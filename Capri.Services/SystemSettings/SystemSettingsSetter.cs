using System.IO;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Capri.Services.Settings;

namespace Capri.Services.SystemSettings
{
    public class SystemSettingsSetter : ISystemSettingsSetter
    {
        private readonly string _appSettingsFilePath;
        public SystemSettingsSetter(IHostingEnvironment env)
        {
            var fileProvider = env.ContentRootFileProvider;
            var appSettingsFileInfo = fileProvider.GetFileInfo("appsettings.json");
            _appSettingsFilePath = appSettingsFileInfo.PhysicalPath;
        }

        public IServiceResult<int> SetMaxNumOfMasterProposalsPerPromoter(int number)
        {
            var appSettings = GetAppSettingsFrom(_appSettingsFilePath);
            appSettings.SystemSettings.MaxNumOfMasterProposalsPerPromoter = number;
            SaveAppSettingsToFile(appSettings, _appSettingsFilePath);
            return ServiceResult<int>.Success(number);
        }

        public IServiceResult<int> SetMaxNumOfBachelorProposalsPerPromoter(int number) {
            var appSettings = GetAppSettingsFrom(_appSettingsFilePath);
            appSettings.SystemSettings.MaxNumOfBachelorProposalsPerPromoter = number;
            SaveAppSettingsToFile(appSettings, _appSettingsFilePath);
            return ServiceResult<int>.Success(number);
        }

        private AppSettings GetAppSettingsFrom(string path) 
        {
            var inputJsonString = File.ReadAllText(path);
            var appSettings = JsonConvert.DeserializeObject<AppSettings>(inputJsonString);
            return appSettings;
        }

        private void SaveAppSettingsToFile(AppSettings appSettings, string path)
        {
            var outputJsonString = JsonConvert.SerializeObject(appSettings, Formatting.Indented);
            File.WriteAllText(_appSettingsFilePath, outputJsonString);
        }
    }
}