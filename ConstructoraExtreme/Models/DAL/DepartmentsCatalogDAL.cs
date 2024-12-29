using ConstructoraExtreme.Models.EN;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace ConstructoraExtreme.Models.DAL
{
    public class DepartmentsCatalogDAL
    {
        private readonly XtremeContext _context;

        // Constructor que recibe un objeto CRMContext para interactuar con la base de datos.
        public DepartmentsCatalogDAL(XtremeContext xtremeContext)
        {
            _context = xtremeContext;
        }

        // Método para crear un nuevo departamento en la base de datos.
        public async Task<int> Create(DepartmentsCatalog department)
        {
            _context.Add(department);
            return await _context.SaveChangesAsync();
        }

        // Método para obtener un departamento por su ID.
        public async Task<DepartmentsCatalog> GetById(int id)
        {
            var department = await _context.DepartmentsCatalogs.FirstOrDefaultAsync(d => d.Id == id);
            return department ?? new DepartmentsCatalog();
        }

        // Método para editar un departamento existente en la base de datos.
        public async Task<int> Edit(DepartmentsCatalog department)
        {
            int result = 0;
            var departmentUpdate = await GetById(department.Id);
            if (departmentUpdate.Id != 0)
            {
                // Actualiza los datos del departamento.
                departmentUpdate.Code = department.Code;
                departmentUpdate.Name = department.Name;

                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        // Método para eliminar un departamento de la base de datos por su ID.
        public async Task<int> Delete(int id)
        {
            int result = 0;
            var departmentDelete = await GetById(id);
            if (departmentDelete.Id > 0)
            {
                // Elimina el departamento de la base de datos.
                _context.DepartmentsCatalogs.Remove(departmentDelete);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        // Método privado para construir una consulta IQueryable para buscar departamentos con filtros.
        private IQueryable<DepartmentsCatalog> Query(DepartmentsCatalog department)
        {
            var query = _context.DepartmentsCatalogs.AsQueryable();
            if (!string.IsNullOrWhiteSpace(department.Code))
                query = query.Where(d => d.Code.Contains(department.Code));
            if (!string.IsNullOrWhiteSpace(department.Name))
                query = query.Where(d => d.Name.Contains(department.Name));

            return query;
        }

        // Método para contar la cantidad de resultados de búsqueda con filtros.
        public async Task<int> CountSearch(DepartmentsCatalog department)
        {
            return await Query(department).CountAsync();
        }

        // Método para buscar departamentos con filtros, paginación y ordenamiento.
        public async Task<List<DepartmentsCatalog>> Search(DepartmentsCatalog department, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = Query(department);
            query = query.OrderByDescending(d => d.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
    }

}
