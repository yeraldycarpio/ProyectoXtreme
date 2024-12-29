using ConstructoraExtreme.Models.EN;
using Microsoft.EntityFrameworkCore;

namespace ConstructoraExtreme.Models.DAL
{
    public class MaintenanceTasksDal
    {
        private readonly XtremeContext _context;

        public MaintenanceTasksDal(XtremeContext xtremeContext)
        {
            _context = xtremeContext;
        }

        // Obtener todas las tareas de mantenimiento
        public List<MaintenanceTasks> GetAll()
        {
            return _context.MaintenanceTasks
                .Include(mt => mt.MaintenanceRecords)
                .ToList();
        }

        // Obtener una tarea de mantenimiento por Id
        public MaintenanceTasks GetById(int id)
        {
            return _context.MaintenanceTasks
                .Include(mt => mt.MaintenanceRecords)
                .FirstOrDefault(mt => mt.Id == id);
        }

        // Crear una nueva tarea de mantenimiento
        public void Add(MaintenanceTasks maintenanceTask)
        {
            _context.MaintenanceTasks.Add(maintenanceTask);
            _context.SaveChanges();
        }

        // Actualizar una tarea de mantenimiento
        public void Update(MaintenanceTasks maintenanceTask)
        {
            _context.MaintenanceTasks.Update(maintenanceTask);
            _context.SaveChanges();
        }

        // Eliminar una tarea de mantenimiento por Id
        public void Delete(int id)
        {
            var maintenanceTask = _context.MaintenanceTasks
                .FirstOrDefault(mt => mt.Id == id);
            if (maintenanceTask != null)
            {
                _context.MaintenanceTasks.Remove(maintenanceTask);
                _context.SaveChanges();
            }
        }
    }

}
