using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class RepositoryContection
    {
        public IConfiguration _Configuration;
        public RepositoryContection (IConfiguration Configuration)
        {
            _Configuration = Configuration;
        }

        public string getConnetion()
        {
            return _Configuration.GetSection("Conections").GetSection("CadImoveis").Value;
        }
    }
}
