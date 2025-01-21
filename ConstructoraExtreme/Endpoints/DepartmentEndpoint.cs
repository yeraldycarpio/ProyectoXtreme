using ConstructoraExtreme.Models.DAL;
using ConstructoraExtreme.Models.EN;
using Extreme.DTOs.DepartmentsDTOs;


namespace ConstructoraExtreme.Endpoints
{
    public static class DepartmentEndpoint
    {
        public static void MapDepartmentEndpoint(this WebApplication app)
        {// GET: Obtener todos los departamentos con búsqueda y paginación
            app.MapPost("/api/departments/search", async (SearchQueryDepartmentsDTO searchDTO, DepartmentsCatalogDAL departmentRepo) =>
            {
                try
                {
                    var department = new DepartmentsCatalog
                    {
                        Code = searchDTO.Code,
                        Name = searchDTO.Name
                    };

                    var searchResult = new SearchResultDepartmentsDTO();

                    if (searchDTO.SendRowCount == 2)
                    {
                        searchResult.CountRow = await departmentRepo.CountSearch(department);
                    }

                    var departments = await departmentRepo.Search(
                        department,
                        searchDTO.Take,
                        searchDTO.Skip
                    );

                    if (!departments.Any())
                    {
                        return Results.Ok(new
                        {
                            message = "Aún no hay registros de departamentos",
                            data = new SearchResultDepartmentsDTO
                            {
                                CountRow = 0,
                                Data = new List<SearchResultDepartmentsDTO.DepartmentsDTO>()
                            }
                        });
                    }

                    searchResult.Data = departments.Select(d => new SearchResultDepartmentsDTO.DepartmentsDTO
                    {
                        Id = d.Id,
                        Code = d.Code,
                        Name = d.Name
                    }).ToList();

                    return Results.Ok(searchResult);
                }
                catch (Exception ex)
                {
                    return Results.Problem(
                        title: "Error en la búsqueda",
                        detail: "Ocurrió un error al buscar los departamentos. Por favor, verifica que la tabla exista en la base de datos.",
                        statusCode: 500
                    );
                }
            }).RequireAuthorization();

            // GET: Obtener departamento por ID
            app.MapGet("/api/departments/{id:int}", async (int id, DepartmentsCatalogDAL departmentRepo) =>
            {
                var department = await departmentRepo.GetById(id);
                if (department.Id == 0)
                    return Results.NotFound(new { message = "Departamento no encontrado" });

                var result = new GetIdResultDepartmentsDTO
                {
                    Id = department.Id,
                    Code = department.Code,
                    Name = department.Name
                };

                return Results.Ok(result);
            }).RequireAuthorization();

            //// POST: Crear nuevo departamento
            app.MapPost("/api/departments/create", async (CreateDepartmentsDTO request, DepartmentsCatalogDAL departmentRepo) =>
            {
                var department = new DepartmentsCatalog
                {
                    Code = request.Code,
                    Name = request.Name
                };

                int result = await departmentRepo.Create(department);
                return result > 0
                    ? Results.Created($"/api/departments/{department.Id}", new { message = "Departamento creado exitosamente" })
                    : Results.BadRequest(new { message = "No se pudo crear el departamento" });
            }).RequireAuthorization("AdminPolicy");

            

            // PUT: Actualizar departamento
            app.MapPut("/api/departments/{id:int}", async (int id, EditDepartmentsDTO request, DepartmentsCatalogDAL departmentRepo) =>
            {
                var department = new DepartmentsCatalog
                {
                    Id = id,
                    Code = request.Code,
                    Name = request.Name
                };

                int result = await departmentRepo.Edit(department);
                return result > 0
                    ? Results.Ok(new { message = "Departamento actualizado exitosamente" })
                    : Results.NotFound(new { message = "Departamento no encontrado" });
            }).RequireAuthorization("AdminPolicy");

            // DELETE: Eliminar departamento
            app.MapDelete("/api/departments/{id:int}", async (int id, DepartmentsCatalogDAL departmentRepo) =>
            {
                int result = await departmentRepo.Delete(id);
                return result > 0
                    ? Results.Ok(new { message = "Departamento eliminado exitosamente" })
                    : Results.NotFound(new { message = "Departamento no encontrado" });
            }).RequireAuthorization("AdminPolicy");
        }
    }
}
