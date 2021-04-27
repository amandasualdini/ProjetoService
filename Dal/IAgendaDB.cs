using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public interface IAgendaDB
    {
        bool Insert(Agenda agenda);
        bool Update(Agenda agenda);
        bool Delete(int id);
        Agenda SelectById(int id);
        List<Agenda> GetAll();
    }
}