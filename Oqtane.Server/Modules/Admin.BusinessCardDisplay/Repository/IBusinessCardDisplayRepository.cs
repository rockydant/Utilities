using System.Collections.Generic;
using Admin.BusinessCardDisplay.Models;

namespace Admin.BusinessCardDisplay.Repository
{
    public interface IBusinessCardDisplayRepository
    {
        IEnumerable<Models.BusinessCardDisplay> GetBusinessCardDisplays(int ModuleId);
        Models.BusinessCardDisplay GetBusinessCardDisplay(int BusinessCardDisplayId);
        Models.BusinessCardDisplay AddBusinessCardDisplay(Models.BusinessCardDisplay BusinessCardDisplay);
        Models.BusinessCardDisplay UpdateBusinessCardDisplay(Models.BusinessCardDisplay BusinessCardDisplay);
        void DeleteBusinessCardDisplay(int BusinessCardDisplayId);
    }
}
