using ConstructoraExtreme.Models.EN;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace ConstructoraExtreme.Models.DAL
{
        public class ProductsDAL
        {
            private readonly XtremeContext _context;

            // Constructor que recibe un objeto CRMContext para interactuar con la base de datos.
            public ProductsDAL(XtremeContext xtremeContext)
            {
                _context = xtremeContext;
            }

            // Método para crear un nuevo producto en la base de datos.
            public async Task<int> Create(Products product)
            {
                _context.Products.Add(product);
                return await _context.SaveChangesAsync();
            }

            // Método para obtener un producto por su ID.
            public async Task<Products> GetById(int id)
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
                return product ?? new Products();
            }

            // Método para editar un producto existente en la base de datos.
            public async Task<int> Edit(Products product)
            {
                int result = 0;
                var productUpdate = await GetById(product.Id);
                if (productUpdate.Id != 0)
                {
                    // Actualiza los datos del producto.
                    productUpdate.Name = product.Name;
                    productUpdate.Description = product.Description;
                    productUpdate.Category = product.Category;
                    productUpdate.Brand = product.Brand;
                    productUpdate.Store_Id = product.Store_Id;

                    result = await _context.SaveChangesAsync();
                }
                return result;
            }

            // Método para eliminar un producto de la base de datos por su ID.
            public async Task<int> Delete(int id)
            {
                int result = 0;
                var productDelete = await GetById(id);
                if (productDelete.Id != 0)
                {
                    // Elimina el producto de la base de datos.
                    _context.Products.Remove(productDelete);
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }

            // Método privado para construir una consulta IQueryable con filtros.
            private IQueryable<Products> Query(Products product)
            {
                var query = _context.Products.AsQueryable();

                if (!string.IsNullOrWhiteSpace(product.Name))
                    query = query.Where(p => p.Name.Contains(product.Name));

                if (!string.IsNullOrWhiteSpace(product.Description))
                    query = query.Where(p => p.Description.Contains(product.Description));

                if (!string.IsNullOrWhiteSpace(product.Category))
                    query = query.Where(p => p.Category.Contains(product.Category));

                if (!string.IsNullOrWhiteSpace(product.Brand))
                    query = query.Where(p => p.Brand.Contains(product.Brand));

                if (product.Store_Id > 0)
                    query = query.Where(p => p.Store_Id == product.Store_Id);

                return query;
            }

            // Método para contar el número de productos que cumplen con los filtros.
            public async Task<int> CountSearch(Products product)
            {
                return await Query(product).CountAsync();
            }

            // Método para buscar productos con filtros, paginación y ordenamiento.
            public async Task<List<Products>> Search(Products product, int take = 10, int skip = 0)
            {
                take = take == 0 ? 10 : take;
                var query = Query(product);
                query = query.OrderByDescending(p => p.Id).Skip(skip).Take(take);
                return await query.ToListAsync();
            }
        }

    }

