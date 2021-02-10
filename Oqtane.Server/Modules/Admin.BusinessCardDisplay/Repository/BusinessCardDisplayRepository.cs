using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using Admin.BusinessCardDisplay.Models;

namespace Admin.BusinessCardDisplay.Repository
{
    public class BusinessCardDisplayRepository : IBusinessCardDisplayRepository, IService
    {
        private readonly BusinessCardDisplayContext _db;

        public BusinessCardDisplayRepository(BusinessCardDisplayContext context)
        {
            _db = context;
        }

        public IEnumerable<Models.BusinessCardDisplay> GetBusinessCardDisplays(int ModuleId)
        {
            return _db.BusinessCardDisplay.Where(item => item.ModuleId == ModuleId);
        }

        public Models.BusinessCardDisplay GetBusinessCardDisplay(int BusinessCardDisplayId)
        {
            return _db.BusinessCardDisplay.Find(BusinessCardDisplayId);
        }

        public Models.BusinessCardDisplay AddBusinessCardDisplay(Models.BusinessCardDisplay BusinessCardDisplay)
        {
            _db.BusinessCardDisplay.Add(BusinessCardDisplay);
            _db.SaveChanges();
            return BusinessCardDisplay;
        }

        public Models.BusinessCardDisplay UpdateBusinessCardDisplay(Models.BusinessCardDisplay BusinessCardDisplay)
        {
            _db.Entry(BusinessCardDisplay).State = EntityState.Modified;
            _db.SaveChanges();
            return BusinessCardDisplay;
        }

        public void DeleteBusinessCardDisplay(int BusinessCardDisplayId)
        {
            Models.BusinessCardDisplay BusinessCardDisplay = _db.BusinessCardDisplay.Find(BusinessCardDisplayId);
            _db.BusinessCardDisplay.Remove(BusinessCardDisplay);
            _db.SaveChanges();
        }
    }
}
