using HomeApplianceRepairManagementSystem.Context;
using HomeApplianceRepairManagementSystem.Models.classes;
using HomeApplianceRepairManagementSystem.Models.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApplianceRepairManagementSystem.Service
{

    public class ReportService
    {
        private readonly AppDbContext _context;
        public ReportService(AppDbContext context)
        {
            _context = context;
        }
        public void OrdersCountByStatus()
        {
            var counts = _context.RepairOrders.GroupBy(o => o.Status).Select(g => new { Status = g.Key, Count = g.Count() }).ToList();
            foreach (var c in counts)
            {
                Console.WriteLine($"{c.Status}: {c.Count}");
            }
        }
        public void OrdersPerTechnician()
        {
            var orders = _context.RepairOrders.Include(o => o.Technician).Where(o => o.Technician != null).GroupBy(o => o.Technician.Name).Select(g => new { Technician = g.Key, Count = g.Count() }).ToList();
            foreach (var o in orders)
            {
                Console.WriteLine($"{o.Technician}: {o.Count} orders");
            }
        }
        public void OrdersByDate(DateTime startDate, DateTime endDate)
        {
            var orders = _context.RepairOrders.Where(o => o.CreatedDate >= startDate && o.CreatedDate <= endDate).Include(o => o.Customer).ToList();
            foreach (var o in orders)
            {
                Console.WriteLine($"{o.Id}: {o.Customer.Name} - {o.CreatedDate}");
            }
        }
    }
}

