using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApplianceRepairManagementSystem.Models.classes
{
    public class Customer
    {
      
            public int CustomerId { get; set; }
            public string CName { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
          
        public ICollection<RepairOrder> RepairOrders { get; set; } = new List<RepairOrder>();
      


    }
}
