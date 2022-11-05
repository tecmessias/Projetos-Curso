using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaMVCEF
{
    public class LeitorService
    {
        public RepositoryLeitor oRepositoryLeitor { get; set; }

        public LeitorService()
        {
            oRepositoryLeitor = new RepositoryLeitor();
        }
    }
}
