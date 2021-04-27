using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class FornecedorDB : IFornecedorDB
    {

        public List<Fornecedor> GetAll()
        {
            string sql = Fornecedor.GETALL;
            List<Fornecedor> lst;

            using (var connection = new DB())
            {
                lst = TransformSQLReaderToList(connection.ExecQueryReturn(sql));
            }
            return lst;
        }

        private List<Fornecedor> TransformSQLReaderToList(SqlDataReader returnData)
        {
            var lst = new List<Fornecedor>();

            while (returnData.Read())
            {
                var item = new Fornecedor()
                {
                    
                    Nome = returnData["nome"].ToString(),
                    Email = returnData["email"].ToString(),
                    Telefone = returnData["telefone"].ToString(),
                    Endereco = returnData["endereco"].ToString(),
                    Servico = returnData["servico"].ToString()

                };
                lst.Add(item);
            }
            return lst;
        }

        public bool Insert(Fornecedor fornecedor)
        {
            bool status = false;
            string sql = string.Format(Fornecedor.INSERT, fornecedor.Nome, fornecedor.Email, fornecedor.Telefone, fornecedor.Endereco, fornecedor.Servico);

            using (var connection = new DB())
            {
                status = connection.ExecQuery(sql);
            }
            return status;
        }

        public Fornecedor SelectById(int id)
        {
            string sql = string.Format(Fornecedor.GETBYID, id);
            Fornecedor fornecedor;

            using (var connection = new DB())
            {
                fornecedor = TransformSQLReaderToList(connection.ExecQueryReturn(sql))[0];
            }
            return fornecedor;
        }

        public bool Update(Fornecedor fornecedor)
        {
            bool status = false;
            string sql = string.Format(Fornecedor.UPDATE, fornecedor.Nome, fornecedor.Email, fornecedor.Telefone, fornecedor.Endereco, fornecedor.Servico, fornecedor.Id);

            using (var connection = new DB())
            {
                status = connection.ExecQuery(sql);
            }
            return status;
        }

        public bool Delete(int id)
        {
            bool status = false;
            string sql = string.Format(Fornecedor.DELETE, id);

            using (var connection = new DB())
            {
                status = connection.ExecQuery(sql);
            }
            return status;
        }
    }
}