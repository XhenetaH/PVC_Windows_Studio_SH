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
    public class ClientBLL : IRepository<Clients>
    {
        private ClientDAL dal = new ClientDAL();
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        public bool Delete(Clients model)
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
        public Clients Get(int id)
        {
            return dal.Get(id);
        }
        public int GetID()
        {
            return dal.GetID();
        }
        public Clients Get(Clients model)
        {
            throw new NotImplementedException();
        }
        public List<Clients> GetName()
        {
            return dal.GetName();
        }
        public List<Clients> GetAll()
        {
            return dal.GetAll();
        }

        public bool Insert(Clients model)
        {
            return dal.Insert(model);
        }

        public bool Update(Clients model)
        {
            return dal.Update(model);
        }
    }

}
