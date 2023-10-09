using fiap.core.Contexts;
using fiap.core.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fiap.api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{api.version}/[controller]")]
    [ApiController]
    [EnableCors("default")]
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

        [HttpGet("")]
        public async Task<ActionResult<List<Instrumento>>> Get()
        {
            //return NotFound();

            var result = await _context.Instrumentos.Where(a => a.Removed == false).ToListAsync();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Instrumento>> Get(int Id)
        {
            var result = await _context.Instrumentos.FirstOrDefaultAsync(a => a.Id == Id && a.Removed == false);
            if (result == null)
                return NotFound();

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

        [HttpPut("{id}")]
        public async Task<ActionResult<Instrumento>> Update(int id, Instrumento model)
        {
            _context.Attach(model);
            await _context.SaveChangesAsync();
            return model;
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Instrumento>> PartialUpdate(int id, Instrumento model)
        {
            var dbModel = await _context.Instrumentos.FirstOrDefaultAsync(a => a.Id == id);
            if (model.Nome != dbModel.Nome)
            {
                dbModel.Nome = model.Nome;
            }
            await _context.SaveChangesAsync();
            return model;
        }

        [HttpDelete]
        [Route("{id}")]
        //[HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            //select top 2 => se tiver mais 1 result ele da throw exception, se tiver menos de 1 result ele da throw de uma exception
            var instrumento = await _context.Instrumentos.SingleAsync(a =>a.Id == id);

           //select top 2 => se tiver mais de 1 elemento ele da throw, se tiver menos de 1 result ele retorna null (sem dar throw)
            var instrumento2 = await _context.Instrumentos.SingleOrDefaultAsync(a => a.Id==id);

            //select top 1 => se nao tiver nenhum result ele da throw de uma ex
            var instrumento3 = await _context.Instrumentos.FirstAsync(a => a.Id == id);

            //select top 1 => se nao tiver nenhum result ele retorna null
            var instrumento4 = await _context.Instrumentos.FirstOrDefaultAsync(a => a.Id == id);


            if (instrumento == null)
                return NotFound();

            // _context.Instrumentos.Remove(instrumento);
            instrumento.Removed = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }



    }




   
}
