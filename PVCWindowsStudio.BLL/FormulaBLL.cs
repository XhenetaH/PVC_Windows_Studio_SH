using PVCWindowsStudio.BO;
using PVCWindowsStudio.BO.Interfaces;
using PVCWindowsStudio.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCWindowsStudio.BLL
{
    public class FormulaBLL : IRepository<Formula>
    {
        readonly FormulaDAL dal = new FormulaDAL();
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        public bool Delete(Formula model)
        {
            throw new NotImplementedException();
        }

        public Formula Get(int id)
        {
            throw new NotImplementedException();
        }

        public Formula Get(Formula model)
        {
            throw new NotImplementedException();
        }

        public List<Formula> GetAll()
        {
            return dal.GetAll();
        }

        public bool Insert(Formula model)
        {
            return dal.Insert(model);
        }

        public bool Update(Formula model)
        {
            return dal.Update(model);
        }
    }

}
