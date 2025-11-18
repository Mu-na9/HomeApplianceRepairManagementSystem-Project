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
      public class TechnicianService
    {
        private readonly AppDbContext _context;

        public TechnicianService(AppDbContext context)
        {
            _context = context;
        }

        public void AddTechnician(string name, string phone, string specialty)
        {
            var technician = new Technician
            {
                TName = name,
                Phone = phone,
                Specialty = specialty
            };
            _context.Technicians.Add(technician);
            _context.SaveChanges();
        }

        public void UpdateTechnician(int id, string name, string phone, string specialty)
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

        public bool DeleteTechnician(int id)
        {
            var technician = _context.Technicians.Include(t => t.RepairOrders).FirstOrDefault(t => t.TechnicianId == id);
            if (technician == null) return false;

            if (technician.RepairOrders.Any())
            {
                Console.WriteLine("Cannot delete technician with assigned orders.");
                return false;
            }

            _context.Technicians.Remove(technician);
            _context.SaveChanges();
            return true;
        }

        public List<Technician> GetAllTechnicians()
        {
            return _context.Technicians.ToList();
        }

        public Technician GetTechnicianById(int id)
        {
            return _context.Technicians.Find(id);
        }
    }
}

