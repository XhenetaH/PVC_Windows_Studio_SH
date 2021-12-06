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
    public class MaterialBLL : IRepository<Materials>
    {
        private readonly MaterialDAL dal = new MaterialDAL();
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        public bool Delete(Materials model)
        {
            return dal.Delete(model);
        }

        public Materials Get(int id)
        {
            return dal.Get(id);
        }

        public Materials Get(Materials model)
        {
            return dal.Get(model);
        }

        public List<Materials> GetAll()
        {
            return dal.GetAll();
        }

        public List<Materials> GetExist()
        {
            return dal.GetExist();
        }

        public bool Insert(Materials model)
        {
            return dal.Insert(model);
        }

        public bool Update(Materials model)
        {
            return dal.Update(model);
        }
    }
}
