using ConstructoraExtreme.Models.EN;
using Microsoft.EntityFrameworkCore;

namespace ConstructoraExtreme.Models.DAL
{
    public class MaintenanceRecordsDal
    {
        private readonly XtremeContext _context;

        public MaintenanceRecordsDal(XtremeContext xtremeContext)
        {
            _context = xtremeContext;
        }

        // Obtener todos los registros de mantenimiento
        public List<MaintenanceRecords> GetAll()
        {
            return _context.MaintenanceRecords
                .Include(mr => mr.Products)
                .Include(mr => mr.MaintenanceTypes)
                .Include(mr => mr.Store)
                .ToList();
        }

        // Obtener un registro de mantenimiento por Id
        public MaintenanceRecords GetById(int id)
        {
            return _context.MaintenanceRecords
                .Include(mr => mr.Products)
                .Include(mr => mr.MaintenanceTypes)
                .Include(mr => mr.Store)
                .FirstOrDefault(mr => mr.Id == id);
        }

        // Crear un nuevo registro de mantenimiento
        public void Add(MaintenanceRecords maintenanceRecord)
        {
            _context.MaintenanceRecords.Add(maintenanceRecord);
            _context.SaveChanges();
        }

        // Actualizar un registro de mantenimiento
        public void Update(MaintenanceRecords maintenanceRecord)
        {
            _context.MaintenanceRecords.Update(maintenanceRecord);
            _context.SaveChanges();
        }

        // Eliminar un registro de mantenimiento por Id
        public void Delete(int id)
        {
            var maintenanceRecord = _context.MaintenanceRecords
                .FirstOrDefault(mr => mr.Id == id);
            if (maintenanceRecord != null)
            {
                _context.MaintenanceRecords.Remove(maintenanceRecord);
                _context.SaveChanges();
            }
        }
    }
}

