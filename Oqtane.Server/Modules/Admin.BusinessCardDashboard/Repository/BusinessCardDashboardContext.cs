using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Admin.BusinessCardDashboard.Models;

namespace Admin.BusinessCardDashboard.Repository
{
    public class BusinessCardDashboardContext : DBContextBase, IService
    {
        public virtual DbSet<Models.BusinessCardDashboard> BusinessCardDashboard { get; set; }

        public BusinessCardDashboardContext(ITenantResolver tenantResolver, IHttpContextAccessor accessor) : base(tenantResolver, accessor)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
