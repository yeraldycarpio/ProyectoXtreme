using ConstructoraExtreme.Models.EN;
using Microsoft.EntityFrameworkCore;

namespace ConstructoraExtreme.Models.DAL
{
        public class RentalPaymentsDAL
        {
            private readonly XtremeContext _context;

            // Constructor que recibe un objeto XtremeContext para interactuar con la base de datos.
            public RentalPaymentsDAL(XtremeContext xtremeContext)
            {
                _context = xtremeContext;
            }

            // Método para crear un nuevo pago de alquiler en la base de datos.
            public async Task<int> Create(RentalPayments rentalPayment)
            {
                _context.RentalPayments.Add(rentalPayment);
                return await _context.SaveChangesAsync();
            }

            // Método para obtener un pago de alquiler por su ID.
            public async Task<RentalPayments> GetById(int id)
            {
                var rentalPayment = await _context.RentalPayments
                    .Include(rp => rp.Rentals)  // Incluir el alquiler relacionado
                    .FirstOrDefaultAsync(rp => rp.Id == id);

                return rentalPayment ?? new RentalPayments();
            }

            // Método para editar un pago de alquiler existente en la base de datos.
            public async Task<int> Edit(RentalPayments rentalPayment)
            {
                int result = 0;
                var rentalPaymentUpdate = await GetById(rentalPayment.Id);
                if (rentalPaymentUpdate.Id != 0)
                {
                    // Actualiza los datos del pago de alquiler.
                    rentalPaymentUpdate.Rental_Id = rentalPayment.Rental_Id;
                    rentalPaymentUpdate.Total_Amount = rentalPayment.Total_Amount;
                    rentalPaymentUpdate.Pending_Amount = rentalPayment.Pending_Amount;
                    rentalPaymentUpdate.Advance_Payment = rentalPayment.Advance_Payment;
                    rentalPaymentUpdate.Payment_Status = rentalPayment.Payment_Status;
                    rentalPaymentUpdate.Due_Date = rentalPayment.Due_Date;
                    rentalPaymentUpdate.Created_At = rentalPayment.Created_At;
                    rentalPaymentUpdate.Update_At = rentalPayment.Update_At;

                    result = await _context.SaveChangesAsync();
                }
                return result;
            }

            // Método para eliminar un pago de alquiler de la base de datos por su ID.
            public async Task<int> Delete(int id)
            {
                int result = 0;
                var rentalPaymentDelete = await GetById(id);
                if (rentalPaymentDelete.Id != 0)
                {
                    // Elimina el pago de alquiler de la base de datos.
                    _context.RentalPayments.Remove(rentalPaymentDelete);
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }

            // Método privado para construir una consulta IQueryable con filtros.
            private IQueryable<RentalPayments> Query(RentalPayments rentalPayment)
            {
                var query = _context.RentalPayments.AsQueryable();

                if (rentalPayment.Rental_Id > 0)
                    query = query.Where(rp => rp.Rental_Id == rentalPayment.Rental_Id);

                if (rentalPayment.Total_Amount > 0)
                    query = query.Where(rp => rp.Total_Amount == rentalPayment.Total_Amount);

                if (rentalPayment.Pending_Amount > 0)
                    query = query.Where(rp => rp.Pending_Amount == rentalPayment.Pending_Amount);

                if (rentalPayment.Advance_Payment > 0)
                    query = query.Where(rp => rp.Advance_Payment == rentalPayment.Advance_Payment);

                if (!string.IsNullOrWhiteSpace(rentalPayment.Payment_Status))
                    query = query.Where(rp => rp.Payment_Status.Contains(rentalPayment.Payment_Status));

                if (rentalPayment.Due_Date != DateTime.MinValue)
                    query = query.Where(rp => rp.Due_Date == rentalPayment.Due_Date);

                return query;
            }

            // Método para contar el número de pagos de alquiler que cumplen con los filtros.
            public async Task<int> CountSearch(RentalPayments rentalPayment)
            {
                return await Query(rentalPayment).CountAsync();
            }

            // Método para buscar pagos de alquiler con filtros, paginación y ordenamiento.
            public async Task<List<RentalPayments>> Search(RentalPayments rentalPayment, int take = 10, int skip = 0)
            {
                take = take == 0 ? 10 : take;
                var query = Query(rentalPayment);
                query = query.OrderByDescending(rp => rp.Id).Skip(skip).Take(take);
                return await query.ToListAsync();
            }
        }

    }
