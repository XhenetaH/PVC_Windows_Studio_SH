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
    public class ProfileBLL : IRepository<Profiles>
    {
        private ProfileDAL dal = new ProfileDAL();
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        public bool Delete(Profiles model)
        {
            throw new NotImplementedException();
        }

        public Profiles Get(int id)
        {
            return dal.Get(id);
        }

        public List<String> GetColor()
        {
            return dal.GetColors();
        }
        public Profiles Get(Profiles model)
        {
            throw new NotImplementedException();
        }
        public List<Profiles> Get()
        {
            return dal.Get();
        }
        public List<Profiles> GetAll()
        {
            return dal.GetAll();
        }
        public List<Profiles> GetExistProfile()
        {
            return dal.GetExistProfile();
        }
        public bool Insert(Profiles model)
        {
            return dal.Insert(model);
        }

        public bool Update(Profiles model)
        {
            return dal.Update(model);
        }
    }
}
