using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            var jsonObj = JsonObjFromPath(_appSettingsFilePath);
            jsonObj["SystemSettings"]["MaxNumOfMasterProposalsPerPromoter"] = number;
            SaveJobjectToFile(jsonObj, _appSettingsFilePath);
            return ServiceResult<int>.Success(number);
        }

        public IServiceResult<int> SetMaxNumOfBachelorProposalsPerPromoter(int number) {
            var jsonObj = JsonObjFromPath(_appSettingsFilePath);
            jsonObj["SystemSettings"]["MaxNumOfBachelorProposalsPerPromoter"] = number;
            SaveJobjectToFile(jsonObj, _appSettingsFilePath);
            return ServiceResult<int>.Success(number);
        }

        private JObject JsonObjFromPath(string path) 
        {
            var inputJsonString = File.ReadAllText(path);
            JObject jsonObj = (JObject) JsonConvert.DeserializeObject(inputJsonString);
            return jsonObj;
        }

        private void SaveJobjectToFile(JObject jsonObj, string path)
        {
            var outputJsonString = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(_appSettingsFilePath, outputJsonString);
        }
    }
}