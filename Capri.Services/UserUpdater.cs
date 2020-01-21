﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Capri.Database;
using Capri.Database.Entities.Identity;
using Capri.Web.ViewModels.User;

namespace Capri.Services
{
    public class UserUpdater : IUserUpdater
    {
        private readonly ISqlDbContext _context;

        public UserUpdater(ISqlDbContext context)
        {
            _context = context;
        }

        public async Task<IServiceResult<User>> Update(
            Guid id,
            UserCredentials credentials)
        {
            var existingUser =
                await _context
                .Users
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existingUser == null)
            {
                return ServiceResult<User>.Error(
                    "User with the given does not exist");
            }

            UpdateCredentialsOf(existingUser, credentials);

            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();

            return ServiceResult<User>.Success(existingUser);
        }

        private void UpdateCredentialsOf(
            User user,
            UserCredentials credentials)
        {
            string email = credentials.Email;
            string password = credentials.Password;

            user.UserName = email;
            user.NormalizedUserName =
                    new UpperInvariantLookupNormalizer()
                        .Normalize(email)
                        .ToUpperInvariant();
            user.Email = email;
            user.NormalizedEmail =
                    new UpperInvariantLookupNormalizer()
                        .Normalize(email)
                        .ToUpperInvariant();
            user.PasswordHash =
                new PasswordHasher<User>()
                .HashPassword(user, password);
        }
    }
}