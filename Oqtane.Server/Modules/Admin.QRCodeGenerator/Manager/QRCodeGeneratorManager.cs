using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Repository;
using Admin.QRCodeGenerator.Models;
using Admin.QRCodeGenerator.Repository;

namespace Admin.QRCodeGenerator.Manager
{
    public class QRCodeGeneratorManager : IInstallable, IPortable
    {
        private IQRCodeGeneratorRepository _QRCodeGeneratorRepository;
        private ISqlRepository _sql;

        public QRCodeGeneratorManager(IQRCodeGeneratorRepository QRCodeGeneratorRepository, ISqlRepository sql)
        {
            _QRCodeGeneratorRepository = QRCodeGeneratorRepository;
            _sql = sql;
        }

        public bool Install(Tenant tenant, string version)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "Admin.QRCodeGenerator." + version + ".sql");
        }

        public bool Uninstall(Tenant tenant)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "Admin.QRCodeGenerator.Uninstall.sql");
        }

        public string ExportModule(Module module)
        {
            string content = "";
            List<Models.QRCodeGenerator> QRCodeGenerators = _QRCodeGeneratorRepository.GetQRCodeGenerators(module.ModuleId).ToList();
            if (QRCodeGenerators != null)
            {
                content = JsonSerializer.Serialize(QRCodeGenerators);
            }
            return content;
        }

        public void ImportModule(Module module, string content, string version)
        {
            List<Models.QRCodeGenerator> QRCodeGenerators = null;
            if (!string.IsNullOrEmpty(content))
            {
                QRCodeGenerators = JsonSerializer.Deserialize<List<Models.QRCodeGenerator>>(content);
            }
            if (QRCodeGenerators != null)
            {
                foreach(var QRCodeGenerator in QRCodeGenerators)
                {
                    _QRCodeGeneratorRepository.AddQRCodeGenerator(new Models.QRCodeGenerator { ModuleId = module.ModuleId, Name = QRCodeGenerator.Name });
                }
            }
        }
    }
}