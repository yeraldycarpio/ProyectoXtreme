using ConstructoraExtreme.Models.DAL;
using ConstructoraExtreme.Models.DTO;
using ConstructoraExtreme.Models.EN;
using Extreme.DTOs.PersonsDTOs;
using Extreme.DTOs.ProductsDTOs;

namespace ConstructoraExtreme.Endpoints
{
    public static class PersonsControllers
    {
        public static void MapPersonsEndpoint(this WebApplication app)
        {
            app.MapPost("/api/persons/create", async (CreatePersonDTO request, PersonsDAL personsRepo) =>
            {
                try
                {
                    var persons = new Persons
                    {
                        Document_Type_Id = request.Document_Type_Id,
                        Document_Number = request.Document_Number,
                        Store_Id = request.Store_Id,
                        Is_Natural_Person = request.Is_Natural_Person,
                        First_Name = request.First_Name,
                        Middle_Name = request.Middle_Name,
                        First_Surname = request.First_Surname,
                        Second_Surname = request.Second_Surname,
                        Business_Name = request.Business_Name,
                        Trade_Name = request.Trade_Name,
                        NRC = request.NRC,
                        Economic_Activity_Id = request.Economic_Activity_Id,
                        Email = request.Email,
                        Phone = request.Phone,
                        Country = request.Country,
                        Department_Id = request.Department_Id,
                        Municipality_Id = request.Municipality_Id,
                        Address_Details = request.Address_Details,
                        Active = request.Active,
                        Created_At = DateTime.UtcNow,
                        Updated_At = DateTime.UtcNow
                    };

                    await personsRepo.Create(persons);

                    return Results.Created($"/api/persons/{persons.Id}", new
                    {
                        message = "Persona creada exitosamente",
                        id = persons.Id
                    });
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new
                    {
                        message = "Error al crear la persona",
                        error = ex.Message
                    });
                }
            });

             // Endpoint para buscar personas con filtros y paginación
            app.MapPost("/api/persons/search", async (SearchQueryPersonDTO searchDTO, PersonsDAL personsRepo) =>
            {
                try
                {
                    var person = new Persons
                    {
                        Document_Number = searchDTO.Document_Number,
                        First_Name = searchDTO.First_Name,
                        First_Surname = searchDTO.First_Surname,
                        Business_Name = searchDTO.Business_Name,
                        Store_Id = searchDTO.Document_Type_Id ?? 0,
                        Active = searchDTO.Active ?? true
                    };

                    var skip = (searchDTO.PageNumber - 1) * searchDTO.PageSize;
                    var searchResult = new SearchResultPersonDTO();

                    var persons = await personsRepo.Search(
                        person,
                        searchDTO.PageSize,
                        skip
                    );

                    if (!persons.Any())
                    {
                        return Results.Ok(new
                        {
                            message = "Aún no hay registros de personas",
                            data = new SearchResultPersonDTO
                            {
                                TotalRecords = 0,
                                PageNumber = searchDTO.PageNumber,
                                PageSize = searchDTO.PageSize,
                                Persons = new List<GetIdResultPersonDTO>()
                            }
                        });
                    }

                    searchResult.TotalRecords = await personsRepo.CountSearch(person);
                    searchResult.PageNumber = searchDTO.PageNumber;
                    searchResult.PageSize = searchDTO.PageSize;
                    searchResult.Persons = persons.Select(p => new GetIdResultPersonDTO
                    {
                        Id = p.Id,
                        Document_Type_Id = p.Document_Type_Id,
                        Document_Number = p.Document_Number,
                        Store_Id = p.Store_Id,
                        Is_Natural_Person = p.Is_Natural_Person,
                        First_Name = p.First_Name,
                        Middle_Name = p.Middle_Name,
                        First_Surname = p.First_Surname,
                        Second_Surname = p.Second_Surname,
                        Business_Name = p.Business_Name,
                        Trade_Name = p.Trade_Name,
                        NRC = p.NRC,
                        Economic_Activity_Id = p.Economic_Activity_Id,
                        Email = p.Email,
                        Phone = p.Phone,
                        Country = p.Country,
                        Department_Id = p.Department_Id,
                        Municipality_Id = p.Municipality_Id,
                        Address_Details = p.Address_Details,
                        Active = p.Active,
                        Created_At = p.Created_At,
                        Updated_At = p.Updated_At,
                        // Propiedades de navegación si están disponibles
                        //Document_Type_Name = p.DocumentType?.Name,
                        //Economic_Activity_Name = p.EconomicActivity?.Name,
                        //Department_Name = p.Department?.Name,
                        //Municipality_Name = p.Municipality?.Name,
                        //Store_Name = p.Store?.Name
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
            });

            app.MapPut("/api/persons/{id:int}", async (int id, EditPersonDTO request, PersonsDAL personsRepo) =>
            {
                // Validate that the ID in the URL matches the ID in the request body
                if (id != request.Id)
                {
                    return Results.BadRequest(new { message = "El ID en la URL no coincide con el ID en el cuerpo de la solicitud" });
                }

                var persons = new Persons
                {
                    Id = request.Id,
                    Document_Type_Id = request.Document_Type_Id,
                    Document_Number = request.Document_Number,
                    Store_Id = request.Store_Id,
                    Is_Natural_Person = request.Is_Natural_Person,
                    First_Name = request.First_Name,
                    Middle_Name = request.Middle_Name,
                    First_Surname = request.First_Surname,
                    Second_Surname = request.Second_Surname,
                    Business_Name = request.Business_Name,
                    Trade_Name = request.Trade_Name,
                    NRC = request.NRC,
                    Economic_Activity_Id = request.Economic_Activity_Id,
                    Email = request.Email,
                    Phone = request.Phone,
                    Country = request.Country,
                    Department_Id = request.Department_Id,
                    Municipality_Id = request.Municipality_Id,
                    Address_Details = request.Address_Details,
                    Active = request.Active,
                    Updated_At = DateTime.UtcNow // Set to current time instead of using client-provided time
                };

                int result = await personsRepo.Edit(persons);
                return result > 0
                    ? Results.Ok(new { message = "Persona actualizada exitosamente" })
                    : Results.NotFound(new { message = "Persona no encontrada" });
            });


            app.MapDelete("/api/persons/{id:int}", async (int id, PersonsDAL personsRepo) =>
            {
                int result = await personsRepo.Delete(id);
                return result > 0
                    ? Results.Ok(new { message = "Producto eliminado exitosamente" })
                    : Results.NotFound(new { message = "Producto no encontrado" });
            });


        }
    }
}