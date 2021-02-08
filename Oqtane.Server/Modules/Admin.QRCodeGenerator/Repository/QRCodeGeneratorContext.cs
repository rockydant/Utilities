using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Admin.QRCodeGenerator.Models;

namespace Admin.QRCodeGenerator.Repository
{
    public class QRCodeGeneratorContext : DBContextBase, IService
    {
        public virtual DbSet<Models.QRCodeGenerator> QRCodeGenerator { get; set; }

        public QRCodeGeneratorContext(ITenantResolver tenantResolver, IHttpContextAccessor accessor) : base(tenantResolver, accessor)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
