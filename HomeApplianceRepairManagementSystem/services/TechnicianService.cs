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
    public class TechnicianService
    {
        private readonly AppDbContext _context;
        public TechnicianService(AppDbContext context)
        {
            _context = context;
        }
        public void AddTechnician(string name, string phone, string specialty)
        {
            var technician = new Technician { Name = name, Phone = phone, Specialty = specialty };
            _context.Technicians.Add(technician);
            _context.SaveChanges();
        }
        public void EditTechnician(int id, string name, string phone, string specialty)
        {
            var technician = _context.Technicians.Find(id);
            if (technician != null)
            {
                technician.Name = name;
                technician.Phone = phone;
                technician.Specialty = specialty;
                _context.SaveChanges();
            }
        }
        public void DeleteTechnician(int id)
        {
            var technician = _context.Technicians.Include(t => t.RepairOrders).FirstOrDefault(t => t.Id == id);

        }

        internal void ListTechnicians()
        {
            throw new NotImplementedException();
        }
    }
}
