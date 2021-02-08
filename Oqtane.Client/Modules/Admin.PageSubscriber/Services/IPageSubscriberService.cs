using System.Collections.Generic;
using System.Threading.Tasks;
using Admin.PageSubscriber.Models;

namespace Admin.PageSubscriber.Services
{
    public interface IPageSubscriberService 
    {
        Task<List<Models.PageSubscriber>> GetPageSubscribersAsync(int ModuleId);

        Task<Models.PageSubscriber> GetPageSubscriberAsync(int PageSubscriberId, int ModuleId);

        Task<Models.PageSubscriber> AddPageSubscriberAsync(Models.PageSubscriber PageSubscriber);

        Task<Models.PageSubscriber> UpdatePageSubscriberAsync(Models.PageSubscriber PageSubscriber);

        Task DeletePageSubscriberAsync(int PageSubscriberId, int ModuleId);
    }
}
