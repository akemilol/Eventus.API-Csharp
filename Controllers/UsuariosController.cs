using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Eventus.API.Infrastructure.Context;
using Eventus.API.Domain.Entities;
using Eventus.API.Application.Dtos;

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
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Preencha todos os campos corretamente." });

            if (dto.Nome.Trim().Length < 3 || !System.Text.RegularExpressions.Regex.IsMatch(dto.Nome, @"^[A-Za-zÀ-ÿ\s]+$"))
                return BadRequest(new { message = "Nome inválido. Digite apenas letras, no mínimo 3 caracteres." });

            var cpfNumbers = new string(dto.CPF.Where(char.IsDigit).ToArray());
            if (cpfNumbers.Length != 11)
                return BadRequest(new { message = "CPF inválido. Deve conter 11 números." });

            var cepNumbers = new string(dto.CEP.Where(char.IsDigit).ToArray());
            if (cepNumbers.Length != 8)
                return BadRequest(new { message = "CEP inválido. Deve conter 8 números." });

            if (dto.Senha.Length < 6)
                return BadRequest(new { message = "A senha deve ter pelo menos 6 caracteres." });

            if (string.IsNullOrWhiteSpace(dto.Email) || !System.Text.RegularExpressions.Regex.IsMatch(dto.Email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
                return BadRequest(new { message = "Email inválido." });

            if (await _context.Usuarios.CountAsync(u => u.Email == dto.Email) > 0)
                return BadRequest(new { message = "E-mail já cadastrado." });

            var usuario = new Usuario
            {
                Nome = dto.Nome.Trim(),
                Email = dto.Email.Trim(),
                Senha = BCrypt.Net.BCrypt.HashPassword(dto.Senha),
                CPF = cpfNumbers,
                CEP = cepNumbers,
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
