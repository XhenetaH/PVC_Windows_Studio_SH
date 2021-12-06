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
    public class ProductItemsBLL : IRepository<ProductItems>
    {
        private readonly ProductItemsDAL dal = new ProductItemsDAL();
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        public bool Delete(ProductItems model)
        {
            throw new NotImplementedException();
        }

        public ProductItems Get(int id)
        {
            return dal.Get(id);
        }

        public ProductItems Get(ProductItems model)
        {
            throw new NotImplementedException();
        }

        public List<ProductItems> GetAll()
        {
            return dal.GetAll();
        }
        public List<ProductItems> GetAll(int id)
        {
            return dal.GetAll(id);
        }
        public List<int> GetFormula()
        {
            return dal.GetFormula();
        }

        public bool Insert(ProductItems model)
        {
            return dal.Insert(model);
        }

        public bool Update(ProductItems model)
        {
            return dal.Update(model);
        }

    }

}
