using ConstructoraExtreme.Models.DAL;
using ConstructoraExtreme.Models.EN;

namespace ConstructoraExtreme.DeparmentGenerator
{
   public static class DepartmentsDataGenerator
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<XtremeContext>();

                // Verificar si ya existen registros para evitar duplicados
                if (!context.DepartmentsCatalogs.Any())
                {
                    // Crear lista de departamentos de El Salvador
                    var departments = new DepartmentsCatalog[]
                    {
                        new DepartmentsCatalog { Code = "01", Name = "Ahuachapán" },
                        new DepartmentsCatalog { Code = "02", Name = "Santa Ana" },
                        new DepartmentsCatalog { Code = "03", Name = "Sonsonate" },
                        new DepartmentsCatalog { Code = "04", Name = "Chalatenango" },
                        new DepartmentsCatalog { Code = "05", Name = "La Libertad" },
                        new DepartmentsCatalog { Code = "06", Name = "San Salvador" },
                        new DepartmentsCatalog { Code = "07", Name = "Cuscatlán" },
                        new DepartmentsCatalog { Code = "08", Name = "La Paz" },
                        new DepartmentsCatalog { Code = "09", Name = "Cabañas" },
                        new DepartmentsCatalog { Code = "10", Name = "San Vicente" },
                        new DepartmentsCatalog { Code = "11", Name = "Usulután" },
                        new DepartmentsCatalog { Code = "12", Name = "San Miguel" },
                        new DepartmentsCatalog { Code = "13", Name = "Morazán" },
                        new DepartmentsCatalog { Code = "14", Name = "La Unión" }
                    };

                    // Agregar todos los departamentos al contexto
                    context.DepartmentsCatalogs.AddRange(departments);

                    // Guardar cambios en la base de datos
                    context.SaveChanges();
                }
            }
        }
    }
}
