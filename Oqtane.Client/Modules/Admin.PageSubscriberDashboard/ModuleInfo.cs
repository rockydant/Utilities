using Oqtane.Models;
using Oqtane.Modules;

namespace Admin.PageSubscriberDashboard
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "PageSubscriberDashboard",
            Description = "PageSubscriberDashboard",
            Version = "1.0.0",
            ServerManagerType = "Admin.PageSubscriberDashboard.Manager.PageSubscriberDashboardManager, Oqtane.Server",
            ReleaseVersions = "1.0.0"
        };
    }
}
