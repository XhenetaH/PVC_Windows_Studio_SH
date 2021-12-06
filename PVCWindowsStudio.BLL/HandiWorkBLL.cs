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
    public class HandiWorkBLL : IRepository<HandiWork>
    {
        private readonly HandiWorkDAL dal = new HandiWorkDAL();
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        public bool Delete(HandiWork model)
        {
            throw new NotImplementedException();
        }

        public HandiWork Get(int id)
        {
            throw new NotImplementedException();
        }

        public HandiWork Get(HandiWork model)
        {
            throw new NotImplementedException();
        }
        public decimal GetPrice(decimal width, decimal height)
        {
            return dal.GetPrice(width, height);
        }

        public decimal GetPriceByDate(int month, int year)
        {
            return dal.GetPriceByDate(month, year);
        }
        public List<HandiWork> GetAll()
        {
            return dal.GetAll();
        }

        public bool Insert(HandiWork model)
        {
            return dal.Insert(model);
        }

        public bool Update(HandiWork model)
        {
            return dal.Update(model);
        }
    }
}
