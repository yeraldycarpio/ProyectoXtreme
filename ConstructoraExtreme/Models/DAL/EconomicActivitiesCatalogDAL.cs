using ConstructoraExtreme.Models.EN;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace ConstructoraExtreme.Models.DAL
{
    public class EconomicActivitiesCatalogDAL
    {
        private readonly XtremeContext _context;

        // Constructor que recibe un objeto CRMContext para interactuar con la base de datos.
        public EconomicActivitiesCatalogDAL(XtremeContext xtremeContext)
        {
            _context = xtremeContext;
        }

        // Método para crear una nueva actividad económica.
        public async Task<int> Create(EconomicActivitiesCatalog activity)
        {
            _context.EconomicActivitiesCatalogs.Add(activity);
            return await _context.SaveChangesAsync();
        }

        // Método para obtener una actividad económica por su ID.
        public async Task<EconomicActivitiesCatalog> GetById(int id)
        {
            var activity = await _context.EconomicActivitiesCatalogs.FirstOrDefaultAsync(a => a.Id == id);
            return activity ?? new EconomicActivitiesCatalog();
        }

        // Método para editar una actividad económica existente.
        public async Task<int> Edit(EconomicActivitiesCatalog activity)
        {
            int result = 0;
            var existingActivity = await GetById(activity.Id);
            if (existingActivity.Id != 0)
            {
                existingActivity.Code = activity.Code;
                existingActivity.Description = activity.Description;
                existingActivity.Active = activity.Active;

                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        // Método para eliminar una actividad económica por su ID.
        public async Task<int> Delete(int id)
        {
            int result = 0;
            var activityToDelete = await GetById(id);
            if (activityToDelete.Id != 0)
            {
                _context.EconomicActivitiesCatalogs.Remove(activityToDelete);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        // Método privado para construir una consulta IQueryable con filtros.
        private IQueryable<EconomicActivitiesCatalog> Query(EconomicActivitiesCatalog filter)
        {
            var query = _context.EconomicActivitiesCatalogs.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Code))
                query = query.Where(a => a.Code.Contains(filter.Code));

            if (!string.IsNullOrWhiteSpace(filter.Description))
                query = query.Where(a => a.Description.Contains(filter.Description));

            if (filter.Active != null)
                query = query.Where(a => a.Active == filter.Active);

            return query;
        }

        // Método para contar el número de registros con filtros.
        public async Task<int> CountSearch(EconomicActivitiesCatalog filter)
        {
            return await Query(filter).CountAsync();
        }

        // Método para buscar actividades económicas con filtros, paginación y ordenamiento.
        public async Task<List<EconomicActivitiesCatalog>> Search(EconomicActivitiesCatalog filter, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = Query(filter);
            query = query.OrderByDescending(a => a.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
    }

}
