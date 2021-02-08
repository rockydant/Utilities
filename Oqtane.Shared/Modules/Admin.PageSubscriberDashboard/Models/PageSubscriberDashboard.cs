using System;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace Admin.PageSubscriberDashboard.Models
{
    [Table("AdminPageSubscriberDashboard")]
    public class PageSubscriberDashboard : IAuditable
    {
        public int PageSubscriberDashboardId { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
