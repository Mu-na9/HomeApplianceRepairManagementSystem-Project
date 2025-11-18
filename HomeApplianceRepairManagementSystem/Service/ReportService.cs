using HomeApplianceRepairManagementSystem.Context;
using HomeApplianceRepairManagementSystem.Models.classes;
using HomeApplianceRepairManagementSystem.Models.Enum;
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

            public Dictionary<OrderStatus, int> GetOrderCountByStatus()
            {
                return _context.RepairOrders
                    .GroupBy(o => o.Status)
                    .ToDictionary(g => g.Key, g => g.Count());
            }

            public Dictionary<string, int> GetOrdersPerTechnician()
            {
                return _context.RepairOrders
                    .Include(o => o.Technician)
                    .Where(o => o.TechnicianId != null)
                    .GroupBy(o => o.Technician.Name)
                    .ToDictionary(g => g.Key, g => g.Count());
            }

            public List<RepairOrder> GetOrdersByDateRange(DateTime startDate, DateTime endDate)
            {
                return _context.RepairOrders
                    .Include(o => o.Customer)
                    .Include(o => o.Technician)
                    .Where(o => o.RequestDate >= startDate && o.RequestDate <= endDate)
                    .ToList();
            }
        }
    }

