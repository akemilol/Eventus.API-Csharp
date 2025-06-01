using Microsoft.AspNetCore.Mvc;
using Eventus.API.Domain.Entities;
using Eventus.API.Infrastructure.Context;
using Eventus.API.Application.Dtos;


namespace Eventus.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AbrigosController : ControllerBase
    {
        private readonly EventusDbContext _context;

        public AbrigosController(EventusDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AbrigoDto>> GetAll()
        {
            var abrigos = _context.Abrigos.Select(a => new AbrigoDto
            {
                Id = a.Id,
                NomeAbrigo = a.NomeAbrigo,
                EnderecoAbrigo = a.EnderecoAbrigo,
                CepAbrigo = a.CepAbrigo,
                CidadeAbrigo = a.CidadeAbrigo,
                UfAbrigo = a.UfAbrigo,
                LatitudeAbrig = a.LatitudeAbrig,
                LongitudeAbrig = a.LongitudeAbrig
            }).ToList();
            return Ok(abrigos);
        }

        [HttpGet("{id}")]
        public ActionResult<AbrigoDto> Get(int id)
        {
            var a = _context.Abrigos.Find(id);
            if (a == null) return NotFound();
            var dto = new AbrigoDto
            {
                Id = a.Id,
                NomeAbrigo = a.NomeAbrigo,
                EnderecoAbrigo = a.EnderecoAbrigo,
                CepAbrigo = a.CepAbrigo,
                CidadeAbrigo = a.CidadeAbrigo,
                UfAbrigo = a.UfAbrigo,
                LatitudeAbrig = a.LatitudeAbrig,
                LongitudeAbrig = a.LongitudeAbrig
            };
            return Ok(dto);
        }

        [HttpPost]
        public ActionResult<AbrigoDto> Post([FromBody] AbrigoCreateDto dto)
        {
            var ab = new Abrigo
            {
                NomeAbrigo = dto.NomeAbrigo,
                EnderecoAbrigo = dto.EnderecoAbrigo,
                CepAbrigo = dto.CepAbrigo,
                CidadeAbrigo = dto.CidadeAbrigo,
                UfAbrigo = dto.UfAbrigo,
                LatitudeAbrig = dto.LatitudeAbrig,
                LongitudeAbrig = dto.LongitudeAbrig
            };
            _context.Abrigos.Add(ab);
            _context.SaveChanges();

            var retorno = new AbrigoDto
            {
                Id = ab.Id,
                NomeAbrigo = ab.NomeAbrigo,
                EnderecoAbrigo = ab.EnderecoAbrigo,
                CepAbrigo = ab.CepAbrigo,
                CidadeAbrigo = ab.CidadeAbrigo,
                UfAbrigo = ab.UfAbrigo,
                LatitudeAbrig = ab.LatitudeAbrig,
                LongitudeAbrig = ab.LongitudeAbrig
            };

            return CreatedAtAction(nameof(Get), new { id = ab.Id }, retorno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AbrigoCreateDto dto)
        {
            var ab = _context.Abrigos.Find(id);
            if (ab == null) return NotFound();

            ab.NomeAbrigo = dto.NomeAbrigo;
            ab.EnderecoAbrigo = dto.EnderecoAbrigo;
            ab.CepAbrigo = dto.CepAbrigo;
            ab.CidadeAbrigo = dto.CidadeAbrigo;
            ab.UfAbrigo = dto.UfAbrigo;
            ab.LatitudeAbrig = dto.LatitudeAbrig;
            ab.LongitudeAbrig = dto.LongitudeAbrig;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ab = _context.Abrigos.Find(id);
            if (ab == null) return NotFound();

            _context.Abrigos.Remove(ab);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
