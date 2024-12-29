using ConstructoraExtreme.Models.EN;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace ConstructoraExtreme.Models.DAL
{
        public class StoreDAL
        {
            private readonly XtremeContext _context;

            // Constructor que recibe un objeto CRMContext para interactuar con la base de datos.
            public StoreDAL(XtremeContext XtremeContext)
            {
                _context = XtremeContext;
            }

            // Método para crear una nueva tienda en la base de datos.
            public async Task<int> Create(Store store)
            {
                _context.Add(store);
                return await _context.SaveChangesAsync();
            }

            // Método para obtener una tienda por su ID.
            public async Task<Store> GetById(int id)
            {
                var store = await _context.Stores.FirstOrDefaultAsync(s => s.Id == id);
                return store ?? new Store();
            }

            // Método para editar una tienda existente en la base de datos.
            public async Task<int> Edit(Store store)
            {
                int result = 0;
                var storeUpdate = await GetById(store.Id);
                if (storeUpdate.Id != 0)
                {
                    // Actualiza los datos de la tienda.
                    storeUpdate.Name = store.Name;
                    storeUpdate.Address = store.Address;
                    storeUpdate.Address_Link = store.Address_Link;
                    storeUpdate.phone_number = store.phone_number;
                    storeUpdate.Nit = store.Nit;
                    storeUpdate.NRC = store.NRC;
                    storeUpdate.Giro = store.Giro;
                    storeUpdate.User_Id = store.User_Id;

                    result = await _context.SaveChangesAsync();
                }
                return result;
            }

            // Método para eliminar una tienda de la base de datos por su ID.
            public async Task<int> Delete(int id)
            {
                int result = 0;
                var storeDelete = await GetById(id);
                if (storeDelete.Id > 0)
                {
                    // Elimina la tienda de la base de datos.
                    _context.Stores.Remove(storeDelete);
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }

            // Método privado para construir una consulta IQueryable para buscar tiendas con filtros.
            private IQueryable<Store> Query(Store store)
            {
                var query = _context.Stores.AsQueryable();
                if (!string.IsNullOrWhiteSpace(store.Name))
                    query = query.Where(s => s.Name.Contains(store.Name));
                if (!string.IsNullOrWhiteSpace(store.Address))
                    query = query.Where(s => s.Address.Contains(store.Address));
                if (!string.IsNullOrWhiteSpace(store.phone_number))
                    query = query.Where(s => s.phone_number.Contains(store.phone_number));
                if (!string.IsNullOrWhiteSpace(store.Nit))
                    query = query.Where(s => s.Nit.Contains(store.Nit));
                if (!string.IsNullOrWhiteSpace(store.NRC))
                    query = query.Where(s => s.NRC.Contains(store.NRC));
                if (!string.IsNullOrWhiteSpace(store.Giro))
                    query = query.Where(s => s.Giro.Contains(store.Giro));
                if (store.User_Id > 0)
                    query = query.Where(s => s.User_Id == store.User_Id);

                return query;
            }

            // Método para contar la cantidad de resultados de búsqueda con filtros.
            public async Task<int> CountSearch(Store store)
            {
                return await Query(store).CountAsync();
            }

            // Método para buscar tiendas con filtros, paginación y ordenamiento.
            public async Task<List<Store>> Search(Store store, int take = 10, int skip = 0)
            {
                take = take == 0 ? 10 : take;
                var query = Query(store);
                query = query.OrderByDescending(s => s.Id).Skip(skip).Take(take);
                return await query.ToListAsync();
            }
        }

    }

