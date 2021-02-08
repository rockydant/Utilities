using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using Admin.QRCodeGenerator.Models;

namespace Admin.QRCodeGenerator.Services
{
    public class QRCodeGeneratorService : ServiceBase, IQRCodeGeneratorService, IService
    {
        private readonly SiteState _siteState;

        public QRCodeGeneratorService(HttpClient http, SiteState siteState) : base(http)
        {
            _siteState = siteState;
        }

         private string Apiurl => CreateApiUrl(_siteState.Alias, "QRCodeGenerator");

        public async Task<List<Models.QRCodeGenerator>> GetQRCodeGeneratorsAsync(int ModuleId)
        {
            List<Models.QRCodeGenerator> QRCodeGenerators = await GetJsonAsync<List<Models.QRCodeGenerator>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", ModuleId));
            return QRCodeGenerators.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.QRCodeGenerator> GetQRCodeGeneratorAsync(int QRCodeGeneratorId, int ModuleId)
        {
            return await GetJsonAsync<Models.QRCodeGenerator>(CreateAuthorizationPolicyUrl($"{Apiurl}/{QRCodeGeneratorId}", ModuleId));
        }

        public async Task<Models.QRCodeGenerator> AddQRCodeGeneratorAsync(Models.QRCodeGenerator QRCodeGenerator)
        {
            return await PostJsonAsync<Models.QRCodeGenerator>(CreateAuthorizationPolicyUrl($"{Apiurl}", QRCodeGenerator.ModuleId), QRCodeGenerator);
        }

        public async Task<Models.QRCodeGenerator> UpdateQRCodeGeneratorAsync(Models.QRCodeGenerator QRCodeGenerator)
        {
            return await PutJsonAsync<Models.QRCodeGenerator>(CreateAuthorizationPolicyUrl($"{Apiurl}/{QRCodeGenerator.QRCodeGeneratorId}", QRCodeGenerator.ModuleId), QRCodeGenerator);
        }

        public async Task DeleteQRCodeGeneratorAsync(int QRCodeGeneratorId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{QRCodeGeneratorId}", ModuleId));
        }
    }
}
