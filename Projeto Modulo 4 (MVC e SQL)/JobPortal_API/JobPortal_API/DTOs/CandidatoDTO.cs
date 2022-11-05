using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal_API.DTOs
{
    public class CandidatoDTO
    {
        public int IdCandidato { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int? Telefone { get; set; }
        public string? Morada { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? DataNasc { get; set; }
        public string? LinkedIn { get; set; }
        public string? Facebook { get; set; }
    }
}
