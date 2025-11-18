using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApplianceRepairManagementSystem.Models.classes
{
    public class Invoice
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
     
        public decimal PartsCost { get; set; }
        public decimal ServiceCost { get; set; }
        public decimal Total { get; set; }
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        
       
        public RepairOrder RepairOrder { get; set; }
    }
}
