using ConstructoraExtreme.Models.DAL;
using ConstructoraExtreme.Models.EN;
using Extreme.DTOs.PersonReferencesDTOs;
using Extreme.DTOs.RolesDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructoraExtreme.Endpoints
{
    public static class PersonReferencesController
    {
        public static void MapPersonReferencesEndpoint(this WebApplication app)
        {
            app.MapPost("/api/personreference/create", async (CreatePersonReferencesDTO request, PersonReferencesDAL personreferencRepo) =>
            {
                var personreferen = new PersonReferences
                {
                    Store_Id = request.Store_Id,
                    Person_Id = request.Person_Id,
                    First_Name = request.First_Name,
                    Middle_Name = request.Middle_Name,
                    First_Surname = request.First_Surname,
                    Second_Surname = request.Second_Surname, // Added this missing property
                    Phone = request.Phone,
                    Active = request.Active, // Set from DTO
                    Created_At = DateTime.Now, // Set current datetime
                    Updated_At = DateTime.Now  // Set current datetime
                };

                await personreferencRepo.Create(personreferen);
                return Results.Created($"/api/personreference/{personreferen.Id}", new { message = "Referencia de persona creada exitosamente" });
            });

            app.MapPut("/api/personreference/{id:int}", async (int id, EditPersonReferencesDTO request, PersonReferencesDAL personreferencRepo) =>
            {
                if (id != request.Id)
                    return Results.BadRequest(new { message = "El ID en la URL no coincide con el ID en los datos" });

                var personReferences = await personreferencRepo.GetById(id);
                if (personReferences == null)
                    return Results.NotFound(new { message = "Referencia de persona no encontrada" });

                // Solo actualizar los campos modificables
                // Store_Id y Person_Id permanecen sin cambios
                personReferences.First_Name = request.First_Name;
                personReferences.Middle_Name = request.Middle_Name;
                personReferences.First_Surname = request.First_Surname;
                personReferences.Second_Surname = request.Second_Surname;
                personReferences.Phone = request.Phone;
                personReferences.Active = request.Active;
                personReferences.Updated_At = DateTime.Now;

                await personreferencRepo.Edit(personReferences);
                return Results.Ok(new
                {
                    message = "Referencia de persona actualizada exitosamente",
                    // data = new
                    // {
                    //Id = personReferences.Id,
                    //Store_Id = personReferences.Store_Id, // Se mantiene el original
                    //Person_Id = personReferences.Person_Id, // Se mantiene el original
                    //First_Name = personReferences.First_Name,
                    // Middle_Name = personReferences.Middle_Name,
                    //First_Surname = personReferences.First_Surname,
                    //Second_Surname = personReferences.Second_Surname,
                    //Phone = personReferences.Phone,
                    //Active = personReferences.Active,
                    //Updated_At = personReferences.Updated_At
                    //}
                });
            });

            app.MapDelete("/api/personreference/{id:int}", async (int id, PersonReferencesDAL personreferencRepo) =>
            {
                var role = await personreferencRepo.GetById(id);
                if (role == null)
                    return Results.NotFound(new { message = "Perosn no encontrado" });

                await personreferencRepo.Delete(id);

                return Results.Ok(new { message = "Rol eliminado exitosamente" });
            });
        }
    }
}
