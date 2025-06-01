namespace Eventus.API_Csharp.Application.Dtos
{
    public class AlertaCreateDto
    {
        public string TipoAlerta { get; set; }
        public string Descricao { get; set; }
        public string CepAlerta { get; set; }
        public DateTime? DataHora { get; set; }
    }
}
