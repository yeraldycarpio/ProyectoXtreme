using ConstructoraExtreme.Models.DAL;
using ConstructoraExtreme.Models.EN;
using Extreme.DTOs.CategoryDTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructoraExtreme.Endpoints
{
    public static class CategoryController
    {
        public static void MapCategoryEndpoints(this WebApplication app)
        {
            // Crear categoría
            app.MapPost("/api/category/create", async (CreateCategoryDTO request, CategoryDAL categoryRepo) =>
            {
                var category = new Category
                {
                    Name = request.Name
                };

                await categoryRepo.CreateCategoryAsync(category);
                return Results.Created($"/api/category/{category.Id}", new { message = "Categoría creada exitosamente", id = category.Id });
            });

            // Obtener todas las categorías
            app.MapGet("/api/category/all", async (CategoryDAL categoryRepo) =>
            {
                var categories = await categoryRepo.GetAllCategoriesAsync();
                var categoryDTOs = categories.Select(c => new CategoryDTOS
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList();

                return Results.Ok(categoryDTOs);
            });

            // Obtener categoría por ID
            app.MapGet("/api/category/{id:int}", async (int id, CategoryDAL categoryRepo) =>
            {
                var category = await categoryRepo.GetCategoryByIdAsync(id);
                if (category == null)
                {
                    return Results.NotFound(new { message = "Categoría no encontrada" });
                }

                var categoryDTO = new CategoryDTOS
                {
                    Id = category.Id,
                    Name = category.Name
                };

                return Results.Ok(categoryDTO);
            });

            // Actualizar categoría
            app.MapPut("/api/category/update/{id:int}", async (int id, EditCategoryDTOS request, CategoryDAL categoryRepo) =>
            {
                var existingCategory = await categoryRepo.GetCategoryByIdAsync(id);
                if (existingCategory == null)
                {
                    return Results.NotFound(new { message = "Categoría no encontrada" });
                }

                existingCategory.Name = request.Name;

                await categoryRepo.UpdateCategoryAsync(existingCategory);
                return Results.Ok(new { message = "Categoría actualizada exitosamente" });
            });

            // Eliminar categoría
            app.MapDelete("/api/category/delete/{id:int}", async (int id, CategoryDAL categoryRepo) =>
            {
                var category = await categoryRepo.GetCategoryByIdAsync(id);
                if (category == null)
                {
                    return Results.NotFound(new { message = "Categoría no encontrada" });
                }

                await categoryRepo.DeleteCategoryAsync(id);
                return Results.Ok(new { message = "Categoría eliminada exitosamente" });
            });
        }
    }
}