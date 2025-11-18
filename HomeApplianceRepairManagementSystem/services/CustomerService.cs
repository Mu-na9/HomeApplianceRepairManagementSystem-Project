using HomeApplianceRepairManagementSystem.Context;
using HomeApplianceRepairManagementSystem.Models.classes;
using HomeApplianceRepairManagementSystem.Models.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HomeApplianceRepairManagementSystem.Service
{
    public class CustomerService
    {
        private readonly AppDbContext _context;

        public CustomerService(AppDbContext context)
        {
            _context = context;
        }

        public void AddCustomer(string name, string phone, string address)
        {
            var customer = new Customer { Name = name, Phone = phone, Address = address };
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void EditCustomer(int id, string name, string phone, string address)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null)
            {
                customer.Name = name;
                customer.Phone = phone;
                customer.Address = address;
                _context.SaveChanges();
            }
        }

        public void DeleteCustomer(int id)
        {
            var customer = _context.Customers.Include(c => c.RepairOrders).FirstOrDefault(c => c.Id == id);
            if (customer != null && !customer.RepairOrders.Any())
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }

        public void ListCustomers()
        {
            var customers = _context.Customers.ToList();
            foreach (var c in customers)
            {
                Console.WriteLine($"{c.Id}: {c.Name} - {c.Phone} - {c.Address}");
            }
        }
    }
}





