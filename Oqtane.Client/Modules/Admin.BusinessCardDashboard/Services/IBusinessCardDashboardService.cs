using System.Collections.Generic;
using System.Threading.Tasks;
using Admin.BusinessCardDashboard.Models;

namespace Admin.BusinessCardDashboard.Services
{
    public interface IBusinessCardDashboardService 
    {
        Task<List<Models.BusinessCardDashboard>> GetBusinessCardDashboardsAsync(int ModuleId);

        Task<Models.BusinessCardDashboard> GetBusinessCardDashboardAsync(int BusinessCardDashboardId, int ModuleId);
        Task<Models.BusinessCardDashboard> GetBusinessCardDashboardAsync(string BusinessCardDashboardName, int ModuleId);

        Task<Models.BusinessCardDashboard> AddBusinessCardDashboardAsync(Models.BusinessCardDashboard BusinessCardDashboard);

        Task<Models.BusinessCardDashboard> UpdateBusinessCardDashboardAsync(Models.BusinessCardDashboard BusinessCardDashboard);

        Task DeleteBusinessCardDashboardAsync(int BusinessCardDashboardId, int ModuleId);
    }
}
