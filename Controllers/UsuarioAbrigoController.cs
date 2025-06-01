using Microsoft.AspNetCore.Mvc;
using Eventus.API_Csharp.Domain.Entities;
using Eventus.API_Csharp.Infrastructure.Context;
using Eventus.API_Csharp.Application.Dtos;

namespace Eventus.API_Csharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioAbrigosController : ControllerBase
    {
        private readonly EventusDbContext _context;

        public UsuarioAbrigosController(EventusDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UsuarioAbrigoDto>> GetAll()
        {
            var items = _context.UsuarioAbrigos.Select(a => new UsuarioAbrigoDto
            {
                Id = a.Id,
                UsuarioIdUsuario = a.UsuarioIdUsuario,
                AbrigosId = a.AbrigosId
            }).ToList();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public ActionResult<UsuarioAbrigoDto> Get(int id)
        {
            var a = _context.UsuarioAbrigos.Find(id);
            if (a == null) return NotFound();
            var dto = new UsuarioAbrigoDto
            {
                Id = a.Id,
                UsuarioIdUsuario = a.UsuarioIdUsuario,
                AbrigosId = a.AbrigosId
            };
            return Ok(dto);
        }

        [HttpPost]
        public ActionResult<UsuarioAbrigoDto> Post([FromBody] UsuarioAbrigoCreateDto dto)
        {
            var entity = new UsuarioAbrigo
            {
                UsuarioIdUsuario = dto.UsuarioIdUsuario,
                AbrigosId = dto.AbrigosId
            };
            _context.UsuarioAbrigos.Add(entity);
            _context.SaveChanges();

            var retorno = new UsuarioAbrigoDto
            {
                Id = entity.Id,
                UsuarioIdUsuario = entity.UsuarioIdUsuario,
                AbrigosId = entity.AbrigosId
            };

            return CreatedAtAction(nameof(Get), new { id = entity.Id }, retorno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UsuarioAbrigoCreateDto dto)
        {
            var entity = _context.UsuarioAbrigos.Find(id);
            if (entity == null) return NotFound();

            entity.UsuarioIdUsuario = dto.UsuarioIdUsuario;
            entity.AbrigosId = dto.AbrigosId;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _context.UsuarioAbrigos.Find(id);
            if (entity == null) return NotFound();

            _context.UsuarioAbrigos.Remove(entity);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
