using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Repository;
using Admin.BusinessCardDisplay.Models;
using Admin.BusinessCardDisplay.Repository;

namespace Admin.BusinessCardDisplay.Manager
{
    public class BusinessCardDisplayManager : IInstallable, IPortable
    {
        private IBusinessCardDisplayRepository _BusinessCardDisplayRepository;
        private ISqlRepository _sql;

        public BusinessCardDisplayManager(IBusinessCardDisplayRepository BusinessCardDisplayRepository, ISqlRepository sql)
        {
            _BusinessCardDisplayRepository = BusinessCardDisplayRepository;
            _sql = sql;
        }

        public bool Install(Tenant tenant, string version)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "Admin.BusinessCardDisplay." + version + ".sql");
        }

        public bool Uninstall(Tenant tenant)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "Admin.BusinessCardDisplay.Uninstall.sql");
        }

        public string ExportModule(Module module)
        {
            string content = "";
            List<Models.BusinessCardDisplay> BusinessCardDisplays = _BusinessCardDisplayRepository.GetBusinessCardDisplays(module.ModuleId).ToList();
            if (BusinessCardDisplays != null)
            {
                content = JsonSerializer.Serialize(BusinessCardDisplays);
            }
            return content;
        }

        public void ImportModule(Module module, string content, string version)
        {
            List<Models.BusinessCardDisplay> BusinessCardDisplays = null;
            if (!string.IsNullOrEmpty(content))
            {
                BusinessCardDisplays = JsonSerializer.Deserialize<List<Models.BusinessCardDisplay>>(content);
            }
            if (BusinessCardDisplays != null)
            {
                foreach(var BusinessCardDisplay in BusinessCardDisplays)
                {
                    _BusinessCardDisplayRepository.AddBusinessCardDisplay(new Models.BusinessCardDisplay { ModuleId = module.ModuleId, Name = BusinessCardDisplay.Name });
                }
            }
        }
    }
}