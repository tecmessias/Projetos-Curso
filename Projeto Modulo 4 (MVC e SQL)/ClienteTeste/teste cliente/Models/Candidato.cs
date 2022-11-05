using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace teste_cliente.Models
{
    public class Candidato
    {
        [Key]
        public int IdCandidato { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        public int? Telefone { get; set; }
        public string? Morada { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? DataNasc { get; set; }
        public string? LinkedIn { get; set; }
        public string? Facebook { get; set; }
        public virtual ICollection<AplicacaoTrabalho>? AplicacaoTrabalho { get; set; }
        public virtual ICollection<CV>? CV { get; set; }
        public virtual ICollection<Foto>? Foto { get; set; }
    }
}
