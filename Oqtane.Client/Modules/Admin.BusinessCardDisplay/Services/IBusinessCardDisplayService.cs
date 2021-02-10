using System.Collections.Generic;
using System.Threading.Tasks;
using Admin.BusinessCardDisplay.Models;

namespace Admin.BusinessCardDisplay.Services
{
    public interface IBusinessCardDisplayService 
    {
        Task<List<Models.BusinessCardDisplay>> GetBusinessCardDisplaysAsync(int ModuleId);

        Task<Models.BusinessCardDisplay> GetBusinessCardDisplayAsync(int BusinessCardDisplayId, int ModuleId);

        Task<Models.BusinessCardDisplay> AddBusinessCardDisplayAsync(Models.BusinessCardDisplay BusinessCardDisplay);

        Task<Models.BusinessCardDisplay> UpdateBusinessCardDisplayAsync(Models.BusinessCardDisplay BusinessCardDisplay);

        Task DeleteBusinessCardDisplayAsync(int BusinessCardDisplayId, int ModuleId);
    }
}
