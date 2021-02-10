using Oqtane.Models;
using Oqtane.Modules;

namespace Admin.BusinessCardDashboard
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "BusinessCardDashboard",
            Description = "BusinessCardDashboard",
            Version = "1.0.0",
            ServerManagerType = "Admin.BusinessCardDashboard.Manager.BusinessCardDashboardManager, Oqtane.Server",
            ReleaseVersions = "1.0.0"
        };
    }
}
