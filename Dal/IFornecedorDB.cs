using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public interface IFornecedorDB
    {
        bool Insert(Fornecedor fornecedor);
        bool Update(Fornecedor fornecedor);
        bool Delete(int id);
        Fornecedor SelectById(int id);
        List<Fornecedor> GetAll();
    }
}