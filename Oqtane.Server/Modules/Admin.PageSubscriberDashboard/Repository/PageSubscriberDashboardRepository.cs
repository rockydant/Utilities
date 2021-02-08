using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using Admin.PageSubscriberDashboard.Models;

namespace Admin.PageSubscriberDashboard.Repository
{
    public class PageSubscriberDashboardRepository : IPageSubscriberDashboardRepository, IService
    {
        private readonly PageSubscriberDashboardContext _db;

        public PageSubscriberDashboardRepository(PageSubscriberDashboardContext context)
        {
            _db = context;
        }

        public IEnumerable<Models.PageSubscriberDashboard> GetPageSubscriberDashboards(int ModuleId)
        {
            return _db.PageSubscriberDashboard.Where(item => item.ModuleId == ModuleId);
        }

        public Models.PageSubscriberDashboard GetPageSubscriberDashboard(int PageSubscriberDashboardId)
        {
            return _db.PageSubscriberDashboard.Find(PageSubscriberDashboardId);
        }

        public Models.PageSubscriberDashboard AddPageSubscriberDashboard(Models.PageSubscriberDashboard PageSubscriberDashboard)
        {
            _db.PageSubscriberDashboard.Add(PageSubscriberDashboard);
            _db.SaveChanges();
            return PageSubscriberDashboard;
        }

        public Models.PageSubscriberDashboard UpdatePageSubscriberDashboard(Models.PageSubscriberDashboard PageSubscriberDashboard)
        {
            _db.Entry(PageSubscriberDashboard).State = EntityState.Modified;
            _db.SaveChanges();
            return PageSubscriberDashboard;
        }

        public void DeletePageSubscriberDashboard(int PageSubscriberDashboardId)
        {
            Models.PageSubscriberDashboard PageSubscriberDashboard = _db.PageSubscriberDashboard.Find(PageSubscriberDashboardId);
            _db.PageSubscriberDashboard.Remove(PageSubscriberDashboard);
            _db.SaveChanges();
        }
    }
}
