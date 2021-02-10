using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Admin.BusinessCardDisplay.Models;

namespace Admin.BusinessCardDisplay.Repository
{
    public class BusinessCardDisplayContext : DBContextBase, IService
    {
        public virtual DbSet<Models.BusinessCardDisplay> BusinessCardDisplay { get; set; }

        public BusinessCardDisplayContext(ITenantResolver tenantResolver, IHttpContextAccessor accessor) : base(tenantResolver, accessor)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
