using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using Admin.PageSubscriber.Models;

namespace Admin.PageSubscriber.Repository
{
    public class PageSubscriberRepository : IPageSubscriberRepository, IService
    {
        private readonly PageSubscriberContext _db;

        public PageSubscriberRepository(PageSubscriberContext context)
        {
            _db = context;
        }

        public IEnumerable<Models.PageSubscriber> GetPageSubscribers(int ModuleId)
        {
            return _db.PageSubscriber.ToList();
        }

        public Models.PageSubscriber GetPageSubscriber(int PageSubscriberId)
        {
            return _db.PageSubscriber.Find(PageSubscriberId);
        }

        public Models.PageSubscriber AddPageSubscriber(Models.PageSubscriber PageSubscriber)
        {
            _db.PageSubscriber.Add(PageSubscriber);
            _db.SaveChanges();
            return PageSubscriber;
        }

        public Models.PageSubscriber UpdatePageSubscriber(Models.PageSubscriber PageSubscriber)
        {
            _db.Entry(PageSubscriber).State = EntityState.Modified;
            _db.SaveChanges();
            return PageSubscriber;
        }

        public void DeletePageSubscriber(int PageSubscriberId)
        {
            Models.PageSubscriber PageSubscriber = _db.PageSubscriber.Find(PageSubscriberId);
            _db.PageSubscriber.Remove(PageSubscriber);
            _db.SaveChanges();
        }
    }
}
