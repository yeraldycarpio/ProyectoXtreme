using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructoraExtreme.MunicipalGenerator.MunicipalGeneratorExtencions
{
    public static class MunicipalitiesGeneratorExtensions
    {
        public static IApplicationBuilder UseMunicipalitiesGenerator(this IApplicationBuilder app)
        {
            // Inicializar datos del catálogo de municipios de El Salvador
            MunicipalitiesDataGenerator.Initialize(app);
            return app;
        }
    }
}
