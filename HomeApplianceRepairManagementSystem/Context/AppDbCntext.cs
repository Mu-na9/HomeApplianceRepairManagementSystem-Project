using HomeApplianceRepairManagementSystem.Models.classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApplianceRepairManagementSystem.Context
{
    public class AppDbcntext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<RepairOrder> RepairOrders { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<OrderTechnician> orderTechnicians { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string con = "server = . ; database = HomeApplianceRepairManagementSystem ;Integrated Security=True; Connect Timeout=30;Encrypt=True;Trust Server Certificate=True; ";
            optionsBuilder.UseSqlServer(con);

        }

    }
}
