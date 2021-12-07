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
    public class BlindBLL : IRepository<Blinds>
    {
        private BlindDAL dal = new BlindDAL();
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        public bool Delete(Blinds model)
        {
            throw new NotImplementedException();
        }

        public decimal GetPrice(int blindId)
        {
            return dal.GetPrice(blindId);
        }
        public Blinds Get(int id)
        {
            return dal.Get(id);
        }

        public Blinds Get(Blinds model)
        {
            throw new NotImplementedException();
        }

        public List<Blinds> GetAll()
        {
            return dal.GetAll();
        }

        public bool Insert(Blinds model)
        {
            return dal.Insert(model);
        }

        public bool Update(Blinds model)
        {
            return dal.Update(model);
        }
    }
}
