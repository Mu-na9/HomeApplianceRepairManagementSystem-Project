using HomeApplianceRepairManagementSystem.Context;
using HomeApplianceRepairManagementSystem.Models.classes;
using HomeApplianceRepairManagementSystem.Models.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApplianceRepairManagementSystem.services
{
    public class RepairOrderService
    {
        private readonly AppDbContext _context;

        public RepairOrderService(AppDbContext context)
        {
            _context = context;
        }

        public void CreateOrder(int customerId, string applianceType, string problemDescription)
        {
            var order = new RepairOrder
            {
                CustomerId = customerId,
                ApplianceType = applianceType,
                ProblemDescription = problemDescription
            };
            _context.RepairOrders.Add(order);
            _context.SaveChanges();
        }

        public void AssignTechnician(int orderId, int technicianId)
        {
            var order = _context.RepairOrders.Find(orderId);
            if (order != null)
            {
                order.TechnicianId = technicianId;
                order.Status = OrderStatus.Assigned;
                _context.SaveChanges();
            }
        }

        public void ChangeStatus(int orderId, OrderStatus status)
        {
            var order = _context.RepairOrders.Find(orderId);
            if (order != null)
            {
                order.Status = status;
                _context.SaveChanges();
            }
        }

        public void CompleteOrder(int orderId, decimal partsCost, decimal serviceCost)
        {
            var order = _context.RepairOrders.Find(orderId);
            if (order != null)
            {
                order.Status = OrderStatus.Completed;
                var invoice = new Invoice
                {
                    OrderId = orderId,
                    PartsCost = partsCost,
                    ServiceCost = serviceCost,
                    Total = partsCost + serviceCost
                };
                _context.Invoices.Add(invoice);
                _context.SaveChanges();
            }
        }

        public void CancelOrder(int orderId)
        {
            var order = _context.RepairOrders.Find(orderId);
            if (order != null)
            {
                order.Status = OrderStatus.Cancelled;
                _context.SaveChanges();
            }
        }

        public void ListOrders()
        {
            var orders = _context.RepairOrders.Include(o => o.Customer).Include(o => o.Technician).ToList();
            foreach (var o in orders)
            {
                Console.WriteLine($"{o.Id}: {o.Customer.Name} - {o.ApplianceType} - {o.Status} - Technician: {o.Technician?.Name ?? "None"}");
            }
        }
    }


}
