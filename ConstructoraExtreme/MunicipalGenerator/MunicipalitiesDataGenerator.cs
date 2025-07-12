using ConstructoraExtreme.Models.DAL;
using ConstructoraExtreme.Models.EN;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConstructoraExtreme.MunicipalGenerator
{
    public static class MunicipalitiesDataGenerator
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<XtremeContext>();

                // Obtener municipios existentes para evitar duplicados
                var existingCodes = context.Set<MunicipalitiesCatalog>()
                    .Select(m => m.Code)
                    .ToHashSet();

                try
                {
                    // Crear listas de municipios por departamento
                    // Ahuachapán (ID: 1)
                    var ahuachapanMunicipalities = new List<MunicipalitiesCatalog>
                        {
                            new MunicipalitiesCatalog { Name = "Ahuachapán", Code = "0101", Department_Id = 1 },
                            new MunicipalitiesCatalog { Name = "Apaneca", Code = "0102", Department_Id = 1 },
                            new MunicipalitiesCatalog { Name = "Atiquizaya", Code = "0103", Department_Id = 1 },
                            new MunicipalitiesCatalog { Name = "Concepción de Ataco", Code = "0104", Department_Id = 1 },
                            new MunicipalitiesCatalog { Name = "El Refugio", Code = "0105", Department_Id = 1 },
                            new MunicipalitiesCatalog { Name = "Guaymango", Code = "0106", Department_Id = 1 },
                            new MunicipalitiesCatalog { Name = "Jujutla", Code = "0107", Department_Id = 1 },
                            new MunicipalitiesCatalog { Name = "San Francisco Menéndez", Code = "0108", Department_Id = 1 },
                            new MunicipalitiesCatalog { Name = "San Lorenzo", Code = "0109", Department_Id = 1 },
                            new MunicipalitiesCatalog { Name = "San Pedro Puxtla", Code = "0110", Department_Id = 1 },
                            new MunicipalitiesCatalog { Name = "Tacuba", Code = "0111", Department_Id = 1 },
                            new MunicipalitiesCatalog { Name = "Turín", Code = "0112", Department_Id = 1 }
                        };

                    // Santa Ana (ID: 2)
                    var santaAnaMunicipalities = new List<MunicipalitiesCatalog>
                        {
                            new MunicipalitiesCatalog { Name = "Santa Ana", Code = "0201", Department_Id = 2 },
                            new MunicipalitiesCatalog { Name = "Candelaria de la Frontera", Code = "0202", Department_Id = 2 },
                            new MunicipalitiesCatalog { Name = "Chalchuapa", Code = "0203", Department_Id = 2 },
                            new MunicipalitiesCatalog { Name = "Coatepeque", Code = "0204", Department_Id = 2 },
                            new MunicipalitiesCatalog { Name = "El Congo", Code = "0205", Department_Id = 2 },
                            new MunicipalitiesCatalog { Name = "El Porvenir", Code = "0206", Department_Id = 2 },
                            new MunicipalitiesCatalog { Name = "Masahuat", Code = "0207", Department_Id = 2 },
                            new MunicipalitiesCatalog { Name = "Metapán", Code = "0208", Department_Id = 2 },
                            new MunicipalitiesCatalog { Name = "San Antonio Pajonal", Code = "0209", Department_Id = 2 },
                            new MunicipalitiesCatalog { Name = "San Sebastián Salitrillo", Code = "0210", Department_Id = 2 },
                            new MunicipalitiesCatalog { Name = "Santa Rosa Guachipilín", Code = "0211", Department_Id = 2 },
                            new MunicipalitiesCatalog { Name = "Santiago de la Frontera", Code = "0212", Department_Id = 2 },
                            new MunicipalitiesCatalog { Name = "Texistepeque", Code = "0213", Department_Id = 2 }
                        };

                    // Sonsonate (ID: 3)
                    var sonsonateMunicipalities = new List<MunicipalitiesCatalog>
                        {
                            new MunicipalitiesCatalog { Name = "Sonsonate", Code = "0301", Department_Id = 3 },
                            new MunicipalitiesCatalog { Name = "Acajutla", Code = "0302", Department_Id = 3 },
                            new MunicipalitiesCatalog { Name = "Armenia", Code = "0303", Department_Id = 3 },
                            new MunicipalitiesCatalog { Name = "Caluco", Code = "0304", Department_Id = 3 },
                            new MunicipalitiesCatalog { Name = "Cuisnahuat", Code = "0305", Department_Id = 3 },
                            new MunicipalitiesCatalog { Name = "Santa Isabel Ishuatán", Code = "0306", Department_Id = 3 },
                            new MunicipalitiesCatalog { Name = "Izalco", Code = "0307", Department_Id = 3 },
                            new MunicipalitiesCatalog { Name = "Juayúa", Code = "0308", Department_Id = 3 },
                            new MunicipalitiesCatalog { Name = "Nahuizalco", Code = "0309", Department_Id = 3 },
                            new MunicipalitiesCatalog { Name = "Nahulingo", Code = "0310", Department_Id = 3 },
                            new MunicipalitiesCatalog { Name = "Salcoatitán", Code = "0311", Department_Id = 3 },
                            new MunicipalitiesCatalog { Name = "San Antonio del Monte", Code = "0312", Department_Id = 3 },
                            new MunicipalitiesCatalog { Name = "San Julián", Code = "0313", Department_Id = 3 },
                            new MunicipalitiesCatalog { Name = "Santa Catarina Masahuat", Code = "0314", Department_Id = 3 },
                            new MunicipalitiesCatalog { Name = "Santo Domingo de Guzmán", Code = "0315", Department_Id = 3 },
                            new MunicipalitiesCatalog { Name = "Sonzacate", Code = "0316", Department_Id = 3 }
                        };

                    // Chalatenango (ID: 4)
                    var chalatenangoMunicipalities = new List<MunicipalitiesCatalog>
                        {
                            new MunicipalitiesCatalog { Name = "Chalatenango", Code = "0401", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "Agua Caliente", Code = "0402", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "Arcatao", Code = "0403", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "Azacualpa", Code = "0404", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "Cancasque", Code = "0405", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "Citalá", Code = "0406", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "Comalapa", Code = "0407", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "Concepción Quezaltepeque", Code = "0408", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "Dulce Nombre de María", Code = "0409", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "El Carrizal", Code = "0410", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "El Paraíso", Code = "0411", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "La Laguna", Code = "0412", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "La Palma", Code = "0413", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "La Reina", Code = "0414", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "Las Vueltas", Code = "0415", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "Nombre de Jesús", Code = "0416", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "Nueva Concepción", Code = "0417", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "Nueva Trinidad", Code = "0418", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "Ojos de Agua", Code = "0419", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "Potonico", Code = "0420", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "San Antonio de la Cruz", Code = "0421", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "San Antonio Los Ranchos", Code = "0422", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "San Fernando", Code = "0423", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "San Francisco Lempa", Code = "0424", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "San Francisco Morazán", Code = "0425", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "San Ignacio", Code = "0426", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "San Isidro Labrador", Code = "0427", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "Las Flores", Code = "0428", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "San Luis del Carmen", Code = "0429", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "San Miguel de Mercedes", Code = "0430", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "San Rafael", Code = "0431", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "Santa Rita", Code = "0432", Department_Id = 4 },
                            new MunicipalitiesCatalog { Name = "Tejutla", Code = "0433", Department_Id = 4 }
                        };

                    // La Libertad (ID: 5)
                    var laLibertadMunicipalities = new List<MunicipalitiesCatalog>
                        {
                            new MunicipalitiesCatalog { Name = "Antiguo Cuscatlán", Code = "0501", Department_Id = 5 },
                            new MunicipalitiesCatalog { Name = "Ciudad Arce", Code = "0502", Department_Id = 5 },
                            new MunicipalitiesCatalog { Name = "Colón", Code = "0503", Department_Id = 5 },
                            new MunicipalitiesCatalog { Name = "Comasagua", Code = "0504", Department_Id = 5 },
                            new MunicipalitiesCatalog { Name = "Chiltiupán", Code = "0505", Department_Id = 5 },
                            new MunicipalitiesCatalog { Name = "Huizúcar", Code = "0506", Department_Id = 5 },
                            new MunicipalitiesCatalog { Name = "Jayaque", Code = "0507", Department_Id = 5 },
                            new MunicipalitiesCatalog { Name = "Jicalapa", Code = "0508", Department_Id = 5 },
                            new MunicipalitiesCatalog { Name = "La Libertad", Code = "0509", Department_Id = 5 },
                            new MunicipalitiesCatalog { Name = "Nueva San Salvador", Code = "0510", Department_Id = 5 },
                            new MunicipalitiesCatalog { Name = "Nuevo Cuscatlán", Code = "0511", Department_Id = 5 },
                            new MunicipalitiesCatalog { Name = "Opico", Code = "0512", Department_Id = 5 },
                            new MunicipalitiesCatalog { Name = "Quezaltepeque", Code = "0513", Department_Id = 5 },
                            new MunicipalitiesCatalog { Name = "Sacacoyo", Code = "0514", Department_Id = 5 },
                            new MunicipalitiesCatalog { Name = "San José Villanueva", Code = "0515", Department_Id = 5 },
                            new MunicipalitiesCatalog { Name = "San Juan Opico", Code = "0516", Department_Id = 5 },
                            new MunicipalitiesCatalog { Name = "San Matías", Code = "0517", Department_Id = 5 },
                            new MunicipalitiesCatalog { Name = "San Pablo Tacachico", Code = "0518", Department_Id = 5 },
                            new MunicipalitiesCatalog { Name = "Tamanique", Code = "0519", Department_Id = 5 },
                            new MunicipalitiesCatalog { Name = "Talnique", Code = "0520", Department_Id = 5 },
                            new MunicipalitiesCatalog { Name = "Teotepeque", Code = "0521", Department_Id = 5 },
                            new MunicipalitiesCatalog { Name = "Zaragoza", Code = "0522", Department_Id = 5 }
                        };

                    // San Salvador (ID: 6)
                    var sanSalvadorMunicipalities = new List<MunicipalitiesCatalog>
                        {
                            new MunicipalitiesCatalog { Name = "Aguilares", Code = "0601", Department_Id = 6 },
                            new MunicipalitiesCatalog { Name = "Apopa", Code = "0602", Department_Id = 6 },
                            new MunicipalitiesCatalog { Name = "Ayutuxtepeque", Code = "0603", Department_Id = 6 },
                            new MunicipalitiesCatalog { Name = "Cuscatancingo", Code = "0604", Department_Id = 6 },
                            new MunicipalitiesCatalog { Name = "El Paisnal", Code = "0605", Department_Id = 6 },
                            new MunicipalitiesCatalog { Name = "Guazapa", Code = "0606", Department_Id = 6 },
                            new MunicipalitiesCatalog { Name = "Ilopango", Code = "0607", Department_Id = 6 },
                            new MunicipalitiesCatalog { Name = "Mejicanos", Code = "0608", Department_Id = 6 },
                            new MunicipalitiesCatalog { Name = "Nejapa", Code = "0609", Department_Id = 6 },
                            new MunicipalitiesCatalog { Name = "Panchimalco", Code = "0610", Department_Id = 6 },
                            new MunicipalitiesCatalog { Name = "Rosario de Mora", Code = "0611", Department_Id = 6 },
                            new MunicipalitiesCatalog { Name = "San Marcos", Code = "0612", Department_Id = 6 },
                            new MunicipalitiesCatalog { Name = "San Martín", Code = "0613", Department_Id = 6 },
                            new MunicipalitiesCatalog { Name = "San Salvador", Code = "0614", Department_Id = 6 },
                            new MunicipalitiesCatalog { Name = "Santiago Texacuangos", Code = "0615", Department_Id = 6 },
                            new MunicipalitiesCatalog { Name = "Santo Tomás", Code = "0616", Department_Id = 6 },
                            new MunicipalitiesCatalog { Name = "Soyapango", Code = "0617", Department_Id = 6 },
                            new MunicipalitiesCatalog { Name = "Tonacatepeque", Code = "0618", Department_Id = 6 },
                            new MunicipalitiesCatalog { Name = "Ciudad Delgado", Code = "0619", Department_Id = 6 }
                        };

                    // Cuscatlán (ID: 7)
                    var cuscatlanMunicipalities = new List<MunicipalitiesCatalog>
{
    new MunicipalitiesCatalog { Name = "Candelaria", Code = "0701", Department_Id = 7 },
    new MunicipalitiesCatalog { Name = "Cojutepeque", Code = "0702", Department_Id = 7 },
    new MunicipalitiesCatalog { Name = "El Carmen", Code = "0703", Department_Id = 7 },
    new MunicipalitiesCatalog { Name = "El Rosario", Code = "0704", Department_Id = 7 },
    new MunicipalitiesCatalog { Name = "Monte San Juan", Code = "0705", Department_Id = 7 },
    new MunicipalitiesCatalog { Name = "Oratorio de Concepción", Code = "0706", Department_Id = 7 },
    new MunicipalitiesCatalog { Name = "San Bartolomé Perulapía", Code = "0707", Department_Id = 7 },
    new MunicipalitiesCatalog { Name = "San Cristóbal", Code = "0708", Department_Id = 7 },
    new MunicipalitiesCatalog { Name = "San José Guayabal", Code = "0709", Department_Id = 7 },
    new MunicipalitiesCatalog { Name = "San Pedro Perulapán", Code = "0710", Department_Id = 7 },
    new MunicipalitiesCatalog { Name = "San Rafael Cedros", Code = "0711", Department_Id = 7 },
    new MunicipalitiesCatalog { Name = "San Ramón", Code = "0712", Department_Id = 7 },
    new MunicipalitiesCatalog { Name = "Santa Cruz Analquito", Code = "0713", Department_Id = 7 },
    new MunicipalitiesCatalog { Name = "Santa Cruz Michapa", Code = "0714", Department_Id = 7 },
    new MunicipalitiesCatalog { Name = "Suchitoto", Code = "0715", Department_Id = 7 },
    new MunicipalitiesCatalog { Name = "Tenancingo", Code = "0716", Department_Id = 7 }
};
                    // La Paz (ID: 8)
                    var laPazMunicipalities = new List<MunicipalitiesCatalog>
{
    new MunicipalitiesCatalog { Name = "Cuyultitán", Code = "0801", Department_Id = 8 },
    new MunicipalitiesCatalog { Name = "El Rosario", Code = "0802", Department_Id = 8 },
    new MunicipalitiesCatalog { Name = "Jerusalén", Code = "0803", Department_Id = 8 },
    new MunicipalitiesCatalog { Name = "Mercedes La Ceiba", Code = "0804", Department_Id = 8 },
    new MunicipalitiesCatalog { Name = "Olocuilta", Code = "0805", Department_Id = 8 },
    new MunicipalitiesCatalog { Name = "Paraíso de Osorio", Code = "0806", Department_Id = 8 },
    new MunicipalitiesCatalog { Name = "San Antonio Masahuat", Code = "0807", Department_Id = 8 },
    new MunicipalitiesCatalog { Name = "San Emigdio", Code = "0808", Department_Id = 8 },
    new MunicipalitiesCatalog { Name = "San Francisco Chinameca", Code = "0809", Department_Id = 8 },
    new MunicipalitiesCatalog { Name = "San Pedro Masahuat", Code = "0810", Department_Id = 8 },
    new MunicipalitiesCatalog { Name = "San Pedro Nonualco", Code = "0811", Department_Id = 8 },
    new MunicipalitiesCatalog { Name = "San Rafael Obrajuelo", Code = "0812", Department_Id = 8 },
    new MunicipalitiesCatalog { Name = "Santa María Ostuma", Code = "0813", Department_Id = 8 },
    new MunicipalitiesCatalog { Name = "Santiago Nonualco", Code = "0814", Department_Id = 8 },
    new MunicipalitiesCatalog { Name = "Tapalhuaca", Code = "0815", Department_Id = 8 },
    new MunicipalitiesCatalog { Name = "Zacatecoluca", Code = "0816", Department_Id = 8 }
};

                    // Cabañas (ID: 9)
                    var cabanasMunicipalities = new List<MunicipalitiesCatalog>
                        {
                            new MunicipalitiesCatalog { Name = "Sensuntepeque", Code = "0901", Department_Id = 9 },
                            new MunicipalitiesCatalog { Name = "Cinquera", Code = "0902", Department_Id = 9 },
                            new MunicipalitiesCatalog { Name = "Dolores", Code = "0903", Department_Id = 9 },
                            new MunicipalitiesCatalog { Name = "Guacotecti", Code = "0904", Department_Id = 9 },
                            new MunicipalitiesCatalog { Name = "Ilobasco", Code = "0905", Department_Id = 9 },
                            new MunicipalitiesCatalog { Name = "Jutiapa", Code = "0906", Department_Id = 9 },
                            new MunicipalitiesCatalog { Name = "San Isidro", Code = "0907", Department_Id = 9 },
                            new MunicipalitiesCatalog { Name = "Tejutepeque", Code = "0908", Department_Id = 9 },
                            new MunicipalitiesCatalog { Name = "Victoria", Code = "0909", Department_Id = 9 }
                        };

                    // San Vicente (ID: 10)
                    var sanVicenteMunicipalities = new List<MunicipalitiesCatalog>
                        {
                            new MunicipalitiesCatalog { Name = "San Vicente", Code = "1001", Department_Id = 10 },
                            new MunicipalitiesCatalog { Name = "Apastepeque", Code = "1002", Department_Id = 10 },
                            new MunicipalitiesCatalog { Name = "Guadalupe", Code = "1003", Department_Id = 10 },
                            new MunicipalitiesCatalog { Name = "San Cayetano Istepeque", Code = "1004", Department_Id = 10 },
                            new MunicipalitiesCatalog { Name = "San Esteban Catarina", Code = "1005", Department_Id = 10 },
                            new MunicipalitiesCatalog { Name = "San Ildefonso", Code = "1006", Department_Id = 10 },
                            new MunicipalitiesCatalog { Name = "San Lorenzo", Code = "1007", Department_Id = 10 },
                            new MunicipalitiesCatalog { Name = "San Sebastián", Code = "1008", Department_Id = 10 },
                            new MunicipalitiesCatalog { Name = "Santa Clara", Code = "1009", Department_Id = 10 },
                            new MunicipalitiesCatalog { Name = "Santo Domingo", Code = "1010", Department_Id = 10 },
                            new MunicipalitiesCatalog { Name = "Tecoluca", Code = "1011", Department_Id = 10 },
                            new MunicipalitiesCatalog { Name = "Tepetitán", Code = "1012", Department_Id = 10 },
                            new MunicipalitiesCatalog { Name = "Verapaz", Code = "1013", Department_Id = 10 }
                        };

                    // Agregar todos los municipios al contexto
                    context.AddRange(ahuachapanMunicipalities);
                    context.AddRange(santaAnaMunicipalities);
                    context.AddRange(sonsonateMunicipalities);
                    context.AddRange(chalatenangoMunicipalities);
                    context.AddRange(laLibertadMunicipalities);
                    context.AddRange(sanSalvadorMunicipalities);
                    context.AddRange(cuscatlanMunicipalities);
                    context.AddRange(laPazMunicipalities);
                    context.AddRange(cabanasMunicipalities);
                    context.AddRange(sanVicenteMunicipalities);

                    // Guardar cambios en la base de datos
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    // Es útil para depuración registrar cualquier error que ocurra
                    var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<XtremeContext>>();
                    logger.LogError(ex, "Error al inicializar datos de municipios.");
                }
            }
        }
    }
}
