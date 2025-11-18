using HomeApplianceRepairManagementSystem.Context;
using HomeApplianceRepairManagementSystem.Models.Enum;
using HomeApplianceRepairManagementSystem.Service;
using HomeApplianceRepairManagementSystem.services;
using Microsoft.EntityFrameworkCore;
using System;

namespace HomeApplianceRepairManagementSystem
{
    class Program
    {
        static void Main()
        {

            using var context = new AppDbContext();
            context.Database.Migrate();

            var customerService = new CustomerService(context);
            var technicianService = new TechnicianService(context);
            var repairOrderService = new RepairOrderService(context);
            var invoiceService = new InvoiceService(context);
            var reportService = new ReportService(context);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Main Menu:");
                Console.WriteLine("1. Manage Customers");
                Console.WriteLine("2. Manage Technicians");
                Console.WriteLine("3. Manage Repair Orders");
                Console.WriteLine("4. Reports");
                Console.WriteLine("5. Exit");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ManageCustomers(customerService);
                        break;
                    case "2":
                        ManageTechnicians(technicianService);
                        break;
                    case "3":
                        ManageRepairOrders(repairOrderService);
                        break;
                    case "4":
                        ManageReports(reportService);
                        break;
                    case "5":
                        return;
                }
            }
        }

        static void ManageCustomers(CustomerService service)
        {
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. Edit Customer");
            Console.WriteLine("3. Delete Customer");
            Console.WriteLine("4. List Customers");
            Console.WriteLine("5. Back");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Name: ");
                    var name = Console.ReadLine();
                    Console.Write("Phone: ");
                    var phone = Console.ReadLine();
                    Console.Write("Address: ");
                    var address = Console.ReadLine();
                    service.AddCustomer(name, phone, address);
                    break;
                case "2":
                    Console.Write("ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Name: ");
                    name = Console.ReadLine();
                    Console.Write("Phone: ");
                    phone = Console.ReadLine();
                    Console.Write("Address: ");
                    address = Console.ReadLine();
                    service.EditCustomer(id, name, phone, address);
                    break;
                case "3":
                    Console.Write("ID: ");
                    id = int.Parse(Console.ReadLine());
                    service.DeleteCustomer(id);
                    break;
                case "4":
                    service.ListCustomers();
                    break;
            }
            Console.ReadKey();
        }

        static void ManageTechnicians(TechnicianService service)
        {
            Console.WriteLine("1. Add Technician");
            Console.WriteLine("2. Edit Technician");
            Console.WriteLine("3. Delete Technician");
            Console.WriteLine("4. List Technicians");
            Console.WriteLine("5. Back");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Name: ");
                    var name = Console.ReadLine();
                    Console.Write("Phone: ");
                    var phone = Console.ReadLine();
                    Console.Write("Specialty: ");
                    var specialty = Console.ReadLine();
                    service.AddTechnician(name, phone, specialty);
                    break;
                case "2":
                    Console.Write("ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Name: ");
                    name = Console.ReadLine();
                    Console.Write("Phone: ");
                    phone = Console.ReadLine();
                    Console.Write("Specialty: ");
                    specialty = Console.ReadLine();
                    service.EditTechnician(id, name, phone, specialty);
                    break;
                case "3":
                    Console.Write("ID: ");
                    id = int.Parse(Console.ReadLine());
                    service.DeleteTechnician(id);
                    break;
                case "4":
                    service.ListTechnicians();
                    break;
            }
            Console.ReadKey();
        }

        static void ManageRepairOrders(RepairOrderService service)
        {
            Console.WriteLine("1. Add Order");
            Console.WriteLine("2. Assign Technician");
            Console.WriteLine("3. Change Status");
            Console.WriteLine("4. Complete Order");
            Console.WriteLine("5. Cancel Order");
            Console.WriteLine("6. List Orders");
            Console.WriteLine("7. Back");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Customer ID: ");
                    int customerId = int.Parse(Console.ReadLine());
                    Console.Write("Appliance Type: ");
                    var applianceType = Console.ReadLine();
                    Console.Write("Problem: ");
                    var problem = Console.ReadLine();
                    service.CreateOrder(customerId, applianceType, problem);
                    break;
                case "2":
                    Console.Write("Order ID: ");
                    int orderId = int.Parse(Console.ReadLine());
                    Console.Write("Technician ID: ");
                    int technicianId = int.Parse(Console.ReadLine());
                    service.AssignTechnician(orderId, technicianId);
                    break;
                case "3":
                    Console.Write("Order ID: ");
                    orderId = int.Parse(Console.ReadLine());
                    Console.Write("Status (0=Pending,1=Assigned,2=InProgress,3=Completed,4=Cancelled): ");
                    OrderStatus status = (OrderStatus)int.Parse(Console.ReadLine());
                    service.ChangeStatus(orderId, status);
                    break;
                case "4":
                    Console.Write("Order ID: ");
                    orderId = int.Parse(Console.ReadLine());
                    Console.Write("Parts Cost: ");
                    decimal partsCost = decimal.Parse(Console.ReadLine());
                    Console.Write("Service Cost: ");
                    decimal serviceCost = decimal.Parse(Console.ReadLine());
                    service.CompleteOrder(orderId, partsCost, serviceCost);
                    break;
                case "5":
                    Console.Write("Order ID: ");
                    orderId = int.Parse(Console.ReadLine());
                    service.CancelOrder(orderId);
                    break;
                case "6":
                    service.ListOrders();
                    break;
            }
            Console.ReadKey();
        }

        static void ManageReports(ReportService service)
        {
            Console.WriteLine("1. Orders by Status");
            Console.WriteLine("2. Orders per Technician");
            Console.WriteLine("3. Orders by Date");
            Console.WriteLine("4. Back");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    service.OrdersCountByStatus();
                    break;
                case "2":
                    service.OrdersPerTechnician();
                    break;
                case "3":
                    Console.Write("Start Date (yyyy-mm-dd): ");
                    DateTime start = DateTime.Parse(Console.ReadLine());
                    Console.Write("End Date (yyyy-mm-dd): ");
                    DateTime end = DateTime.Parse(Console.ReadLine());
                    service.OrdersByDate(start, end);
                    break;
            }
            Console.ReadKey();
        }
    }

}