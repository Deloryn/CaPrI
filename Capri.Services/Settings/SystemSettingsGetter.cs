using Microsoft.Extensions.Options;
using Capri.Database;

namespace Capri.Services.Settings
{
    public class SystemSettingsGetter : ISystemSettingsGetter
    {
        private SystemSettings systemSettings;
        private readonly ISqlDbContext _context;

        public SystemSettingsGetter(
            IOptionsMonitor<SystemSettings> optionsMonitor,
            ISqlDbContext context)
        {
            _context = context;
            systemSettings = optionsMonitor.CurrentValue;
            optionsMonitor.OnChange(changedSystemSettings => {
                systemSettings = changedSystemSettings;
            });
        }

        public SystemSettings GetSystemSettings()
        {
            return systemSettings;
        }
    }
}