namespace JobPortal_API.DTOs
{
    public class EmpresaDTO
    {
        public int IdEmpresa { get; set; }
        public string Nome { get; set; }
        public string? Localidade { get; set; }
        public string Email { get; set; }
        public int? Telefone { get; set; }
        public int? NoFuncionarios { get; set; }
        public string? ZonaAtuacao { get; set; }
        public string? LinkedIn { get; set; }
        public string? Facebook { get; set; }
    }
}
