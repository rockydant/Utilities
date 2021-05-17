using System;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace Admin.PageSubscriber.Models
{
    [Table("AdminPageSubscriber")]
    public class PageSubscriber : IAuditable
    {
        public int PageSubscriberId { get; set; }
        public int ModuleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int NoAttendee { get; set; }
    }
}
