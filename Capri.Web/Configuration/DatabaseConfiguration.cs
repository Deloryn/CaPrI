﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Capri.Database;
using Capri.Database.Entities.Identity;

namespace Capri.Web.Configuration
{
    public static class DatabaseConfiguration
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CapriDbContext>(
                options => options.UseSqlServer(connectionString));
            services.AddScoped<ISqlDbContext, CapriDbContext>();

            services.AddIdentity<User, GuidRole>(options => { })
                    .AddEntityFrameworkStores<CapriDbContext>();
        }
    }
}
