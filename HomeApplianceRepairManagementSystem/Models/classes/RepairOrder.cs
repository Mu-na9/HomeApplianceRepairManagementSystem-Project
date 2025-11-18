using HomeApplianceRepairManagementSystem.Models.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApplianceRepairManagementSystem.Models.classes
{
    public class RepairOrder
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
   
        public string ApplianceType { get; set; }
        public string ProblemDescription { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? TechnicianId { get; set; }
       
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

         public Customer Customer { get; set; }
         public Technician Technician { get; set; }
         public Invoice Invoice { get; set; }
    }
}

