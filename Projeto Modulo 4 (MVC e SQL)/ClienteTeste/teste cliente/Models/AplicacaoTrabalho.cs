using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace teste_cliente.Models
{
    public class AplicacaoTrabalho
    {
        [Key]
        public int IdAplicacao { get; set; }

        public int? IdOferta { get; set; }
        [ForeignKey("IdOferta")]
        public virtual OfertaEmprego OfertaEmprego { get; set; }

        public int? IdCandidato { get; set; }

        [ForeignKey("IdCandidato")]
        public virtual Candidato Candidato { get; set; }

        public DateTime DataAplicacao { get; set; } = DateTime.Now;

        public string? AplicacaoAceite { get; set; } = null;
    }
}
