using ConstructoraExtreme.Models.DAL;
using ConstructoraExtreme.Models.EN;
using Extreme.DTOs.ProductsDTOs;

namespace ConstructoraExtreme.Endpoints
{
    public static class ProductEndpoint
    {
        public static void MapProductEndpoints(this WebApplication app)
        {
            // GET: Obtener producto por ID
            app.MapGet("/api/products/{id:int}", async (int id, ProductsDAL productRepo) =>
            {
                var product = await productRepo.GetById(id);
                if (product.Id == 0)
                    return Results.NotFound(new { message = "Producto no encontrado" });

                var result = new GetIdResultProductDTO
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Category = product.Category,
                    Brand = product.Brand,
                    Store_Id = product.Store_Id,
                    StoreName = product.Store?.Name
                };

                return Results.Ok(result);
            }).RequireAuthorization();

            // POST: Crear nuevo producto
            app.MapPost("/api/products/create", async (CreateProductDTO request, ProductsDAL productRepo) =>
            {
                var product = new Products
                {
                    Name = request.Name,
                    Description = request.Description,
                    Category = request.Category,
                    Brand = request.Brand,
                    Store_Id = request.Store_Id
                };

                int result = await productRepo.Create(product);
                return result > 0
                    ? Results.Created($"/api/products/{product.Id}", new { message = "Producto creado exitosamente" })
                    : Results.BadRequest(new { message = "No se pudo crear el producto" });
            }).RequireAuthorization("AdminPolicy");

            // PUT: Actualizar producto
            app.MapPut("/api/products/{id:int}", async (int id, EditProductDTO request, ProductsDAL productRepo) =>
            {
                var product = new Products
                {
                    Id = id,
                    Name = request.Name,
                    Description = request.Description,
                    Category = request.Category,
                    Brand = request.Brand,
                    Store_Id = request.Store_Id
                };

                int result = await productRepo.Edit(product);
                return result > 0
                    ? Results.Ok(new { message = "Producto actualizado exitosamente" })
                    : Results.NotFound(new { message = "Producto no encontrado" });
            }).RequireAuthorization("AdminPolicy");

            // POST: Búsqueda de productos
            app.MapPost("/api/products/search", async (SearchQueryProductDTO searchDTO, ProductsDAL productRepo) =>
            {
                try
                {
                    var product = new Products
                    {
                        Name = searchDTO.Name,
                        Category = searchDTO.Category,
                        Brand = searchDTO.Brand,
                        Store_Id = searchDTO.Store_Id ?? 0
                    };

                    var skip = (searchDTO.PageNumber - 1) * searchDTO.PageSize;
                    var searchResult = new SearchResultProductDTO();

                    var products = await productRepo.Search(
                        product,
                        searchDTO.PageSize,
                        skip
                    );

                    if (!products.Any())
                    {
                        return Results.Ok(new
                        {
                            message = "Aún no hay registros de productos",
                            data = new SearchResultProductDTO
                            {
                                CountRow = 0,
                                Data = new List<SearchResultProductDTO.ProductDTO>()
                            }
                        });
                    }

                    searchResult.CountRow = await productRepo.CountSearch(product);
                    searchResult.Data = products.Select(p => new SearchResultProductDTO.ProductDTO
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Category = p.Category,
                        Brand = p.Brand,
                        Store_Id = p.Store_Id,
                        StoreName = p.Store?.Name
                    }).ToList();

                    return Results.Ok(searchResult);
                }
                catch (Exception ex)
                {
                    return Results.Problem(
                        title: "Error en la búsqueda",
                        detail: ex.Message,
                        statusCode: 500
                    );
                }
            }).RequireAuthorization();

            // DELETE: Eliminar producto
            app.MapDelete("/api/products/{id:int}", async (int id, ProductsDAL productRepo) =>
            {
                int result = await productRepo.Delete(id);
                return result > 0
                    ? Results.Ok(new { message = "Producto eliminado exitosamente" })
                    : Results.NotFound(new { message = "Producto no encontrado" });
            }).RequireAuthorization("AdminPolicy");
        }
    }
}
