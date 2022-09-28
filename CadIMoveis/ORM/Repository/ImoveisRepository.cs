using Dapper;
using Domain.Entityes;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ORM.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Repository
{
    public class ImoveisRepository : RepositoryContection, IIMovel
    {
        public ImoveisRepository(IConfiguration config) : base(config) { }
        public void Add(Imovel Obj)
        {
             string sql = "Insert Into Imoveis (IdTipoImovel,ValorImovel,Descricao,Cep,Logradouro,Complemento,Bairro,Localidade,Uf,IdCliente,Situacao,Cidade ) values (@IdTipoImovel,@ValorImovel,@Descricao,@Cep,@Logradouro,@Complemento,@Bairro,@Localidade,@Uf,@IdCliente,@Situacao,@Cidade) ";
            using (var con  = new SqlConnection(base.getConnetion()))
            {
                con.Execute(sql, Obj);
            }
        }

        public IEnumerable<Imovel> GetAll()
        {
             IEnumerable<Imovel> Retorno;
            string sql = "Select * from Imoveis";
            using(var con = new SqlConnection(base.getConnetion()))
            {
                Retorno = con.Query<Imovel>(sql);
            }
            return Retorno;
        }

        public Imovel GetById(int Id)
        {
            string sql = $"Select * from Imoveis  where Id  = {Id}";
            using (var con = new SqlConnection(base.getConnetion()))
            {
                return con.Query<Imovel>(sql).FirstOrDefault();
            }
        }

        public IEnumerable<Imovel> GetImoveisClienteByIdCliente(int IdCliente)
        {
            IEnumerable<Imovel> retorno;
            string sql = $"Select * From Imoveis where IdCliente = {IdCliente}";
            using(var con = new SqlConnection(base.getConnetion()))
            {
                retorno = con.Query<Imovel>(sql);
            }
            return retorno;

        }

        public IEnumerable<TipoImovel> GetTipoImovels()
        {
            IEnumerable<TipoImovel> Retorno;
            string Sql = "Select * from TipoImovel";
            using(var con = new SqlConnection(getConnetion()))
            {
                Retorno = con.Query<TipoImovel>(Sql);

            }
            return Retorno;
        }

        public void Remove(Imovel Obj)
        {
            string sql = $"Update Imoveis Set Situacao = @Situacao where Id = {Obj.Id}";
            using (var con = new SqlConnection(base.getConnetion()))
            {
                con.Execute(sql, Obj);
            }
        }

        public void Update(Imovel Obj)
        {
            string sql = $"Update Imoveis Set IdTipoImovel = @IdTipoImovel , ValorImovel = @ValorImovel ,Descricao=@Descricao,Cep = @Cep, Logradouro=@Logradouro,Complemento=@Complemento,Bairro=@Bairro,Localidade=@Localidade,Uf=@Uf,IdCliente=@IdCliente, Situacao = @Situacao, Cidade=@Cidade where Id = {Obj.Id}";
            using (var con = new SqlConnection(getConnetion()))
            {
                con.Execute(sql, Obj);
            }
        }
    }
}
