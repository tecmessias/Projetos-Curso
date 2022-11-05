namespace BibliotecaMVCEF
{
    public class RepositoryVRequisicoesObraService
    {
        public RepositoryVRequisicoesObra oRepositoryVRequisicoesObra { get; set; }
        public RepositoryLeitor oRepositoryLeitor { get; set; }
        public RepositoryObras oRepositoryObras { get; set; }
        public RepositoryRequisicoes oRepositoryRequisicoes { get; set; }

        public RepositoryVRequisicoesObraService()
        {
            oRepositoryVRequisicoesObra = new RepositoryVRequisicoesObra();
            oRepositoryLeitor = new RepositoryLeitor ();
            oRepositoryObras = new RepositoryObras();
            oRepositoryRequisicoes = new RepositoryRequisicoes();
        }

    }
}
