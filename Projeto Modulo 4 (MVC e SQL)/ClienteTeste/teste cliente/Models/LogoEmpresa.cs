using System.ComponentModel.DataAnnotations.Schema;

namespace teste_cliente.Models
{
    public class LogoEmpresa
    {
        public int Id { get; set; }
        public int IdEmpresaFoto { get; set; }
        [ForeignKey("IdEmpresaFoto")]
        public virtual Empresa empresa { get; set; }
        public byte[]? Logo { get; set; }
    }
}
