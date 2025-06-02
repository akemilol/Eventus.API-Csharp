using System;

namespace Eventus.API.Domain.Entities
{
    public class Alerta
    {
        public int Id { get; set; }
        public string TipoAlerta { get; set; }
        public string Descricao { get; set; }
        public string CepAlerta { get; set; }
        public DateTime? DataHora { get; set; }
    }
}
