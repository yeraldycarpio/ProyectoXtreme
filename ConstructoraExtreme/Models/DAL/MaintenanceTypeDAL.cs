using ConstructoraExtreme.Models.EN;

namespace ConstructoraExtreme.Models.DAL
{
    public class MaintenanceTypesDal
    {
        private readonly XtremeContext _context;

        public MaintenanceTypesDal(XtremeContext xtremeContext)
        {
            _context = xtremeContext;
        }

        // Obtener todos los tipos de mantenimiento
        public List<MaintenanceTypes> GetAll()
        {
            return _context.MaintenanceTypes.ToList();
        }

        // Obtener un tipo de mantenimiento por Id
        public MaintenanceTypes GetById(int id)
        {
            return _context.MaintenanceTypes.FirstOrDefault(m => m.Id == id);
        }

        // Crear un nuevo tipo de mantenimiento
        public void Add(MaintenanceTypes maintenanceType)
        {
            _context.MaintenanceTypes.Add(maintenanceType);
            _context.SaveChanges();
        }

        // Actualizar un tipo de mantenimiento
        public void Update(MaintenanceTypes maintenanceType)
        {
            _context.MaintenanceTypes.Update(maintenanceType);
            _context.SaveChanges();
        }

        // Eliminar un tipo de mantenimiento por Id
        public void Delete(int id)
        {
            var maintenanceType = _context.MaintenanceTypes.FirstOrDefault(m => m.Id == id);
            if (maintenanceType != null)
            {
                _context.MaintenanceTypes.Remove(maintenanceType);
                _context.SaveChanges();
            }
        }
    }

}
