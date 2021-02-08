using System;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace Admin.QRCodeGenerator.Models
{
    [Table("AdminQRCodeGenerator")]
    public class QRCodeGenerator : IAuditable
    {
        public int QRCodeGeneratorId { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string LinkUrl { get; set; }
        public string QrCode { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
