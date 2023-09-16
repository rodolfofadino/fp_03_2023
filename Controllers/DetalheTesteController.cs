using Microsoft.AspNetCore.Mvc;

namespace fiap.Controllers
{
    public class DetalheTesteController : Controller
    {
        

        public string Detalhes()
        {

            return "Detalhes de teste";
        }


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
