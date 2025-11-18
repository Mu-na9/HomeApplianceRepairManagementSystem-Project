using HomeApplianceRepairManagementSystem.Models.classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApplianceRepairManagementSystem.Context
{

    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<RepairOrder> RepairOrders { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string con = "server = . ; database = HomeApplianceRepairManagementSystem ;Integrated Security=True; Connect Timeout=30;Encrypt=True;Trust Server Certificate=True; ";
            optionsBuilder.UseSqlServer(con);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // تكوين العلاقة One-to-One بين RepairOrder و Invoice
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.RepairOrder)
                .WithOne(o => o.Invoice)
                .HasForeignKey<Invoice>(i => i.OrderId);
        }

    }
}


