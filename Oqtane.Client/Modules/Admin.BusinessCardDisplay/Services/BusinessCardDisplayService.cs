using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using Admin.BusinessCardDisplay.Models;

namespace Admin.BusinessCardDisplay.Services
{
    public class BusinessCardDisplayService : ServiceBase, IBusinessCardDisplayService, IService
    {
        private readonly SiteState _siteState;

        public BusinessCardDisplayService(HttpClient http, SiteState siteState) : base(http)
        {
            _siteState = siteState;
        }

         private string Apiurl => CreateApiUrl(_siteState.Alias, "BusinessCardDisplay");

        public async Task<List<Models.BusinessCardDisplay>> GetBusinessCardDisplaysAsync(int ModuleId)
        {
            List<Models.BusinessCardDisplay> BusinessCardDisplays = await GetJsonAsync<List<Models.BusinessCardDisplay>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", ModuleId));
            return BusinessCardDisplays.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.BusinessCardDisplay> GetBusinessCardDisplayAsync(int BusinessCardDisplayId, int ModuleId)
        {
            return await GetJsonAsync<Models.BusinessCardDisplay>(CreateAuthorizationPolicyUrl($"{Apiurl}/{BusinessCardDisplayId}", ModuleId));
        }

        public async Task<Models.BusinessCardDisplay> AddBusinessCardDisplayAsync(Models.BusinessCardDisplay BusinessCardDisplay)
        {
            return await PostJsonAsync<Models.BusinessCardDisplay>(CreateAuthorizationPolicyUrl($"{Apiurl}", BusinessCardDisplay.ModuleId), BusinessCardDisplay);
        }

        public async Task<Models.BusinessCardDisplay> UpdateBusinessCardDisplayAsync(Models.BusinessCardDisplay BusinessCardDisplay)
        {
            return await PutJsonAsync<Models.BusinessCardDisplay>(CreateAuthorizationPolicyUrl($"{Apiurl}/{BusinessCardDisplay.BusinessCardDisplayId}", BusinessCardDisplay.ModuleId), BusinessCardDisplay);
        }

        public async Task DeleteBusinessCardDisplayAsync(int BusinessCardDisplayId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{BusinessCardDisplayId}", ModuleId));
        }
    }
}
