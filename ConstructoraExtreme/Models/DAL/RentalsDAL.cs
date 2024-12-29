using ConstructoraExtreme.Models.EN;
using Microsoft.EntityFrameworkCore;

namespace ConstructoraExtreme.Models.DAL
{
    public class RentalsDAL
    {
        private readonly XtremeContext _context;

        // Constructor que recibe un objeto XtremeContext para interactuar con la base de datos.
        public RentalsDAL(XtremeContext xtremeContext)
        {
            _context = xtremeContext;
        }

        // Método para crear un nuevo alquiler en la base de datos.
        public async Task<int> Create(Rentals rental)
        {
            _context.Rentals.Add(rental);
            return await _context.SaveChangesAsync();
        }

        // Método para obtener un alquiler por su ID.
        public async Task<Rentals> GetById(int id)
        {
            var rental = await _context.Rentals
                .Include(r => r.Store)  // Incluir la tienda relacionada
                .Include(r => r.Persons) // Incluir la persona relacionada
                .FirstOrDefaultAsync(r => r.Id == id);

            return rental ?? new Rentals();
        }

        // Método para editar un alquiler existente en la base de datos.
        public async Task<int> Edit(Rentals rental)
        {
            int result = 0;
            var rentalUpdate = await GetById(rental.Id);
            if (rentalUpdate.Id != 0)
            {
                // Actualiza los datos del alquiler.
                rentalUpdate.Store_Id = rental.Store_Id;
                rentalUpdate.Person_Id = rental.Person_Id;
                rentalUpdate.Total_Amount = rental.Total_Amount;
                rentalUpdate.Start_Date = rental.Start_Date;
                rentalUpdate.End_Date = rental.End_Date;
                rentalUpdate.Status = rental.Status;
                rentalUpdate.Updated_At = rental.Updated_At;

                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        // Método para eliminar un alquiler de la base de datos por su ID.
        public async Task<int> Delete(int id)
        {
            int result = 0;
            var rentalDelete = await GetById(id);
            if (rentalDelete.Id != 0)
            {
                // Elimina el alquiler de la base de datos.
                _context.Rentals.Remove(rentalDelete);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        // Método privado para construir una consulta IQueryable con filtros.
        private IQueryable<Rentals> Query(Rentals rental)
        {
            var query = _context.Rentals.AsQueryable();

            if (rental.Store_Id > 0)
                query = query.Where(r => r.Store_Id == rental.Store_Id);

            if (rental.Person_Id > 0)
                query = query.Where(r => r.Person_Id == rental.Person_Id);

            if (rental.Start_Date != DateTime.MinValue)
                query = query.Where(r => r.Start_Date >= rental.Start_Date);

            if (rental.End_Date != DateTime.MinValue)
                query = query.Where(r => r.End_Date <= rental.End_Date);

            if (!string.IsNullOrWhiteSpace(rental.Status))
                query = query.Where(r => r.Status.Contains(rental.Status));

            return query;
        }

        // Método para contar el número de alquileres que cumplen con los filtros.
        public async Task<int> CountSearch(Rentals rental)
        {
            return await Query(rental).CountAsync();
        }

        // Método para buscar alquileres con filtros, paginación y ordenamiento.
        public async Task<List<Rentals>> Search(Rentals rental, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = Query(rental);
            query = query.OrderByDescending(r => r.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
    }
}
