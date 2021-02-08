using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Admin.PageSubscriber.Models;

namespace Admin.PageSubscriber.Repository
{
    public class PageSubscriberContext : DBContextBase, IService
    {
        public virtual DbSet<Models.PageSubscriber> PageSubscriber { get; set; }

        public PageSubscriberContext(ITenantResolver tenantResolver, IHttpContextAccessor accessor) : base(tenantResolver, accessor)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
