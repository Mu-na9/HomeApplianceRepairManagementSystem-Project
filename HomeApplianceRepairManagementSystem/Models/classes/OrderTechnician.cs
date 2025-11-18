using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApplianceRepairManagementSystem.Models.classes
{
    public class OrderTechnician
    {
        public RepairOrder RepairOrder { get; set; }
        public Technician Technician { get; set; }
    }
}
