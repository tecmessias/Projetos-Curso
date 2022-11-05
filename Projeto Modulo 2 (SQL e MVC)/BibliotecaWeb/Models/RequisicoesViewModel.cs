using BibliotecaMVCEF.Models;

namespace BibliotecaWeb.Models
{
    public class RequisicoesViewModel
    {
        public  Leitor oLeitor { get; set; }
        public int idLeitor { get; set; }
        
        public Obras oObras { get; set; }
        public int idObras { get; set; }
        public DateTime DataRequisicao { get; set; }
        public DateTime DataDevolucao { get; set; }
        public List<Leitor> oListLeitor { get; set; }
        public List<Obras> oListObras { get; set; }
        public Obras IdObra { get; set; }
        public Leitor IdLeitor { get; set; }

        public VRequisicoesObra oVRequisicoesObra { get; set; }
        public Requisicoes oRequisicoes { get; set; }

       


    }
}
