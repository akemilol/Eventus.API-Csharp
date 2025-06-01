using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Eventus.API_Csharp.Infrastructure.Context;
using Eventus.API.Domain.Entities;
using Eventus.API.Application.Dtos;

namespace Eventus.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatosController : ControllerBase
    {
        private readonly EventusDbContext _context;
        public RelatosController(EventusDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get() =>
            Ok(await _context.Relatos.Include(r => r.Usuario).ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var relato = await _context.Relatos.Include(r => r.Usuario).FirstOrDefaultAsync(r => r.Id == id);
            if (relato == null) return NotFound();
            return Ok(relato);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RelatoEventoCreateDto dto)
        {
            var relato = new RelatoEvento
            {
                UsuarioId = dto.UsuarioId,
                Descricao = dto.Descricao,
                Localizacao = dto.Localizacao,
                DataEvento = dto.DataEvento
            };
            _context.Relatos.Add(relato);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = relato.Id }, relato);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RelatoEventoCreateDto dto)
        {
            var relato = await _context.Relatos.FindAsync(id);
            if (relato == null) return NotFound();

            relato.UsuarioId = dto.UsuarioId;
            relato.Descricao = dto.Descricao;
            relato.Localizacao = dto.Localizacao;
            relato.DataEvento = dto.DataEvento;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var relato = await _context.Relatos.FindAsync(id);
            if (relato == null) return NotFound();
            _context.Relatos.Remove(relato);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
