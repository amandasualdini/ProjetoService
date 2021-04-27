using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class AgendaDB : IAgendaDB
    {

        public List<Agenda> GetAll()
        {
            string sql = Agenda.GETALL;
            List<Agenda> lst;

            using (var connection = new DB())
            {
                lst = TransformSQLReaderToList(connection.ExecQueryReturn(sql));
            }
            return lst;
        }

        private List<Agenda> TransformSQLReaderToList(SqlDataReader returnData)
        {
            var lst = new List<Agenda>();

            while (returnData.Read())
            {
                var item = new Agenda()
                {
                    
                    Cliente = returnData["cliente"].ToString(),
                    Horario = returnData["horario"].ToString()

                };
                lst.Add(item);
            }
            return lst;
        }

        public bool Insert(Agenda agenda)
        {
            bool status = false;
            string sql = string.Format(Agenda.INSERT, agenda.Cliente, agenda.Horario);

            using (var connection = new DB())
            {
                status = connection.ExecQuery(sql);
            }
            return status;
        }

        public Agenda SelectById(int id)
        {
            string sql = string.Format(Agenda.GETBYID, id);
            Agenda agenda;

            using (var connection = new DB())
            {
                agenda = TransformSQLReaderToList(connection.ExecQueryReturn(sql))[0];
            }
            return agenda;
        }

        public bool Update(Agenda agenda)
        {
            bool status = false;
            string sql = string.Format(Agenda.UPDATE, agenda.Cliente, agenda.Horario, agenda.Id);

            using (var connection = new DB())
            {
                status = connection.ExecQuery(sql);
            }
            return status;
        }

        public bool Delete(int id)
        {
            bool status = false;
            string sql = string.Format(Agenda.DELETE, id);

            using (var connection = new DB())
            {
                status = connection.ExecQuery(sql);
            }
            return status;
        }
    }
}