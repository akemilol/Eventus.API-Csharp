using System;

namespace Eventus.API.Domain.Entities
{
    public class RelatoEvento
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Descricao { get; set; }
        public string Localizacao { get; set; }
        public DateTime DataEvento { get; set; }
        public Usuario Usuario { get; set; }
    }
}
