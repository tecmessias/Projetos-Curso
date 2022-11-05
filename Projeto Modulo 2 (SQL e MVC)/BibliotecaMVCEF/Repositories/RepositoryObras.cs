using BibliotecaMVCEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaMVCEF
{
    public class RepositoryObras : RepositoryBase<Obras>, IRepositoryObras
    {
        public RepositoryObras(bool SaveChanges = true) : base(SaveChanges)
        {

        }
    }
}
