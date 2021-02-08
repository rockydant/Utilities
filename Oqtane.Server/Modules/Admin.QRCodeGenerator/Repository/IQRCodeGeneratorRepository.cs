using System.Collections.Generic;
using Admin.QRCodeGenerator.Models;

namespace Admin.QRCodeGenerator.Repository
{
    public interface IQRCodeGeneratorRepository
    {
        IEnumerable<Models.QRCodeGenerator> GetQRCodeGenerators(int ModuleId);
        Models.QRCodeGenerator GetQRCodeGenerator(int QRCodeGeneratorId);
        Models.QRCodeGenerator AddQRCodeGenerator(Models.QRCodeGenerator QRCodeGenerator);
        Models.QRCodeGenerator UpdateQRCodeGenerator(Models.QRCodeGenerator QRCodeGenerator);
        void DeleteQRCodeGenerator(int QRCodeGeneratorId);
    }
}
