using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Repository;
using Admin.PageSubscriberDashboard.Models;
using Admin.PageSubscriberDashboard.Repository;

namespace Admin.PageSubscriberDashboard.Manager
{
    public class PageSubscriberDashboardManager : IInstallable, IPortable
    {
        private IPageSubscriberDashboardRepository _PageSubscriberDashboardRepository;
        private ISqlRepository _sql;

        public PageSubscriberDashboardManager(IPageSubscriberDashboardRepository PageSubscriberDashboardRepository, ISqlRepository sql)
        {
            _PageSubscriberDashboardRepository = PageSubscriberDashboardRepository;
            _sql = sql;
        }

        public bool Install(Tenant tenant, string version)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "Admin.PageSubscriberDashboard." + version + ".sql");
        }

        public bool Uninstall(Tenant tenant)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "Admin.PageSubscriberDashboard.Uninstall.sql");
        }

        public string ExportModule(Module module)
        {
            string content = "";
            List<Models.PageSubscriberDashboard> PageSubscriberDashboards = _PageSubscriberDashboardRepository.GetPageSubscriberDashboards(module.ModuleId).ToList();
            if (PageSubscriberDashboards != null)
            {
                content = JsonSerializer.Serialize(PageSubscriberDashboards);
            }
            return content;
        }

        public void ImportModule(Module module, string content, string version)
        {
            List<Models.PageSubscriberDashboard> PageSubscriberDashboards = null;
            if (!string.IsNullOrEmpty(content))
            {
                PageSubscriberDashboards = JsonSerializer.Deserialize<List<Models.PageSubscriberDashboard>>(content);
            }
            if (PageSubscriberDashboards != null)
            {
                foreach(var PageSubscriberDashboard in PageSubscriberDashboards)
                {
                    _PageSubscriberDashboardRepository.AddPageSubscriberDashboard(new Models.PageSubscriberDashboard { ModuleId = module.ModuleId, Name = PageSubscriberDashboard.Name });
                }
            }
        }
    }
}