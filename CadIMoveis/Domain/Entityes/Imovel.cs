using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entityes
{
    public class Imovel
    {
        public int Id { get; set; }
        public int? IdTipoImovel { get; set; }
        public int? IdCliente { get; set; }
        public decimal ValorImovel { get; set; }
        public string Descricao { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public  string Localidade { get; set; }
        public string Cidade {get; set;}
        public string Uf { get; set; }
        public string Situacao { get; set; }
    }
}
