using System.ComponentModel.DataAnnotations;

namespace fiap.Models
{
    public class Instrumento
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Insira o nome do instrumento")]
        public string Nome { get; set; }

        //[EmailAddress]
        public string? Marca { get; set; }
        public string? Categoria { get; set; }
        public decimal Preco{ get; set; }
        public string Cor { get; set; }
        
        public bool Removed { get; set; }
    }
}
