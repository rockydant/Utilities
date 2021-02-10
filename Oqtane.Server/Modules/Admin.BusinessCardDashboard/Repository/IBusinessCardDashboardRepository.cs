using System.Collections.Generic;
using Admin.BusinessCardDashboard.Models;

namespace Admin.BusinessCardDashboard.Repository
{
    public interface IBusinessCardDashboardRepository
    {
        IEnumerable<Models.BusinessCardDashboard> GetBusinessCardDashboards(int ModuleId);
        Models.BusinessCardDashboard GetBusinessCardDashboard(int BusinessCardDashboardId);

        Models.BusinessCardDashboard GetBusinessCardDashboard(string BusinessCardDashboardName);
        Models.BusinessCardDashboard AddBusinessCardDashboard(Models.BusinessCardDashboard BusinessCardDashboard);
        Models.BusinessCardDashboard UpdateBusinessCardDashboard(Models.BusinessCardDashboard BusinessCardDashboard);
        void DeleteBusinessCardDashboard(int BusinessCardDashboardId);
    }
}
