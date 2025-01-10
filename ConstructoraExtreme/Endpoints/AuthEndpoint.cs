using ConstructoraExtreme.Models.DAL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Extreme.DTOs.UserDTOs;
using ConstructoraExtreme.Models.EN;
using CRM.DTOs.UsersDTOs;
using Microsoft.AspNetCore.Mvc;

namespace ConstructoraExtreme.Endpoints
{
    public static class AuthEndpoint
    {
        public static void MapAuthEndpoints(this WebApplication app)
        {

            //CREAR
            app.MapPost("/api/auth/register", async (CreateUserDTO request, UserDAL userRepo) =>
            {
                try
                {
                    if (await userRepo.GetUserByEmailAsync(request.Email) != null)
                    {
                        return Results.BadRequest(new { message = "El email ya está registrado" });
                    }

                    var user = new User
                    {
                        Name = request.Name,
                        Email = request.Email,
                        RoleId = request.RoleId
                    };

                    await userRepo.CreateUserAsync(user, request.Password);

                    return Results.Ok(new { message = "Usuario registrado exitosamente" });
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { message = "Error al registrar usuario", error = ex.Message });
                }
            }).RequireAuthorization("AdminPolicy");

            //LOGIN
            app.MapPost("/api/auth/login", async (LoginUserDTO request, UserDAL userRepo, HttpContext context) =>
            {
                var user = await userRepo.ValidateCredentialsAsync(request.Email, request.Password);

                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim(ClaimTypes.Role, user.Role?.Name ?? "SinRol"),
                        new Claim("UserId", user.Id.ToString())
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1)
                    };

                    await context.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    var userDto = new UserLoginResponseDTO
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Email = user.Email,
                        RoleName = user.Role?.Name
                    };

                    return Results.Ok(new { message = "Login exitoso", user = userDto });
                }

                //return Results.Unauthorized();
                return Results.BadRequest(new { message = "Credenciales inválidas." });

            });

            app.MapPost("/api/auth/logout", async (HttpContext context) =>
            {
                await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return Results.Ok(new { message = "Sesión cerrada" });
            });


            // Agregar este endpoint en MapAuthEndpoints  ESTE ES DE PRUEBA, AL RATO SE ELIMINA
            app.MapGet("/api/auth/test", (HttpContext context) =>
            {
                var user = context.User;
                if (user.Identity.IsAuthenticated)
                {
                    return Results.Ok(new
                    {
                        message = "Usuario autenticado",
                        userName = user.Identity.Name,
                        role = user.FindFirst(ClaimTypes.Role)?.Value,
                        userId = user.FindFirst("UserId")?.Value,
                        claims = user.Claims.Select(c => new { c.Type, c.Value })
                    });
                }
                return Results.Unauthorized();
            }).RequireAuthorization(); // Requiere autenticación



            
        }
    }
}
