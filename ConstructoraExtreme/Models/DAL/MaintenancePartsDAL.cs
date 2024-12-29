using ConstructoraExtreme.Models.EN;
using Microsoft.EntityFrameworkCore;

namespace ConstructoraExtreme.Models.DAL
{
    public class MaintenancePartsDal
    {
        private readonly XtremeContext _context;

        public MaintenancePartsDal(XtremeContext xtremeContext)
        {
            _context = xtremeContext;
        }

        // Obtener todas las partes de mantenimiento
        public List<MaintenanceParts> GetAll()
        {
            return _context.MaintenanceParts
                .Include(mp => mp.MaintenanceRecords)
                .ToList();
        }

        // Obtener una parte de mantenimiento por Id
        public MaintenanceParts GetById(int id)
        {
            return _context.MaintenanceParts
                .Include(mp => mp.MaintenanceRecords)
                .FirstOrDefault(mp => mp.Id == id);
        }

        // Crear una nueva parte de mantenimiento
        public void Add(MaintenanceParts maintenancePart)
        {
            _context.MaintenanceParts.Add(maintenancePart);
            _context.SaveChanges();
        }

        // Actualizar una parte de mantenimiento
        public void Update(MaintenanceParts maintenancePart)
        {
            _context.MaintenanceParts.Update(maintenancePart);
            _context.SaveChanges();
        }

        // Eliminar una parte de mantenimiento por Id
        public void Delete(int id)
        {
            var maintenancePart = _context.MaintenanceParts
                .FirstOrDefault(mp => mp.Id == id);
            if (maintenancePart != null)
            {
                _context.MaintenanceParts.Remove(maintenancePart);
                _context.SaveChanges();
            }
        }
    }

}
