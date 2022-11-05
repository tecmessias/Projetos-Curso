namespace JobPortal_API.DTOs
{
    public class CVDTO
    {
        public int IdCV { get; set; }
        public string Nome { get; set; }
        public string Localizacao { get; set; }
        public string? Educacao { get; set; }
        public string? ExpProfissional { get; set; }
        public string? Competencias { get; set; }
        public string? Interesses { get; set; }
        public int IdCandidatoCv { get; set; }
    }
}
