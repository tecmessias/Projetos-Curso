using BibliotecaMVCEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaMVCEF
{
    public class RepositoryRequisicoes : RepositoryBase<Requisicoes>, IRepositoryRequisicoes
    {
        public RepositoryRequisicoes(bool SaveChanges = true) : base(SaveChanges)
        {

        }
    }
}
