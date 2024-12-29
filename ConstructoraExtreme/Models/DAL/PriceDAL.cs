using ConstructoraExtreme.Models.EN;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace ConstructoraExtreme.Models.DAL
{
    public class PricesDAL
    {
        private readonly XtremeContext _context;

        // Constructor que recibe un objeto CRMContext para interactuar con la base de datos.
        public PricesDAL(XtremeContext xtremeContext)
        {
            _context = xtremeContext;
        }

        // Método para crear un nuevo precio en la base de datos.
        public async Task<int> Create(Prices price)
        {
            _context.Prices.Add(price);
            return await _context.SaveChangesAsync();
        }

        // Método para obtener un precio por su ID.
        public async Task<Prices> GetById(int id)
        {
            var price = await _context.Prices.FirstOrDefaultAsync(p => p.Id == id);
            return price ?? new Prices();
        }

        // Método para editar un precio existente en la base de datos.
        public async Task<int> Edit(Prices price)
        {
            int result = 0;
            var priceUpdate = await GetById(price.Id);
            if (priceUpdate.Id != 0)
            {
                // Actualiza los datos del precio.
                priceUpdate.Daily_Price = price.Daily_Price;
                priceUpdate.Monthly_Price = price.Monthly_Price;
                priceUpdate.Product_Id = price.Product_Id;

                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        // Método para eliminar un precio de la base de datos por su ID.
        public async Task<int> Delete(int id)
        {
            int result = 0;
            var priceToDelete = await GetById(id);
            if (priceToDelete.Id != 0)
            {
                // Elimina el precio de la base de datos.
                _context.Prices.Remove(priceToDelete);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        // Método privado para construir una consulta IQueryable con filtros.
        private IQueryable<Prices> Query(Prices price)
        {
            var query = _context.Prices.AsQueryable();

            if (price.Daily_Price > 0)
                query = query.Where(p => p.Daily_Price == price.Daily_Price);

            if (price.Monthly_Price > 0)
                query = query.Where(p => p.Monthly_Price == price.Monthly_Price);

            if (price.Product_Id > 0)
                query = query.Where(p => p.Product_Id == price.Product_Id);

            return query;
        }

        // Método para contar el número de precios que cumplen con los filtros.
        public async Task<int> CountSearch(Prices price)
        {
            return await Query(price).CountAsync();
        }

        // Método para buscar precios con filtros, paginación y ordenamiento.
        public async Task<List<Prices>> Search(Prices price, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = Query(price);
            query = query.OrderByDescending(p => p.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
    }

}
