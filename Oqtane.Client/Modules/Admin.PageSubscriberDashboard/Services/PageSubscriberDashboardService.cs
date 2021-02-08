using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using Admin.PageSubscriberDashboard.Models;

namespace Admin.PageSubscriberDashboard.Services
{
    public class PageSubscriberDashboardService : ServiceBase, IPageSubscriberDashboardService, IService
    {
        private readonly SiteState _siteState;

        public PageSubscriberDashboardService(HttpClient http, SiteState siteState) : base(http)
        {
            _siteState = siteState;
        }

         private string Apiurl => CreateApiUrl(_siteState.Alias, "PageSubscriberDashboard");

        public async Task<List<Models.PageSubscriberDashboard>> GetPageSubscriberDashboardsAsync(int ModuleId)
        {
            List<Models.PageSubscriberDashboard> PageSubscriberDashboards = await GetJsonAsync<List<Models.PageSubscriberDashboard>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", ModuleId));
            return PageSubscriberDashboards.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.PageSubscriberDashboard> GetPageSubscriberDashboardAsync(int PageSubscriberDashboardId, int ModuleId)
        {
            return await GetJsonAsync<Models.PageSubscriberDashboard>(CreateAuthorizationPolicyUrl($"{Apiurl}/{PageSubscriberDashboardId}", ModuleId));
        }

        public async Task<Models.PageSubscriberDashboard> AddPageSubscriberDashboardAsync(Models.PageSubscriberDashboard PageSubscriberDashboard)
        {
            return await PostJsonAsync<Models.PageSubscriberDashboard>(CreateAuthorizationPolicyUrl($"{Apiurl}", PageSubscriberDashboard.ModuleId), PageSubscriberDashboard);
        }

        public async Task<Models.PageSubscriberDashboard> UpdatePageSubscriberDashboardAsync(Models.PageSubscriberDashboard PageSubscriberDashboard)
        {
            return await PutJsonAsync<Models.PageSubscriberDashboard>(CreateAuthorizationPolicyUrl($"{Apiurl}/{PageSubscriberDashboard.PageSubscriberDashboardId}", PageSubscriberDashboard.ModuleId), PageSubscriberDashboard);
        }

        public async Task DeletePageSubscriberDashboardAsync(int PageSubscriberDashboardId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{PageSubscriberDashboardId}", ModuleId));
        }
    }
}
