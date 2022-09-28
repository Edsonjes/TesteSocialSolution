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
    public class ClienteRepository : RepositoryContection, ICliente
    {

        public ClienteRepository (IConfiguration config) : base(config) { }
        public void Add(Cliente Obj)
        {
            string sql = "Insert Into Cliente (Nome ,Cpf_CnpJ,Situacao) values (@Nome, @Cpf_CnpJ, @Situacao) ";
            using (var con  = new SqlConnection(base.getConnetion()))
            {
                con.Execute(sql, Obj);
            }
        }

        public Cliente GetById(int Id)
        {
            string sql = $"Select * from Cliente  where Id  = {Id}";
            using (var con = new SqlConnection(base.getConnetion()))
            {
                return con.Query<Cliente>(sql).FirstOrDefault();
            }
        }

        public IEnumerable<Cliente> GetAll()
        {
            IEnumerable<Cliente> Retorno;
            string sql = "Select * from Cliente";
            using(var con = new SqlConnection(base.getConnetion()))
            {
                Retorno = con.Query<Cliente>(sql);
            }
            return Retorno;
        }

        public void Remove(Cliente Obj)
        {
            string sql = $"Update Cliente Set Situacao = @Situacao where Id = {Obj.Id}";
            using (var con = new SqlConnection(base.getConnetion()))
            {
                con.Execute(sql, Obj);
            }
        }

        public void Update(Cliente Obj)
        {
            string sql = $"Update Cliente Set Nome = @Nome , Cpf_Cnpj = @Cpf_Cnpj , Situacao = @Situacao where Id = {Obj.Id}";
            using (var con = new SqlConnection(getConnetion()))
            {
                con.Execute(sql, Obj);
            }
        }

        public IEnumerable<Cliente> Filter(string Cpf_Cnpj)
        {
            IEnumerable<Cliente> retorno;
            string sql = $"Select * from Cliente where Cpf_Cnpj = @Cpf_Cnpj";
            using (var con = new SqlConnection(getConnetion()))
            {
                retorno = con.Query<Cliente>(sql, new {Cpf_Cnpj});
            }
            return retorno;

        }
    }
}
