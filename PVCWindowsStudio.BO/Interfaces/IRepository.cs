using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCWindowsStudio.BO.Interfaces
{
    public interface IRepository<T>
    {
        bool Insert(T model);
        bool Update(T model);
        bool Delete(int id);
        bool Delete(T model);
        T Get(int id);
        T Get(T model);
        List<T> GetAll();
       
    }
}
