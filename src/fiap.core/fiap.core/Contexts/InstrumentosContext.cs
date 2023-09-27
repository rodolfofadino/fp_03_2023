using fiap.core.Models;
using Microsoft.EntityFrameworkCore;

namespace fiap.core.Contexts
{

    public class InstrumentosContext : DbContext
    {

        public InstrumentosContext(DbContextOptions<InstrumentosContext> options) : base(options)
        {

        }


        public DbSet<Instrumento> Instrumentos { get; set; }
       
    }
}
