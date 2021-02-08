using Oqtane.Models;
using Oqtane.Modules;

namespace Admin.QRCodeGenerator
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "QRCodeGenerator",
            Description = "QRCodeGenerator",
            Version = "1.0.0",
            ServerManagerType = "Admin.QRCodeGenerator.Manager.QRCodeGeneratorManager, Oqtane.Server",
            ReleaseVersions = "1.0.0"
        };
    }
}
