using HomeApplianceRepairManagementSystem.Context;
using HomeApplianceRepairManagementSystem.Models.Enum;
using HomeApplianceRepairManagementSystem.Service;
using System;

namespace HomeApplianceRepairManagementSystem
{
    class Program
    {
        static void Main()
        {

            Console.WriteLine("....Welcom To HOME APPLIANCE REPAIR MANAGEMENT SYSTEM...");


            bool exit = false;
            while (!exit)
            {
                DisplayMainMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ManageCustomers();
                        break;
                    case "2":
                        ManageTechnicians();
                        break;
                    case "3":
                        ManageRepairOrders();
                        break;
                    case "4":
                        ViewReports();
                        break;
                    case "5":
                        exit = true;
                        Console.WriteLine("\n✓ Thank you for using the system. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("\n✗ Invalid option. Please try again.");
                        break;
                }
            }
        }


        static void DisplayMainMenu()
        {
            Console.WriteLine("\n               MAIN MENU                     ");
            Console.WriteLine(" 1. Manage Customers                           ");
            Console.WriteLine(" 2. Manage Technicians                         ");
            Console.WriteLine(" 3. Manage Repair Orders                       ");
            Console.WriteLine(" 4. Reports                                    ");
            Console.WriteLine(" 5. Exit                                       ");
            Console.WriteLine("                                               ");
            Console.Write("\n   Select an option:   ");
        }

        #region Customer Management
        static void ManageCustomers()
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n          CUSTOMER MANAGEMENT         ");
                Console.WriteLine(" 1. Add New Customer                    ");
                Console.WriteLine(" 2. View All Customers                  ");
                Console.WriteLine(" 3. Edit Customer                       ");
                Console.WriteLine(" 4. Delete Customer                     ");
                Console.WriteLine(" 5. Back to Main Menu                   ");
                Console.Write("\n Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddCustomer();
                        break;
                    case "2":
                        ViewAllCustomers();
                        break;
                    case "3":
                        EditCustomer();
                        break;
                    case "4":
                        DeleteCustomer();
                        break;
                    case "5":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("\n✗ Invalid option.");
                        break;
                }
            }
        }

        static void AddCustomer()
        {
            Console.WriteLine("\n── Add New Customer ──");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Phone: ");
            string phone = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();

            CustomerService.AddCustomer(name, phone, address);
            Console.WriteLine("\n✓ Customer added successfully!");
        }

        static void ViewAllCustomers()
        {
            var customers = _CustomerService.GetAllCustomers();
            Console.WriteLine("\n── All Customers ──");
            Console.WriteLine("ID\tName\t\t\tPhone\t\tAddress");
            Console.WriteLine("─────────────────────────────────────────────────────────");
            foreach (var c in customers)
            {
                Console.WriteLine($"{c.CustomerId}\t{c.Name,-20}\t{c.Phone}\t{c.Address}");
            }
        }

        static void EditCustomer()
        {
            Console.Write("\nEnter Customer ID to edit: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var customer = _CustomerService.GetCustomerById(id);
                if (customer != null)
                {
                    Console.WriteLine($"\nEditing: {customer.Name}");
                    Console.Write("New Name (leave blank to keep current): ");
                    string name = Console.ReadLine();
                    Console.Write("New Phone (leave blank to keep current): ");
                    string phone = Console.ReadLine();
                    Console.Write("New Address (leave blank to keep current): ");
                    string address = Console.ReadLine();

                    _CustomerService.UpdateCustomer(id,
                        string.IsNullOrWhiteSpace(name) ? customer.Name : name,
                        string.IsNullOrWhiteSpace(phone) ? customer.Phone : phone,
                        string.IsNullOrWhiteSpace(address) ? customer.Address : address);

                    Console.WriteLine("\n✓ Customer updated successfully!");
                }
                else
                {
                    Console.WriteLine("\n✗ Customer not found.");
                }
            }
        }

        static void DeleteCustomer()
        {
            Console.Write("\nEnter Customer ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (
                    _CustomerService.DeleteCustomer(id))
                    Console.WriteLine("\n✓ Customer deleted successfully!");
                else
                    Console.WriteLine("\n✗ Cannot delete customer.");
            }
        }
        #endregion

        #region Technician Management
        static void ManageTechnicians()
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n        TECHNICIAN MANAGEMENT         ");
                Console.WriteLine(" 1. Add New Technician                   ");
                Console.WriteLine(" 2. View All Technicians                 ");
                Console.WriteLine(" 3. Edit Technician                      ");
                Console.WriteLine(" 4. Delete Technician                    ");
                Console.WriteLine(" 5. Back to Main Menu                    ");
                Console.WriteLine("                                         ");
                Console.Write("\nSelect an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTechnician();
                        break;
                    case "2":
                        ViewAllTechnicians();
                        break;
                    case "3":
                        EditTechnician();
                        break;
                    case "4":
                        DeleteTechnician();
                        break;
                    case "5":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("\n✗ Invalid option.");
                        break;
                }
            }
        }

        static void AddTechnician()
        {
            Console.WriteLine("\n── Add New Technician ──");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Phone: ");
            string phone = Console.ReadLine();
            Console.Write("Specialty (e.g., Refrigerator, AC, Washing Machine): ");
            string specialty = Console.ReadLine();

            _TechnicianService.AddTechnician(name, phone, specialty);
            Console.WriteLine("\n✓ Technician added successfully!");
        }

        static void ViewAllTechnicians()
        {
            var technicians = _TechnicianService.GetAllTechnicians();
            Console.WriteLine("\n── All Technicians ──");
            Console.WriteLine("ID\tName\t\t\tPhone\t\tSpecialty");
            Console.WriteLine("─────────────────────────────────────────────────────────");
            foreach (var t in technicians)
            {
                Console.WriteLine($"{t.TechnicianId}\t{t.Name,-20}\t{t.Phone}\t{t.Specialty}");
            }
        }

        static void EditTechnician()
        {
            Console.Write("\nEnter Technician ID to edit: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var tech = _TechnicianService.GetTechnicianById(id);
                if (tech != null)
                {
                    Console.WriteLine($"\nEditing: {tech.Name}");
                    Console.Write("New Name: ");
                    string name = Console.ReadLine();
                    Console.Write("New Phone: ");
                    string phone = Console.ReadLine();
                    Console.Write("New Specialty: ");
                    string specialty = Console.ReadLine();

                    _technicianService.UpdateTechnician(id,
                        string.IsNullOrWhiteSpace(name) ? tech.Name : name,
                        string.IsNullOrWhiteSpace(phone) ? tech.Phone : phone,
                        string.IsNullOrWhiteSpace(specialty) ? tech.Specialty : specialty);

                    Console.WriteLine("\n✓ Technician updated successfully!");
                }
                else
                {
                    Console.WriteLine("\n✗ Technician not found.");
                }
            }
        }

        static void DeleteTechnician()
        {
            Console.Write("\nEnter Technician ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (_TechnicianService.DeleteTechnician(id))
                    Console.WriteLine("\n✓ Technician deleted successfully!");
            }
        }
        #endregion

        #region Repair Order Management
        static void ManageRepairOrders()
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n         REPAIR ORDER MANAGEMENT         ");
                Console.WriteLine(" 1. Add New Order                          ");
                Console.WriteLine(" 2. Assign Technician                      ");
                Console.WriteLine(" 3. Change Status                          ");
                Console.WriteLine(" 4. Complete Order (Enter Costs)           ");
                Console.WriteLine(" 5. Cancel Order                           ");
                Console.WriteLine(" 6. View All Orders                        ");
                Console.WriteLine(" 7. Back to Main Menu                      ");

                Console.Write("\nSelect an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddRepairOrder();
                        break;
                    case "2":
                        AssignTechnician();
                        break;
                    case "3":
                        ChangeOrderStatus();
                        break;
                    case "4":
                        CompleteOrder();
                        break;
                    case "5":
                        CancelOrder();
                        break;
                    case "6":
                        ViewAllOrders();
                        break;
                    case "7":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("\n✗ Invalid option.");
                        break;
                }
            }
        }


    }
}