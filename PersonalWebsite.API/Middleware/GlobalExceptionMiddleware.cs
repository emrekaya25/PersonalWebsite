using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using PersonalWebsite.Entity.CustomException;
using PersonalWebsite.Entity.Result;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace PersonalWebsite.API.Middleware
{
	// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
	public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {

                if (e.GetType()==typeof(FieldValidationException))
                {
                    List<string> errors = new();
                       errors = e.Data["FieldValidationMessage"] as List<string>;

                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsJsonAsync(ApiResponse<FieldValidationException>.FieldValidationError(errors), new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = null
                    });


                }


            }


            
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class GlobalExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}
