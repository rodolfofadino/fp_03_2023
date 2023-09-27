using fiap.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace fiap.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public IActionResult Pessoa([FromBody]Pessoa model)
        {
            return Ok();
        }
        
        public IActionResult Index() {

            //return View("Pessoas");


            ViewData["Nome"] = "Rodolfo";

            ViewBag.Horario = DateTime.Now;

            //abstracao consumo de api ou db

            var pessoa = new Pessoa() { Nome="Fernando", Id=1, DataDeInicio= DateTime.Now };

            return View(pessoa);
        }
        

        public IActionResult Detalhes()
        {

            //return View("Pessoas");


            ViewData["Nome"] = "Rodolfo";

            ViewBag.Horario = DateTime.Now;

            //abstracao consumo de api ou db

            var pessoa = new Pessoa() { Nome = "Fernando", Id = 1, DataDeInicio = DateTime.Now };

            return View(pessoa);
        }








        //public string Detalhes()
        //{

        //    return "Detalhes de nos 10";
        //}


        //public Cadastro LoadPessoa()
        //{
        //    return new Cadastro() { Id = 44, Name = "Rodolfo" };
        //}
    }

    //public class Cadastro
    //{
       
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
