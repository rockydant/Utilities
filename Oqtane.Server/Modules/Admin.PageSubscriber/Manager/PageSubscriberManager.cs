using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Repository;
using Admin.PageSubscriber.Models;
using Admin.PageSubscriber.Repository;

namespace Admin.PageSubscriber.Manager
{
    public class PageSubscriberManager : IInstallable, IPortable
    {
        private IPageSubscriberRepository _PageSubscriberRepository;
        private ISqlRepository _sql;

        public PageSubscriberManager(IPageSubscriberRepository PageSubscriberRepository, ISqlRepository sql)
        {
            _PageSubscriberRepository = PageSubscriberRepository;
            _sql = sql;
        }

        public bool Install(Tenant tenant, string version)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "Admin.PageSubscriber." + version + ".sql");
        }

        public bool Uninstall(Tenant tenant)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "Admin.PageSubscriber.Uninstall.sql");
        }

        public string ExportModule(Module module)
        {
            string content = "";
            List<Models.PageSubscriber> PageSubscribers = _PageSubscriberRepository.GetPageSubscribers(module.ModuleId).ToList();
            if (PageSubscribers != null)
            {
                content = JsonSerializer.Serialize(PageSubscribers);
            }
            return content;
        }

        public void ImportModule(Module module, string content, string version)
        {
            List<Models.PageSubscriber> PageSubscribers = null;
            if (!string.IsNullOrEmpty(content))
            {
                PageSubscribers = JsonSerializer.Deserialize<List<Models.PageSubscriber>>(content);
            }
            if (PageSubscribers != null)
            {
                foreach(var PageSubscriber in PageSubscribers)
                {
                    _PageSubscriberRepository.AddPageSubscriber(new Models.PageSubscriber { ModuleId = module.ModuleId, FirstName = PageSubscriber.FirstName });
                }
            }
        }
    }
}
