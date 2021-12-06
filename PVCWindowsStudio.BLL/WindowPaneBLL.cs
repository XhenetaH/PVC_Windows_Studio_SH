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
    public class WindowPaneBLL : IRepository<WindowPanes>
    {
        private WindowPaneDAL dal = new WindowPaneDAL();
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        public decimal GetPrice(int paneId)
        {
            return dal.GetPrice(paneId);
        }
        public bool Delete(WindowPanes model)
        {
            throw new NotImplementedException();
        }

        public WindowPanes Get(int id)
        {
            throw new NotImplementedException();
        }

        public WindowPanes Get(WindowPanes model)
        {
            throw new NotImplementedException();
        }

        public List<WindowPanes> GetAll()
        {
            return dal.GetAll();
        }

        public bool Insert(WindowPanes model)
        {
            return dal.Insert(model);
        }

        public bool Update(WindowPanes model)
        {
            return dal.Update(model);
        }
    }
}
