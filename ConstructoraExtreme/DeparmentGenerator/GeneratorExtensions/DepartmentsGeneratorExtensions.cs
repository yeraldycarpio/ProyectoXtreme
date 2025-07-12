using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructoraExtreme.DeparmentGenerator.GeneratorExtensions
{
    public static class DepartmentsGeneratorExtensions
    {
        public static IApplicationBuilder UseDepartmentsGenerator(this IApplicationBuilder app)
        {
            // Inicializar datos del catálogo de departamentos de El Salvador
            DepartmentsDataGenerator.Initialize(app);

            return app;
        }
    }
}
