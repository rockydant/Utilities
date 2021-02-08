using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using Admin.PageSubscriber.Models;

namespace Admin.PageSubscriber.Services
{
    public class PageSubscriberService : ServiceBase, IPageSubscriberService, IService
    {
        private readonly SiteState _siteState;

        public PageSubscriberService(HttpClient http, SiteState siteState) : base(http)
        {
            _siteState = siteState;
        }

         private string Apiurl => CreateApiUrl(_siteState.Alias, "PageSubscriber");

        public async Task<List<Models.PageSubscriber>> GetPageSubscribersAsync(int ModuleId)
        {
            List<Models.PageSubscriber> PageSubscribers = await GetJsonAsync<List<Models.PageSubscriber>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", ModuleId));
            return PageSubscribers.OrderBy(item => item.FirstName).ToList();
        }

        public async Task<Models.PageSubscriber> GetPageSubscriberAsync(int PageSubscriberId, int ModuleId)
        {
            return await GetJsonAsync<Models.PageSubscriber>(CreateAuthorizationPolicyUrl($"{Apiurl}/{PageSubscriberId}", ModuleId));
        }

        public async Task<Models.PageSubscriber> AddPageSubscriberAsync(Models.PageSubscriber PageSubscriber)
        {
            return await PostJsonAsync<Models.PageSubscriber>(CreateAuthorizationPolicyUrl($"{Apiurl}", PageSubscriber.ModuleId), PageSubscriber);
        }

        public async Task<Models.PageSubscriber> UpdatePageSubscriberAsync(Models.PageSubscriber PageSubscriber)
        {
            return await PutJsonAsync<Models.PageSubscriber>(CreateAuthorizationPolicyUrl($"{Apiurl}/{PageSubscriber.PageSubscriberId}", PageSubscriber.ModuleId), PageSubscriber);
        }

        public async Task DeletePageSubscriberAsync(int PageSubscriberId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{PageSubscriberId}", ModuleId));
        }
    }
}
