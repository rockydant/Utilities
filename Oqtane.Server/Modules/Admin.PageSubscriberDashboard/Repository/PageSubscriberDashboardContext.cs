using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Admin.PageSubscriberDashboard.Models;

namespace Admin.PageSubscriberDashboard.Repository
{
    public class PageSubscriberDashboardContext : DBContextBase, IService
    {
        public virtual DbSet<Models.PageSubscriberDashboard> PageSubscriberDashboard { get; set; }

        public PageSubscriberDashboardContext(ITenantResolver tenantResolver, IHttpContextAccessor accessor) : base(tenantResolver, accessor)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
