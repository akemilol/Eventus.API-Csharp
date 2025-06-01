using Microsoft.AspNetCore.Mvc;
using Eventus.API_Csharp.Domain.Entities;
using Eventus.API_Csharp.Infrastructure.Context;
using Eventus.API_Csharp.Application.Dtos;


namespace Eventus.API_Csharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioAlertasController : ControllerBase
    {
        private readonly EventusDbContext _context;

        public UsuarioAlertasController(EventusDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UsuarioAlertaDto>> GetAll()
        {
            var items = _context.UsuarioAlertas.Select(a => new UsuarioAlertaDto
            {
                Id = a.Id,
                UsuarioIdUsuario = a.UsuarioIdUsuario,
                AlertasId = a.AlertasId,
                DataRecebimento = a.DataRecebimento
            }).ToList();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public ActionResult<UsuarioAlertaDto> Get(int id)
        {
            var a = _context.UsuarioAlertas.Find(id);
            if (a == null) return NotFound();
            var dto = new UsuarioAlertaDto
            {
                Id = a.Id,
                UsuarioIdUsuario = a.UsuarioIdUsuario,
                AlertasId = a.AlertasId,
                DataRecebimento = a.DataRecebimento
            };
            return Ok(dto);
        }

        [HttpPost]
        public ActionResult<UsuarioAlertaDto> Post([FromBody] UsuarioAlertaCreateDto dto)
        {
            var entity = new UsuarioAlerta
            {
                UsuarioIdUsuario = dto.UsuarioIdUsuario,
                AlertasId = dto.AlertasId,
                DataRecebimento = dto.DataRecebimento
            };
            _context.UsuarioAlertas.Add(entity);
            _context.SaveChanges();

            var retorno = new UsuarioAlertaDto
            {
                Id = entity.Id,
                UsuarioIdUsuario = entity.UsuarioIdUsuario,
                AlertasId = entity.AlertasId,
                DataRecebimento = entity.DataRecebimento
            };

            return CreatedAtAction(nameof(Get), new { id = entity.Id }, retorno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UsuarioAlertaCreateDto dto)
        {
            var entity = _context.UsuarioAlertas.Find(id);
            if (entity == null) return NotFound();

            entity.UsuarioIdUsuario = dto.UsuarioIdUsuario;
            entity.AlertasId = dto.AlertasId;
            entity.DataRecebimento = dto.DataRecebimento;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _context.UsuarioAlertas.Find(id);
            if (entity == null) return NotFound();

            _context.UsuarioAlertas.Remove(entity);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
