using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Agenda
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Horario { get; set; }
       


        public const string INSERT = "INSERT INTO TB_AGENDA (cliente, horario) VALUES ('{0}', '{1}')";
        public const string GETALL = "SELECT cliente, horario FROM TB_AGENDA";
        public const string GETBYID = "SELECT id, nome, horario FROM TB_AGENDA WHERE id = {0}";
        public const string DELETE = "DELETE FROM TB_AGENDA WHERE id = {0}";
        public const string UPDATE = "UPDATE TB_AGENDA SET cliente = '{0}', horario = '{1}' WHERE id = {2}";
    }
}
