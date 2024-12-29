using ConstructoraExtreme.Models.EN;
using Microsoft.EntityFrameworkCore;

namespace ConstructoraExtreme.Models.DAL
{
    public class InventoryDAL
    {
            private readonly XtremeContext _context;

            // Constructor que recibe un objeto XtremeContext para interactuar con la base de datos.
            public InventoryDAL(XtremeContext xtremeContext)
            {
                _context = xtremeContext;
            }

            // Método para crear un nuevo inventario en la base de datos.
            public async Task<int> Create(Inventory inventory)
            {
                _context.Inventories.Add(inventory);
                return await _context.SaveChangesAsync();
            }

            // Método para obtener un inventario por su ID.
            public async Task<Inventory> GetById(int id)
            {
                var inventory = await _context.Inventories
                    .Include(i => i.Products)  // Incluir el producto relacionado
                    .Include(i => i.Store)     // Incluir la tienda relacionada
                    .FirstOrDefaultAsync(i => i.Id == id);

                return inventory ?? new Inventory();
            }

            // Método para editar un inventario existente en la base de datos.
            public async Task<int> Edit(Inventory inventory)
            {
                int result = 0;
                var inventoryUpdate = await GetById(inventory.Id);
                if (inventoryUpdate.Id != 0)
                {
                    // Actualiza los datos del inventario.
                    inventoryUpdate.Available_Quantity = inventory.Available_Quantity;
                    inventoryUpdate.Product_Id = inventory.Product_Id;
                    inventoryUpdate.Store_Id = inventory.Store_Id;

                    result = await _context.SaveChangesAsync();
                }
                return result;
            }

            // Método para eliminar un inventario de la base de datos por su ID.
            public async Task<int> Delete(int id)
            {
                int result = 0;
                var inventoryDelete = await GetById(id);
                if (inventoryDelete.Id != 0)
                {
                    // Elimina el inventario de la base de datos.
                    _context.Inventories.Remove(inventoryDelete);
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }

            // Método privado para construir una consulta IQueryable con filtros.
            private IQueryable<Inventory> Query(Inventory inventory)
            {
                var query = _context.Inventories.AsQueryable();

                if (inventory.Product_Id > 0)
                    query = query.Where(i => i.Product_Id == inventory.Product_Id);

                if (inventory.Store_Id > 0)
                    query = query.Where(i => i.Store_Id == inventory.Store_Id);

                if (inventory.Available_Quantity > 0)
                    query = query.Where(i => i.Available_Quantity == inventory.Available_Quantity);

                return query;
            }

            // Método para contar el número de inventarios que cumplen con los filtros.
            public async Task<int> CountSearch(Inventory inventory)
            {
                return await Query(inventory).CountAsync();
            }

            // Método para buscar inventarios con filtros, paginación y ordenamiento.
            public async Task<List<Inventory>> Search(Inventory inventory, int take = 10, int skip = 0)
            {
                take = take == 0 ? 10 : take;
                var query = Query(inventory);
                query = query.OrderByDescending(i => i.Id).Skip(skip).Take(take);
                return await query.ToListAsync();
            }
        }
}
