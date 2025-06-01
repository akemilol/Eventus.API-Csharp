namespace Eventus.API.Application.Dtos

{
    public class AbrigoCreateDto
    {
        public string NomeAbrigo { get; set; }
        public string EnderecoAbrigo { get; set; }
        public string CepAbrigo { get; set; }
        public string CidadeAbrigo { get; set; }
        public string UfAbrigo { get; set; }
        public decimal? LatitudeAbrig { get; set; }
        public decimal? LongitudeAbrig { get; set; }
    }
}
