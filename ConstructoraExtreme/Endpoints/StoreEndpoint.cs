using ConstructoraExtreme.Models.DAL;
using ConstructoraExtreme.Models.EN;
using Extreme.DTOs.StoreDTOs;

namespace ConstructoraExtreme.Endpoints
{
    public static class StoreEndpoint
    {
        public static void MapStoreEndpoints(this WebApplication app)
        {
            // GET: Obtener tienda por ID
            app.MapGet("/api/stores/{id:int}", async (int id, StoreDAL storeRepo) =>
            {
                var store = await storeRepo.GetById(id);
                if (store.Id == 0)
                    return Results.NotFound(new { message = "Tienda no encontrada" });

                var result = new GetIdResultStoreDTO
                {
                    Id = store.Id,
                    Name = store.Name,
                    Address = store.Address,
                    Address_Link = store.Address_Link,
                    PhoneNumber = store.phone_number,
                    Nit = store.Nit,
                    NRC = store.NRC,
                    Giro = store.Giro,
                    UserId = store.User_Id
                };

                return Results.Ok(result);
            }).RequireAuthorization();

            // POST: Crear nueva tienda
            app.MapPost("/api/stores/create", async (CreateStoreDTO request, StoreDAL storeRepo) =>
            {
                var store = new Store
                {
                    Name = request.Name,
                    Address = request.Address,
                    Address_Link = request.Address_Link,
                    phone_number = request.PhoneNumber,
                    Nit = request.Nit,
                    NRC = request.NRC,
                    Giro = request.Giro,
                    User_Id = request.UserId
                };

                int result = await storeRepo.Create(store);
                return result > 0
                    ? Results.Created($"/api/stores/{store.Id}", new { message = "Tienda creada exitosamente" })
                    : Results.BadRequest(new { message = "No se pudo crear la tienda" });
            }).RequireAuthorization("AdminPolicy");

            // PUT: Actualizar tienda
            app.MapPut("/api/stores/{id:int}", async (int id, EditStoreDTO request, StoreDAL storeRepo) =>
            {
                var store = new Store
                {
                    Id = id,
                    Name = request.Name,
                    Address = request.Address,
                    Address_Link = request.Address_Link,
                    phone_number = request.PhoneNumber,
                    Nit = request.Nit,
                    NRC = request.NRC,
                    Giro = request.Giro,
                    User_Id = request.UserId
                };

                int result = await storeRepo.Edit(store);
                return result > 0
                    ? Results.Ok(new { message = "Tienda actualizada exitosamente" })
                    : Results.NotFound(new { message = "Tienda no encontrada" });
            }).RequireAuthorization("AdminPolicy");

            // POST: Búsqueda de tiendas
            app.MapPost("/api/stores/search", async (SearchQueryStoreDTO searchDTO, StoreDAL storeRepo) =>
            {
                try
                {
                    var store = new Store
                    {
                        Name = searchDTO.Name_Like,
                        Address = searchDTO.Address_Like,
                        phone_number = searchDTO.PhoneNumber_Like,
                        Nit = searchDTO.Nit_Like,
                        NRC = searchDTO.NRC_Like,
                        //User_Id = searchDTO.User_Like
                    };

                    var searchResult = new SearchResultStoreDTO();

                    if (searchDTO.SendRowCount == 2)
                    {
                        searchResult.CountRow = await storeRepo.CountSearch(store);
                    }

                    var stores = await storeRepo.Search(
                        store,
                        searchDTO.Take,
                        searchDTO.Skip
                    );

                    if (!stores.Any())
                    {
                        return Results.Ok(new
                        {
                            message = "Aún no hay registros de tiendas",
                            data = new SearchResultStoreDTO
                            {
                                CountRow = 0,
                                Data = new List<SearchResultStoreDTO.StoreDTO>()
                            }
                        });
                    }

                    searchResult.Data = stores.Select(s => new SearchResultStoreDTO.StoreDTO
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Address = s.Address,
                        PhoneNumber = s.phone_number,
                        Nit = s.Nit,
                        NRC = s.NRC,
                        Giro = s.Giro
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

            // DELETE: Eliminar tienda
            app.MapDelete("/api/stores/{id:int}", async (int id, StoreDAL storeRepo) =>
            {
                int result = await storeRepo.Delete(id);
                return result > 0
                    ? Results.Ok(new { message = "Tienda eliminada exitosamente" })
                    : Results.NotFound(new { message = "Tienda no encontrada" });
            }).RequireAuthorization("AdminPolicy");
        }
    }
}
