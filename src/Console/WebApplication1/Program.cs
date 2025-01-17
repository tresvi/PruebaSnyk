
namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", async (HttpContext context) =>
            {
                if (context.Request.Query.ContainsKey("mensaje"))
                {
                    string mensaje = context.Request.Query["mensaje"]!;
                    // 🚨 VULNERABILIDAD: Se inyecta directamente en la respuesta sin sanitizar
                    await context.Response.WriteAsync($"<html><body><h1>{mensaje}</h1></body></html>");
                }
                else
                {
                    await context.Response.WriteAsync("<html><body><h1>Ingrese un mensaje en la URL.</h1></body></html>");
                }
            });

            app.Run();
        }
    }
}
