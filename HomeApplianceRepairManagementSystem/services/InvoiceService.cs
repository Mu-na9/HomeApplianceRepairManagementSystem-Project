using HomeApplianceRepairManagementSystem.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApplianceRepairManagementSystem.services
{
        public class InvoiceService
        {
            private readonly AppDbContext _context;
            public InvoiceService(AppDbContext context)
            {
                _context = context;
            }
            public void ListInvoices()
            {
                var invoices = _context.Invoices.Include(i => i.RepairOrder).ThenInclude(o => o.Customer).ToList();
                foreach (var i in invoices)
                {
                    Console.WriteLine($"{i.Id}: Order {i.OrderId} - Customer: {i.RepairOrder.Customer.Name} - Total: {i.Total:C} - Date: {i.InvoiceDate}");
                }
            }
        }
    
}
