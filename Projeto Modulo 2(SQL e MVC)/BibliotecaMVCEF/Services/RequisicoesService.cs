using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaMVCEF
{ 
    public class RequisicoesService
    {
        public RepositoryRequisicoes oRepositoryRequisicoes { get; set; }
               
        public RequisicoesService()
    {
        oRepositoryRequisicoes = new RepositoryRequisicoes();


            oRepositoryVRequisicoesObra = new RepositoryVRequisicoesObra();
            oRepositoryLeitor = new RepositoryLeitor();
            oRepositoryObras = new RepositoryObras();
    }




        public RepositoryVRequisicoesObra oRepositoryVRequisicoesObra { get; set; }
        public RepositoryLeitor oRepositoryLeitor { get; set; }
        public RepositoryObras oRepositoryObras { get; set; }
        



}
}
