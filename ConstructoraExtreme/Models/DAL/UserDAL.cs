using ConstructoraExtreme.Models.EN;
using CRM.DTOs.UsersDTOs;
using Extreme.DTOs.UserDTOs;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

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

        // Crear usuario con contraseña encriptada
        public async Task CreateUserAsync(User user, string password)
        {
            user.Password = HashPassword(password);
            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();
        }

        // Listar usuarios con búsqueda y paginación
        public async Task<SearchResultUserDTO> GetUsersAsync(SearchQueryUserDTO query)
        {
            var usersQuery = _context.Users.Include(u => u.Role).AsQueryable();

            if (!string.IsNullOrEmpty(query.Name_Like))
            {
                usersQuery = usersQuery.Where(u => u.Name.Contains(query.Name_Like));
            }
            if (!string.IsNullOrEmpty(query.Email_Like))
            {
                usersQuery = usersQuery.Where(u => u.Email.Contains(query.Email_Like));
            }
            query.Skip = Math.Max(0, query.Skip);
            query.Take = Math.Max(1, query.Take); // Evitar `Take` con valor 0


            var totalCount = query.SendRowCount == 2 ? await usersQuery.CountAsync() : 0;

            var users = await usersQuery
                .OrderBy(u => u.Id) // Add some default sorting
                .Skip(query.Skip)
                .Take(query.Take)
                .Select(u => new SearchResultUserDTO.UserDTO
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email
                })
                .ToListAsync();

            return new SearchResultUserDTO { CountRow = totalCount, Data = users };
        }


        // Obtener usuario por email
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .Include(u => u.Role)  // This ensures the Role is loaded
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        // Obtener usuario por ID
        public async Task<GetIdResultUserDTO?> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Role)
                .Where(u => u.Id == id)
                .Select(u => new GetIdResultUserDTO
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    Password = u.Password,
                    RoleId = (int)u.RoleId
                })
                .FirstOrDefaultAsync();
        }
        // Actualizar usuario
        public async Task<bool> UpdateUserAsync(int id, EditUserDTO dto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            user.Name = dto.Name;
            user.Email = dto.Email;

            //if (!string.IsNullOrEmpty(dto.Password))
            //{
            //    user.Password = HashPassword(dto.Password);
            //}

            await _context.SaveChangesAsync();
            return true;
        }

        // Eliminar usuario
        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
        // Método para encriptar contraseñas
        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            
        }
        public async Task<User?> ValidateCredentialsAsync(string email, string password)
        {
            var user = await GetUserByEmailAsync(email);

            if (user != null && VerifyPassword(user.Password, password))
            {
                return user;
            }

            return null;
        }
        // Verificar la contraseña encriptada
        private bool VerifyPassword(string? hashedPassword, string? plainPassword)
        {
            if (string.IsNullOrEmpty(hashedPassword) || string.IsNullOrEmpty(plainPassword))
                return false;

            return hashedPassword == HashPassword(plainPassword);
        }


    }

}
