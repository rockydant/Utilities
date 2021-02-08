using System.Collections.Generic;
using Admin.PageSubscriberDashboard.Models;

namespace Admin.PageSubscriberDashboard.Repository
{
    public interface IPageSubscriberDashboardRepository
    {
        IEnumerable<Models.PageSubscriberDashboard> GetPageSubscriberDashboards(int ModuleId);
        Models.PageSubscriberDashboard GetPageSubscriberDashboard(int PageSubscriberDashboardId);
        Models.PageSubscriberDashboard AddPageSubscriberDashboard(Models.PageSubscriberDashboard PageSubscriberDashboard);
        Models.PageSubscriberDashboard UpdatePageSubscriberDashboard(Models.PageSubscriberDashboard PageSubscriberDashboard);
        void DeletePageSubscriberDashboard(int PageSubscriberDashboardId);
    }
}
