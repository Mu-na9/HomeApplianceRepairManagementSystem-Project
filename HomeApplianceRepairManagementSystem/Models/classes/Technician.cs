using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApplianceRepairManagementSystem.Models.classes
{
    public class Technician
    {
        public int TechId { get; set; }
        public string TName { get; set; }
        public string Phone { get; set; }
        public string Specialty { get; set; }

       
        
        
        public ICollection<RepairOrder> RepairOrders { get; set; }


    }
}
