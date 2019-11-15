using System.IO;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;

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
            var inputJsonString = File.ReadAllText(_appSettingsFilePath);

            dynamic jsonObj = JsonConvert.DeserializeObject(inputJsonString);
            jsonObj["SystemSettings"]["MaxNumOfMasterProposalsPerPromoter"] = number;

            var outputJsonString = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(_appSettingsFilePath, outputJsonString);   

            return ServiceResult<int>.Success(number);
        }

        public IServiceResult<int> SetMaxNumOfBachelorProposalsPerPromoter(int number) {
            var inputJsonString = File.ReadAllText(_appSettingsFilePath);

            dynamic jsonObj = JsonConvert.DeserializeObject(inputJsonString);
            jsonObj["SystemSettings"]["MaxNumOfBachelorProposalsPerPromoter"] = number;

            var outputJsonString = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(_appSettingsFilePath, outputJsonString);
            
            return ServiceResult<int>.Success(number);
        }   
    }
}