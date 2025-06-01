using Microsoft.AspNetCore.Mvc.RazorPages;
using Eventus.API_Csharp.Domain.Entities;
using Eventus.API_Csharp.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;
using Eventus.API.Domain.Entities;

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
