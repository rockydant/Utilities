using Oqtane.Models;
using Oqtane.Modules;

namespace Admin.BusinessCardDisplay
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "BusinessCardDisplay",
            Description = "BusinessCardDisplay",
            Version = "1.0.0",
            ServerManagerType = "Admin.BusinessCardDisplay.Manager.BusinessCardDisplayManager, Oqtane.Server",
            ReleaseVersions = "1.0.0"
        };
    }
}
