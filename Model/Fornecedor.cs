using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Servico { get; set; }




        public const string INSERT = "INSERT INTO TB_FORNECEDOR (nome, email, telefone, endereco, servico) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')";
        public const string GETALL = "SELECT nome, email, telefone, endereco, servico FROM TB_FORNECEDOR";
        public const string GETBYID = "SELECT nome, email, telefone, endereco, servico FROM TB_FORNECEDOR WHERE id = {0}";
        public const string DELETE = "DELETE FROM TB_FORNECEDOR WHERE id = {0}";
        public const string UPDATE = "UPDATE TB_FORNECEDOR SET nome = '{0}', email = '{1}', telefone = '{2}', endereco = '{3}',  servico = '{4}' WHERE id = {5}";
    }
}
