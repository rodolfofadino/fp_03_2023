using Microsoft.AspNetCore.Mvc;

namespace fiap.ViewComponents
{

    public class NoticiasViewComponent : ViewComponent
    {
        public NoticiasViewComponent()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync(int total, bool noticiasUrgentes, string categoria)
        {
            var noticias = Load(total);

            var viewName = "noticias";
            if (noticiasUrgentes)
                viewName = "noticiasUrgentes";
           
            
            return View(viewName, noticias);

            
        }

        private IEnumerable<Noticia> Load(int total)
        {
            for (int i = 0; i < total; i++)
            {
                yield return new Noticia() { Id = i + 1, Titulo = $"Noticia sobre {i + 1}", Link = "https://globo.com", Imagem = "https://s2-home-globo.glbimg.com/OkISFLTxyHbeqixeUPoOlRMMeB8=/133x295:1401x1009/fit-in/515x290/middle/smart/filters:strip_icc():strip_exif():format(webp)/i.s3.glbimg.com/v1/AUTH_bc8228b6673f488aa253bbcb03c80ec5/internal_photos/bs/2023/N/G/dM9465TlaaWkA1nYB1ag/whatsapp-image-2023-09-16-at-05.14.05.jpeg" };
            }
        }
    }

    public class Noticia
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Link { get; set; }
        public string Imagem { get; set; }
    }
}
