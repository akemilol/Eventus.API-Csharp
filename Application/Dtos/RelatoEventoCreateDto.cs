namespace Eventus.API.Application.Dtos
{
    public class RelatoEventoCreateDto
    {
        public int UsuarioId { get; set; }
        public string? Descricao { get; set; }
        public string? Localizacao { get; set; }
        public DateTime DataEvento { get; set; }
    }
}
