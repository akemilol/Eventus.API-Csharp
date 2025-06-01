namespace Eventus.API.Application.Dtos

{
    public class AlertaDto
    {
        public int Id { get; set; }
        public string TipoAlerta { get; set; }
        public string Descricao { get; set; }
        public string CepAlerta { get; set; }
        public DateTime? DataHora { get; set; }
    }
}
