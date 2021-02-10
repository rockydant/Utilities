using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Repository;
using Admin.BusinessCardDashboard.Models;
using Admin.BusinessCardDashboard.Repository;

namespace Admin.BusinessCardDashboard.Manager
{
    public class BusinessCardDashboardManager : IInstallable, IPortable
    {
        private IBusinessCardDashboardRepository _BusinessCardDashboardRepository;
        private ISqlRepository _sql;

        public BusinessCardDashboardManager(IBusinessCardDashboardRepository BusinessCardDashboardRepository, ISqlRepository sql)
        {
            _BusinessCardDashboardRepository = BusinessCardDashboardRepository;
            _sql = sql;
        }

        public bool Install(Tenant tenant, string version)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "Admin.BusinessCardDashboard." + version + ".sql");
        }

        public bool Uninstall(Tenant tenant)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "Admin.BusinessCardDashboard.Uninstall.sql");
        }

        public string ExportModule(Module module)
        {
            string content = "";
            List<Models.BusinessCardDashboard> BusinessCardDashboards = _BusinessCardDashboardRepository.GetBusinessCardDashboards(module.ModuleId).ToList();
            if (BusinessCardDashboards != null)
            {
                content = JsonSerializer.Serialize(BusinessCardDashboards);
            }
            return content;
        }

        public void ImportModule(Module module, string content, string version)
        {
            List<Models.BusinessCardDashboard> BusinessCardDashboards = null;
            if (!string.IsNullOrEmpty(content))
            {
                BusinessCardDashboards = JsonSerializer.Deserialize<List<Models.BusinessCardDashboard>>(content);
            }
            if (BusinessCardDashboards != null)
            {
                foreach(var BusinessCardDashboard in BusinessCardDashboards)
                {
                    _BusinessCardDashboardRepository.AddBusinessCardDashboard(new Models.BusinessCardDashboard { ModuleId = module.ModuleId, Name = BusinessCardDashboard.Name });
                }
            }
        }
    }
}