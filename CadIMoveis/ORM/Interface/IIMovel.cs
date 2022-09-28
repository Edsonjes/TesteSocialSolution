using Domain.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Interface
{
    public interface IIMovel : IRepositoryBase<Imovel>
    {
        IEnumerable<TipoImovel>GetTipoImovels();
        IEnumerable<Imovel> GetImoveisClienteByIdCliente(int IdCliente);

    }
}
