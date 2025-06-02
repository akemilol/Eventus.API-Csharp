using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Eventus.API.Domain.Entities;
using Eventus.API.Application.Dtos;
using Eventus.API.Infrastructure.Context;

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
        public async Task<IActionResult> Get()
        {
            var relatos = await _context.Relatos.ToListAsync();

            var dtos = relatos.Select(relato => new RelatoEventoCreateDto
            {
                Id = relato.Id,
                UsuarioId = relato.UsuarioId,
                Descricao = relato.Descricao,
                Localizacao = relato.Localizacao,
                DataEvento = relato.DataEvento
            }).ToList();

            return Ok(dtos);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var relato = await _context.Relatos.FindAsync(id);
            if (relato == null) return NotFound();

            var dto = new RelatoEventoCreateDto
            {
                Id = relato.Id,
                UsuarioId = relato.UsuarioId,
                Descricao = relato.Descricao,
                Localizacao = relato.Localizacao,
                DataEvento = relato.DataEvento
            };

            return Ok(dto);
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

            dto.Id = relato.Id; 

            return CreatedAtAction(nameof(GetById), new { id = relato.Id }, dto);
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
