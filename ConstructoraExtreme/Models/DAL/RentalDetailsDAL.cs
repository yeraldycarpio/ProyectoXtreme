using ConstructoraExtreme.Models.EN;
using Microsoft.EntityFrameworkCore;

namespace ConstructoraExtreme.Models.DAL
{
        public class RentalDetailsDAL
        {
            private readonly XtremeContext _context;

            // Constructor que recibe un objeto XtremeContext para interactuar con la base de datos.
            public RentalDetailsDAL(XtremeContext xtremeContext)
            {
                _context = xtremeContext;
            }

            // Método para crear un nuevo detalle de alquiler en la base de datos.
            public async Task<int> Create(RentalDetails rentalDetail)
            {
                _context.RentalDetails.Add(rentalDetail);
                return await _context.SaveChangesAsync();
            }

            // Método para obtener un detalle de alquiler por su ID.
            public async Task<RentalDetails> GetById(int id)
            {
                var rentalDetail = await _context.RentalDetails
                    .Include(rd => rd.Rentals)  // Incluir el alquiler relacionado
                    .Include(rd => rd.Products) // Incluir el producto relacionado
                    .FirstOrDefaultAsync(rd => rd.Id == id);

                return rentalDetail ?? new RentalDetails();
            }

            // Método para editar un detalle de alquiler existente en la base de datos.
            public async Task<int> Edit(RentalDetails rentalDetail)
            {
                int result = 0;
                var rentalDetailUpdate = await GetById(rentalDetail.Id);
                if (rentalDetailUpdate.Id != 0)
                {
                    // Actualiza los datos del detalle de alquiler.
                    rentalDetailUpdate.Rental_Id = rentalDetail.Rental_Id;
                    rentalDetailUpdate.Product_Id = rentalDetail.Product_Id;
                    rentalDetailUpdate.Quantity = rentalDetail.Quantity;
                    rentalDetailUpdate.Daily_Price = rentalDetail.Daily_Price;
                    rentalDetailUpdate.Rental_Days = rentalDetail.Rental_Days;
                    rentalDetailUpdate.Subtotal = rentalDetail.Subtotal;
                    rentalDetailUpdate.Created_At = rentalDetail.Created_At;

                    result = await _context.SaveChangesAsync();
                }
                return result;
            }

            // Método para eliminar un detalle de alquiler de la base de datos por su ID.
            public async Task<int> Delete(int id)
            {
                int result = 0;
                var rentalDetailDelete = await GetById(id);
                if (rentalDetailDelete.Id != 0)
                {
                    // Elimina el detalle de alquiler de la base de datos.
                    _context.RentalDetails.Remove(rentalDetailDelete);
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }

            // Método privado para construir una consulta IQueryable con filtros.
            private IQueryable<RentalDetails> Query(RentalDetails rentalDetail)
            {
                var query = _context.RentalDetails.AsQueryable();

                if (rentalDetail.Rental_Id > 0)
                    query = query.Where(rd => rd.Rental_Id == rentalDetail.Rental_Id);

                if (rentalDetail.Product_Id > 0)
                    query = query.Where(rd => rd.Product_Id == rentalDetail.Product_Id);

                if (rentalDetail.Quantity > 0)
                    query = query.Where(rd => rd.Quantity == rentalDetail.Quantity);

                if (rentalDetail.Daily_Price > 0)
                    query = query.Where(rd => rd.Daily_Price == rentalDetail.Daily_Price);

                if (rentalDetail.Rental_Days > 0)
                    query = query.Where(rd => rd.Rental_Days == rentalDetail.Rental_Days);

                if (rentalDetail.Subtotal > 0)
                    query = query.Where(rd => rd.Subtotal == rentalDetail.Subtotal);

                return query;
            }

            // Método para contar el número de detalles de alquiler que cumplen con los filtros.
            public async Task<int> CountSearch(RentalDetails rentalDetail)
            {
                return await Query(rentalDetail).CountAsync();
            }

            // Método para buscar detalles de alquiler con filtros, paginación y ordenamiento.
            public async Task<List<RentalDetails>> Search(RentalDetails rentalDetail, int take = 10, int skip = 0)
            {
                take = take == 0 ? 10 : take;
                var query = Query(rentalDetail);
                query = query.OrderByDescending(rd => rd.Id).Skip(skip).Take(take);
                return await query.ToListAsync();
            }
        }

    }

