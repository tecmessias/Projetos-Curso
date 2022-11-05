namespace JobPortal_API.DTOs
{
    public class OfertaEmpregoDTO
    {
        public int IdOferta { get; set; }
        public int IdEmpresa { get; set; }
        public string Titulo { get; set; }
        public float? Salario { get; set; }
        public string? Jornada { get; set; }
        public string? Localização { get; set; }
        public string? RegimeTrabalho { get; set; }
        public string? TipoContrato { get; set; }
        public string? Requisitos { get; set; }
        public bool? VagaDisponivel { get; set; }
    }
}
