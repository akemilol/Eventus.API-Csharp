using Microsoft.AspNetCore.Mvc.RazorPages;
using Eventus.API.Domain.Entities;
using Eventus.API.Infrastructure.Context;

public class UsuariosModel : PageModel
{
    private readonly EventusDbContext _context;
    public List<Usuario> Usuarios { get; set; } = new();

    public UsuariosModel(EventusDbContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
        Usuarios = _context.Usuarios.ToList();
    }
}
