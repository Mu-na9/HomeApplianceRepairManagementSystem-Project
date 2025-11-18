using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApplianceRepairManagementSystem.Models.classes
{
    public class RepairOrder
    {
        public int ROrderId { get; set; }
        public int CustomerId { get; set; }
        public string ApplianceType { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? TechnicianId { get; set; }
        public string Status { get; set; }
      


        public Customer Customer { get; set; }
        public Technician Technician { get; set; }
        public Invoice invoice { get; set; }


    }
}
