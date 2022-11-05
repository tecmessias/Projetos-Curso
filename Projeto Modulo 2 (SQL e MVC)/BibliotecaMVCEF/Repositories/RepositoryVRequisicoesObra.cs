using BibliotecaMVCEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaMVCEF
{
    public class RepositoryVRequisicoesObra : RepositoryBase<VRequisicoesObra >, IRepositoryVRequisicoesObra
    {
        public RepositoryVRequisicoesObra(bool SaveChanges = true) : base(SaveChanges)
        {

        }
    }
}
