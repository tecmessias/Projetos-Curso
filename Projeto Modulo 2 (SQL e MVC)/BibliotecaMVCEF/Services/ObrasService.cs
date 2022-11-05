using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaMVCEF
{
    public class ObrasService
    {
        public RepositoryObras oRepositoryObras { get; set; }

        public ObrasService()
        {
            oRepositoryObras = new RepositoryObras();
        }
    }

}

