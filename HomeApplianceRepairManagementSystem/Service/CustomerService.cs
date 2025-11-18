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
    public class CustomerService 
    {
        public AppDbcntext dbcntext { get; set; }

        public CustomerService(AppDbcntext context)
        {
            _context = context;
        }

        public void AddCustomer(string name, string phone, string address)
        {
            var customer = new Customer
            {
                CName = name,
                Phone = phone,
                Address = address
            };
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void UpdateCustomer(int id, string name, string phone, string address)
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

        public bool DeleteCustomer(int id)
        {
            var customer = _context.Customers.Include(c => c.RepairOrders).FirstOrDefault(c => c.CustomerId == id);
            if (customer == null) return false;

            if (customer.RepairOrders.Any())
            {
                Console.WriteLine("Cannot delete customer with existing orders.");
                return false;
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return true;
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.Find(id);
        }
    }
}

    


