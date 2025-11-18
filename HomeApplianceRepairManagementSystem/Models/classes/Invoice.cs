using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApplianceRepairManagementSystem.Models.classes
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int RepairOrderId { get; set; }
        public decimal PartsCost { get; set; }
        public decimal AmounteTotal { get; set; }
        public DateTime InvoiceDate { get; set; }


        public decimal Total => PartsCost + AmounteTotal;

        public RepairOrder RepairOrder { get; set; }


    }
}
