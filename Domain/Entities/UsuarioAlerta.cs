namespace Eventus.API.Domain.Entities

{
    public class UsuarioAlerta
    {
        public int Id { get; set; }
        public int UsuarioIdUsuario { get; set; }
        public int AlertasId { get; set; }
        public DateTime? DataRecebimento { get; set; }
    }
}
