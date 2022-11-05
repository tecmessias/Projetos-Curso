using BibliotecaMVCEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaMVCEF
{
    public class RepositoryLeitor : RepositoryBase<Leitor>, IRepositoryLeitor
    {
        public RepositoryLeitor(bool SaveChanges = true) : base(SaveChanges)
        {

        }
    }
}
