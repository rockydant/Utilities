using System.Collections.Generic;
using System.Threading.Tasks;
using Admin.QRCodeGenerator.Models;

namespace Admin.QRCodeGenerator.Services
{
    public interface IQRCodeGeneratorService 
    {
        Task<List<Models.QRCodeGenerator>> GetQRCodeGeneratorsAsync(int ModuleId);

        Task<Models.QRCodeGenerator> GetQRCodeGeneratorAsync(int QRCodeGeneratorId, int ModuleId);

        Task<Models.QRCodeGenerator> AddQRCodeGeneratorAsync(Models.QRCodeGenerator QRCodeGenerator);

        Task<Models.QRCodeGenerator> UpdateQRCodeGeneratorAsync(Models.QRCodeGenerator QRCodeGenerator);

        Task DeleteQRCodeGeneratorAsync(int QRCodeGeneratorId, int ModuleId);
    }
}
