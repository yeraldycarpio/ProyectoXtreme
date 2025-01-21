using ConstructoraExtreme.Models.DAL;
using ConstructoraExtreme.Models.EN;
using Extreme.DTOs.RolesDTOs;

namespace ConstructoraExtreme.Endpoints
{
    public static class RoleEndpoint
    {
        public static void MapRoleEndpoints(this WebApplication app)
        {
            app.MapGet("/api/roles", async (RoleDAL roleRepo) =>
            {
                var roles = await roleRepo.GetAllRolesAsync();
                var rolesDTO = roles.Select(r => new RoleDTO
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,

                });

                return Results.Ok(rolesDTO);
            }).RequireAuthorization();

            app.MapGet("/api/roles/{id:int}", async (int id, RoleDAL roleRepo) =>
            {
                var role = await roleRepo.GetRoleByIdAsync(id);
                if (role == null)
                    return Results.NotFound(new { message = "Rol no encontrado" });

                var roleDTO = new RoleDTO
                {
                    Id = role.Id,
                    Name = role.Name,
                    Description = role.Description,

                };

                return Results.Ok(roleDTO);
            }).RequireAuthorization();

            // Endpoint para listar roles - accesible por Admin y otro
            app.MapPost("/api/roles/create", async (CreateRoleDTO request, RoleDAL roleRepo) =>
            {
                var role = new Role
                {
                    Name = request.Name,
                    Description = request.Description
                };

                await roleRepo.CreateRoleAsync(role);

                return Results.Created($"/api/roles/{role.Id}", new { message = "Rol creado exitosamente" });
            }).RequireAuthorization("AdminPolicy");

            app.MapPut("/api/roles/{id:int}", async (int id, EditRoleDTO request, RoleDAL roleRepo) =>
            {
                var role = await roleRepo.GetRoleByIdAsync(id);
                if (role == null)
                    return Results.NotFound(new { message = "Rol no encontrado" });

                role.Name = request.Name;
                role.Description = request.Description;

                await roleRepo.UpdateRoleAsync(role);

                return Results.Ok(new { message = "Rol actualizado exitosamente" });
            }).RequireAuthorization("AdminPolicy");

            app.MapDelete("/api/roles/{id:int}", async (int id, RoleDAL roleRepo) =>
            {
                var role = await roleRepo.GetRoleByIdAsync(id);
                if (role == null)
                    return Results.NotFound(new { message = "Rol no encontrado" });

                await roleRepo.DeleteRoleAsync(id);

                return Results.Ok(new { message = "Rol eliminado exitosamente" });
            }).RequireAuthorization("AdminPolicy");


        }
    }
}
