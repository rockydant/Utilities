using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using Admin.BusinessCardDashboard.Models;

namespace Admin.BusinessCardDashboard.Repository
{
    public class BusinessCardDashboardRepository : IBusinessCardDashboardRepository, IService
    {
        private readonly BusinessCardDashboardContext _db;

        public BusinessCardDashboardRepository(BusinessCardDashboardContext context)
        {
            _db = context;
        }

        public IEnumerable<Models.BusinessCardDashboard> GetBusinessCardDashboards(int ModuleId)
        {
            return _db.BusinessCardDashboard.Where(item => item.ModuleId == ModuleId);
        }

        public Models.BusinessCardDashboard GetBusinessCardDashboard(int BusinessCardDashboardId)
        {
            return _db.BusinessCardDashboard.Find(BusinessCardDashboardId);
        }

        public Models.BusinessCardDashboard AddBusinessCardDashboard(Models.BusinessCardDashboard BusinessCardDashboard)
        {
            _db.BusinessCardDashboard.Add(BusinessCardDashboard);
            _db.SaveChanges();
            return BusinessCardDashboard;
        }

        public Models.BusinessCardDashboard UpdateBusinessCardDashboard(Models.BusinessCardDashboard BusinessCardDashboard)
        {
            _db.Entry(BusinessCardDashboard).State = EntityState.Modified;
            _db.SaveChanges();
            return BusinessCardDashboard;
        }

        public void DeleteBusinessCardDashboard(int BusinessCardDashboardId)
        {
            Models.BusinessCardDashboard BusinessCardDashboard = _db.BusinessCardDashboard.Find(BusinessCardDashboardId);
            _db.BusinessCardDashboard.Remove(BusinessCardDashboard);
            _db.SaveChanges();
        }
    }
}
