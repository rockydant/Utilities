using Oqtane.Models;
using Oqtane.Modules;

namespace Admin.PageSubscriber
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "PageSubscriber",
            Description = "PageSubscriber",
            Version = "1.0.0",
            ServerManagerType = "Admin.PageSubscriber.Manager.PageSubscriberManager, Oqtane.Server",
            ReleaseVersions = "1.0.0"
        };
    }
}
