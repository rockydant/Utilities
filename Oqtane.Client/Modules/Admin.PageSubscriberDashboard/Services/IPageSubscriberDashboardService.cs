using System.Collections.Generic;
using System.Threading.Tasks;
using Admin.PageSubscriberDashboard.Models;

namespace Admin.PageSubscriberDashboard.Services
{
    public interface IPageSubscriberDashboardService 
    {
        Task<List<Models.PageSubscriberDashboard>> GetPageSubscriberDashboardsAsync(int ModuleId);

        Task<Models.PageSubscriberDashboard> GetPageSubscriberDashboardAsync(int PageSubscriberDashboardId, int ModuleId);

        Task<Models.PageSubscriberDashboard> AddPageSubscriberDashboardAsync(Models.PageSubscriberDashboard PageSubscriberDashboard);

        Task<Models.PageSubscriberDashboard> UpdatePageSubscriberDashboardAsync(Models.PageSubscriberDashboard PageSubscriberDashboard);

        Task DeletePageSubscriberDashboardAsync(int PageSubscriberDashboardId, int ModuleId);
    }
}
