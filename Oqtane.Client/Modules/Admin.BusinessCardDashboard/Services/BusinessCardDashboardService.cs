using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using Admin.BusinessCardDashboard.Models;

namespace Admin.BusinessCardDashboard.Services
{
    public class BusinessCardDashboardService : ServiceBase, IBusinessCardDashboardService, IService
    {
        private readonly SiteState _siteState;

        public BusinessCardDashboardService(HttpClient http, SiteState siteState) : base(http)
        {
            _siteState = siteState;
        }

         private string Apiurl => CreateApiUrl(_siteState.Alias, "BusinessCardDashboard");

        public async Task<List<Models.BusinessCardDashboard>> GetBusinessCardDashboardsAsync(int ModuleId)
        {
            List<Models.BusinessCardDashboard> BusinessCardDashboards = await GetJsonAsync<List<Models.BusinessCardDashboard>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", ModuleId));
            return BusinessCardDashboards.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.BusinessCardDashboard> GetBusinessCardDashboardAsync(string BusinessCardDashboardName, int ModuleId)
        {
            return await GetJsonAsync<Models.BusinessCardDashboard>(CreateAuthorizationPolicyUrl($"{Apiurl}/{BusinessCardDashboardName}", ModuleId));
        }

        public async Task<Models.BusinessCardDashboard> GetBusinessCardDashboardAsync(int BusinessCardDashboardId, int ModuleId)
        {
            return await GetJsonAsync<Models.BusinessCardDashboard>(CreateAuthorizationPolicyUrl($"{Apiurl}/{BusinessCardDashboardId}", ModuleId));
        }

        public async Task<Models.BusinessCardDashboard> AddBusinessCardDashboardAsync(Models.BusinessCardDashboard BusinessCardDashboard)
        {
            return await PostJsonAsync<Models.BusinessCardDashboard>(CreateAuthorizationPolicyUrl($"{Apiurl}", BusinessCardDashboard.ModuleId), BusinessCardDashboard);
        }

        public async Task<Models.BusinessCardDashboard> UpdateBusinessCardDashboardAsync(Models.BusinessCardDashboard BusinessCardDashboard)
        {
            return await PutJsonAsync<Models.BusinessCardDashboard>(CreateAuthorizationPolicyUrl($"{Apiurl}/{BusinessCardDashboard.BusinessCardDashboardId}", BusinessCardDashboard.ModuleId), BusinessCardDashboard);
        }

        public async Task DeleteBusinessCardDashboardAsync(int BusinessCardDashboardId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{BusinessCardDashboardId}", ModuleId));
        }
    }
}
