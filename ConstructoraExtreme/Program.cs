using ConstructoraExtreme.Endpoints;
using ConstructoraExtreme.Models.DAL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
//Generador de departamentos
using ConstructoraExtreme.DeparmentGenerator.GeneratorExtensions;
//Generador de municipios
using ConstructoraExtreme.MunicipalGenerator.MunicipalGeneratorExtencions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("cookieAuth", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Cookie,
        Name = "Cookie",
        Description = "Autenticación con cookies"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "cookieAuth"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddDbContext<XtremeContext>(options=> 
options.UseSqlServer(builder.Configuration.GetConnectionString("cnn")));
builder.Services.AddScoped<UserDAL>();
builder.Services.AddScoped<RoleDAL>();
builder.Services.AddScoped<DepartmentsCatalogDAL>();
builder.Services.AddScoped<StoreDAL>();
builder.Services.AddScoped<ProductsDAL>();
builder.Services.AddScoped<PersonsDAL>();
builder.Services.AddScoped<PersonReferencesDAL>();
builder.Services.AddScoped<CategoryDAL>();

// Configuración Autenticación
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => {
        options.ExpireTimeSpan = TimeSpan.FromHours(1);
        options.SlidingExpiration = true;
        //options.LoginPath = "/api/auth/unauthorized";
        options.LoginPath = "/api/auth/login";
        options.LogoutPath = "/api/auth/logout";
        // Aquí agregas las configuraciones de eventos
        options.Events = new CookieAuthenticationEvents
        {
            OnRedirectToLogin = context =>
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";
                return context.Response.WriteAsync("{\"message\": \"No autorizado. Se requiere autenticación.\"}");
            },
            OnRedirectToAccessDenied = context =>
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                context.Response.ContentType = "application/json";
                return context.Response.WriteAsync("{\"message\": \"Acceso denegado. Se necesitan permisos de Admin.\"}");
            }
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
        policy.RequireRole("Admin"));
    options.AddPolicy("ViewerPolicy", policy => 
    policy.RequireRole("Viewer"));
});
builder.Services.AddControllers();

var app = builder.Build();
app.UseDepartmentsGenerator(); // Esto ejecutará la inicialización de datos una sola vez al iniciar la aplicación
app.UseMunicipalitiesGenerator();// Esto ejecutará la inicialización de datos una sola vez al iniciar la aplicación

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapAuthEndpoints();
app.MapRoleEndpoints();
app.MapDepartmentEndpoint();
app.MapStoreEndpoints();
app.MapProductEndpoints();
app.MapControllers();
app.MapPersonsEndpoint();
app.MapPersonReferencesEndpoint();
app.MapCategoryEndpoints();

app.Run();

