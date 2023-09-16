using Newtonsoft.Json;
using System.Text;

namespace fiap.Middlewares
{
    public class MeuLogMiddleware
    {
        private RequestDelegate _next;

        public MeuLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task Invoke(HttpContext httpContext)
        {
            //logar a request
            var objetoASerLogado = await FormatRequest(httpContext.Request);
            
            Console.WriteLine("LOG - REQUEST");
            Console.WriteLine(objetoASerLogado);
            Console.WriteLine("LOG - REQUEST");

            httpContext.Request.Body.Position = 0;

            await _next(httpContext);
            
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            //request.EnableRewind();
            request.EnableBuffering();
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var textBody = Encoding.UTF8.GetString(buffer);

            var messageLog = new { scheme = request.Scheme, host = request.Host, body = textBody };

            
            return JsonConvert.SerializeObject(messageLog);
        }
    }



    public static class MiddlewareExtension {

        public static IApplicationBuilder UseMeuMiddlewareDaFiapCustomizado(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MeuLogMiddleware>();
        }
    }
}
