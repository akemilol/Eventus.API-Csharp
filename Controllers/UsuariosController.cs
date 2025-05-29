using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Eventus.API.Infrastructure.Context;
using Eventus.API.Domain.Entities;
using Eventus.API.Application.Dtos;
using BCrypt.Net;

namespace Eventus.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly EventusDbContext _context;
        public UsuariosController(EventusDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            var result = usuarios.Select(u => new UsuarioDto
            {
                Id = u.Id,
                Nome = u.Nome,
                Email = u.Email,
                CPF = u.CPF,
                CEP = u.CEP,
                DataNascimento = u.DataNascimento.ToString("dd/MM/yyyy")
            }).ToList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();
            var usuarioDto = new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                CPF = usuario.CPF,
                CEP = usuario.CEP,
                DataNascimento = usuario.DataNascimento.ToString("dd/MM/yyyy")
            };
            return Ok(usuarioDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioCreateDto dto)
        {
            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = BCrypt.Net.BCrypt.HashPassword(dto.Senha),
                CPF = dto.CPF,
                CEP = dto.CEP,
                DataNascimento = dto.DataNascimento
            };
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            var usuarioDto = new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                CPF = usuario.CPF,
                CEP = usuario.CEP,
                DataNascimento = usuario.DataNascimento.ToString("dd/MM/yyyy")
            };
            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuarioDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UsuarioCreateDto dto)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();

            usuario.Nome = dto.Nome;
            usuario.Email = dto.Email;
            if (!string.IsNullOrWhiteSpace(dto.Senha))
                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(dto.Senha);
            usuario.CPF = dto.CPF;
            usuario.CEP = dto.CEP;
            usuario.DataNascimento = dto.DataNascimento;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return NotFound();
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginDto dto)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (usuario == null || !BCrypt.Net.BCrypt.Verify(dto.Senha, usuario.Senha))
                return Unauthorized(new { message = "E-mail ou senha inválidos!" });

            var usuarioDto = new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                CPF = usuario.CPF,
                CEP = usuario.CEP,
                DataNascimento = usuario.DataNascimento.ToString("dd/MM/yyyy")
            };
            return Ok(usuarioDto);
        }
    }
}
