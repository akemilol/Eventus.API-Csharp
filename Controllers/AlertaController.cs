using Microsoft.AspNetCore.Mvc;
using Eventus.API_Csharp.Domain.Entities;
using Eventus.API_Csharp.Infrastructure.Context;
using Eventus.API_Csharp.Application.Dtos;

namespace Eventus.API_Csharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertasController : ControllerBase
    {
        private readonly EventusDbContext _context;

        public AlertasController(EventusDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AlertaDto>> GetAll()
        {
            var alertas = _context.Alertas.Select(a => new AlertaDto
            {
                Id = a.Id,
                TipoAlerta = a.TipoAlerta,
                Descricao = a.Descricao,
                CepAlerta = a.CepAlerta,
                DataHora = a.DataHora
            }).ToList();
            return Ok(alertas);
        }

        [HttpGet("{id}")]
        public ActionResult<AlertaDto> Get(int id)
        {
            var a = _context.Alertas.Find(id);
            if (a == null) return NotFound();
            var dto = new AlertaDto
            {
                Id = a.Id,
                TipoAlerta = a.TipoAlerta,
                Descricao = a.Descricao,
                CepAlerta = a.CepAlerta,
                DataHora = a.DataHora
            };
            return Ok(dto);
        }

        [HttpPost]
        public ActionResult<AlertaDto> Post([FromBody] AlertaCreateDto dto)
        {
            var alert = new Alerta
            {
                TipoAlerta = dto.TipoAlerta,
                Descricao = dto.Descricao,
                CepAlerta = dto.CepAlerta,
                DataHora = dto.DataHora
            };
            _context.Alertas.Add(alert);
            _context.SaveChanges();

            var retorno = new AlertaDto
            {
                Id = alert.Id,
                TipoAlerta = alert.TipoAlerta,
                Descricao = alert.Descricao,
                CepAlerta = alert.CepAlerta,
                DataHora = alert.DataHora
            };
            return CreatedAtAction(nameof(Get), new { id = alert.Id }, retorno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AlertaCreateDto dto)
        {
            var alert = _context.Alertas.Find(id);
            if (alert == null) return NotFound();

            alert.TipoAlerta = dto.TipoAlerta;
            alert.Descricao = dto.Descricao;
            alert.CepAlerta = dto.CepAlerta;
            alert.DataHora = dto.DataHora;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var alert = _context.Alertas.Find(id);
            if (alert == null) return NotFound();

            _context.Alertas.Remove(alert);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
