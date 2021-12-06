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
    public class ProductBLL : IRepository<Products>
    {
        private ProductDAL dal = new ProductDAL();
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        public bool Delete(Products model)
        {
            throw new NotImplementedException();
        }

        public Products Get(int id)
        {
            throw new NotImplementedException();
        }

        public int GetNr()
        {
            return dal.GetNumber();
        }
        public int GetNrByDate()
        {
            return dal.GetNumberByDate();
        }
        public Products Get(Products model)
        {
            throw new NotImplementedException();
        }
        public List<Products> GetExistProd()
        {
            return dal.GetExistProd();
        }
        public List<Products> GetExistProdByColor(string color)
        {
            return dal.GetExistProdByColor(color);
        }
        public List<Products> GetAll()
        {
            return dal.GetAll();
        }

        public bool Insert(Products model)
        {
            return dal.Insert(model);
        }

        public bool Update(Products model)
        {
            return dal.Update(model);
        }
    }
}
