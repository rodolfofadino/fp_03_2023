using fiap.core.Contexts;
using fiap.core.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fiap.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentosController : Controller
    {
        private InstrumentosContext _context;

        public InstrumentosController(InstrumentosContext context)
        {
            _context = context;
        }


        ////tipo especifico
        //[HttpGet]
        //public async Task<List<Instrumento>> Get()
        //{

        //    return await  _context.Instrumentos.ToListAsync();
        //}

        ////Interface
        //[HttpGet]
        //[ProducesResponseType(200, Type = typeof(List<Instrumento>))]
        //[ProducesResponseType(400, Type = typeof(Erro))]
        //public async Task<IActionResult> Get()
        //{
        //    var result = await _context.Instrumentos.ToListAsync();


        //    return Ok( result);
        //}

        public async Task<ActionResult<List<Instrumento>>> Get()
        {
            //return NotFound();

            var result = await _context.Instrumentos.ToListAsync();
            return result;
        }

        //[HttpPost]
        //public async Task<ActionResult<Instrumento>> Create([FromBody]Instrumento model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Instrumentos.Add(model);
        //        await _context.SaveChangesAsync();

        //        return Created($"/api/instrumentos/{model.Id}", model);
        //    }

        //    return BadRequest(ModelState);
        //}


        [HttpPost]
        public async Task<ActionResult<Instrumento>> Create(Instrumento model)
        {
            _context.Instrumentos.Add(model);
            await _context.SaveChangesAsync();

            return Created($"/api/instrumentos/{model.Id}", model);
        }

    }
}
