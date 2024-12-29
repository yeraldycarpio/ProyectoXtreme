using ConstructoraExtreme.Models.EN;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace ConstructoraExtreme.Models.DAL
{
    public class UserDAL
    {
        private readonly XtremeContext _context;

        // Constructor que recibe un objeto CRMContext para interactuar con la base de datos.
        public UserDAL(XtremeContext XtremeContext)
        {
            _context = XtremeContext;
        }

        // Método para crear un nuevo usuario en la base de datos.
        public async Task<int> Create(User user)
        {
            _context.Add(user);
            return await _context.SaveChangesAsync();
        }

        // Método para obtener un usuario por su ID.
        public async Task<User> GetById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user ?? new User();
        }

        // Método para editar un usuario existente en la base de datos.
        public async Task<int> Edit(User user)
        {
            int result = 0;
            var userUpdate = await GetById(user.Id);
            if (userUpdate.Id != 0)
            {
                // Actualiza los datos del usuario.
                userUpdate.Name = user.Name;
                userUpdate.Email = user.Email;
                userUpdate.Password = user.Password;

                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        // Método para eliminar un usuario de la base de datos por su ID.
        public async Task<int> Delete(int id)
        {
            int result = 0;
            var userDelete = await GetById(id);
            if (userDelete.Id > 0)
            {
                // Elimina el usuario de la base de datos.
                _context.Users.Remove(userDelete);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        // Método privado para construir una consulta IQueryable para buscar usuarios con filtros.
        private IQueryable<User> Query(User user)
        {
            var query = _context.Users.AsQueryable();
            if (!string.IsNullOrWhiteSpace(user.Name))
                query = query.Where(u => u.Name.Contains(user.Name));
            if (!string.IsNullOrWhiteSpace(user.Email))
                query = query.Where(u => u.Email.Contains(user.Email));

            return query;
        }

        // Método para contar la cantidad de resultados de búsqueda con filtros.
        public async Task<int> CountSearch(User user)
        {
            return await Query(user).CountAsync();
        }

        // Método para buscar usuarios con filtros, paginación y ordenamiento.
        public async Task<List<User>> Search(User user, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = Query(user);
            query = query.OrderByDescending(u => u.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
    }

}
