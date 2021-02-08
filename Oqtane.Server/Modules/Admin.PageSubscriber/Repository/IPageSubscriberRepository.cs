using System.Collections.Generic;
using Admin.PageSubscriber.Models;

namespace Admin.PageSubscriber.Repository
{
    public interface IPageSubscriberRepository
    {
        IEnumerable<Models.PageSubscriber> GetPageSubscribers(int ModuleId);
        Models.PageSubscriber GetPageSubscriber(int PageSubscriberId);
        Models.PageSubscriber AddPageSubscriber(Models.PageSubscriber PageSubscriber);
        Models.PageSubscriber UpdatePageSubscriber(Models.PageSubscriber PageSubscriber);
        void DeletePageSubscriber(int PageSubscriberId);
    }
}
