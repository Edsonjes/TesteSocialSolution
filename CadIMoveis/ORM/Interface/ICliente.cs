using Domain.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Interface
{
    public interface ICliente : IRepositoryBase<Cliente>
    {
        IEnumerable<Cliente> Filter(string Cpf_Cnpj);
    }
}
