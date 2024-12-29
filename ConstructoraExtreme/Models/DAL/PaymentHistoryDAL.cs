using ConstructoraExtreme.Models.EN;
using Microsoft.EntityFrameworkCore;

namespace ConstructoraExtreme.Models.DAL
{
    public class PaymentHistoryDAL
    {
        private readonly XtremeContext _context;

        // Constructor que recibe un objeto XtremeContext para interactuar con la base de datos.
        public PaymentHistoryDAL(XtremeContext xtremeContext)
        {
            _context = xtremeContext;
        }

        // Método para crear un nuevo historial de pago en la base de datos.
        public async Task<int> Create(PaymentHistory paymentHistory)
        {
            _context.paymentHistories.Add(paymentHistory);
            return await _context.SaveChangesAsync();
        }

        // Método para obtener un historial de pago por su ID.
        public async Task<PaymentHistory> GetById(int id)
        {
            var paymentHistory = await _context.paymentHistories
                .Include(ph => ph.RentalPayments)  // Incluir el pago de alquiler relacionado
                .FirstOrDefaultAsync(ph => ph.Id == id);

            return paymentHistory ?? new PaymentHistory();
        }

        // Método para editar un historial de pago existente en la base de datos.
        public async Task<int> Edit(PaymentHistory paymentHistory)
        {
            int result = 0;
            var paymentHistoryUpdate = await GetById(paymentHistory.Id);
            if (paymentHistoryUpdate.Id != 0)
            {
                // Actualiza los datos del historial de pago.
                paymentHistoryUpdate.Rental_Payment_Id = paymentHistory.Rental_Payment_Id;
                paymentHistoryUpdate.Amount = paymentHistory.Amount;
                paymentHistoryUpdate.Payment_Type = paymentHistory.Payment_Type;
                paymentHistoryUpdate.Payment_Method = paymentHistory.Payment_Method;
                paymentHistoryUpdate.Payment_Date = paymentHistory.Payment_Date;
                paymentHistoryUpdate.Note = paymentHistory.Note;
                paymentHistoryUpdate.Created_At = paymentHistory.Created_At;

                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        // Método para eliminar un historial de pago de la base de datos por su ID.
        public async Task<int> Delete(int id)
        {
            int result = 0;
            var paymentHistoryDelete = await GetById(id);
            if (paymentHistoryDelete.Id != 0)
            {
                // Elimina el historial de pago de la base de datos.
                _context.paymentHistories.Remove(paymentHistoryDelete);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        // Método privado para construir una consulta IQueryable con filtros.
        private IQueryable<PaymentHistory> Query(PaymentHistory paymentHistory)
        {
            var query = _context.paymentHistories.AsQueryable();

            if (paymentHistory.Rental_Payment_Id > 0)
                query = query.Where(ph => ph.Rental_Payment_Id == paymentHistory.Rental_Payment_Id);

            if (paymentHistory.Amount > 0)
                query = query.Where(ph => ph.Amount == paymentHistory.Amount);

            if (!string.IsNullOrWhiteSpace(paymentHistory.Payment_Type))
                query = query.Where(ph => ph.Payment_Type.Contains(paymentHistory.Payment_Type));

            if (!string.IsNullOrWhiteSpace(paymentHistory.Payment_Method))
                query = query.Where(ph => ph.Payment_Method.Contains(paymentHistory.Payment_Method));

            if (paymentHistory.Payment_Date != DateTime.MinValue)
                query = query.Where(ph => ph.Payment_Date == paymentHistory.Payment_Date);

            if (!string.IsNullOrWhiteSpace(paymentHistory.Note))
                query = query.Where(ph => ph.Note.Contains(paymentHistory.Note));

            return query;
        }

        // Método para contar el número de historiales de pago que cumplen con los filtros.
        public async Task<int> CountSearch(PaymentHistory paymentHistory)
        {
            return await Query(paymentHistory).CountAsync();
        }

        // Método para buscar historiales de pago con filtros, paginación y ordenamiento.
        public async Task<List<PaymentHistory>> Search(PaymentHistory paymentHistory, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = Query(paymentHistory);
            query = query.OrderByDescending(ph => ph.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
    }

}
