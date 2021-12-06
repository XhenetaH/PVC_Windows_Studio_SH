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
    public class PriceListBLL : IRepository<PriceList>
    {
        readonly PriceListDAL dal = new PriceListDAL();
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        public bool Delete(PriceList model)
        {
            throw new NotImplementedException();
        }

        public PriceList Get(int id)
        {
            throw new NotImplementedException();
        }

        public PriceList Get(PriceList model)
        {
            throw new NotImplementedException();
        }

        public List<PriceList> GetAll()
        {
            return dal.GetAll();
        }

        public bool Insert(PriceList model)
        {
            return dal.Insert(model);
        }

        public bool Update(PriceList model)
        {
            return dal.Update(model);
        }
    }
}
