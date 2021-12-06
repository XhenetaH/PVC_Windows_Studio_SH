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
    public class InvoiceBLL : IRepository<Invoices>
    {
        private readonly InvoiceDAL dal = new InvoiceDAL();
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        public bool Delete(Invoices model)
        {
            throw new NotImplementedException();
        }

        public Invoices Get(int id)
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
        public Invoices Get(Invoices model)
        {
            throw new NotImplementedException();
        }

        public List<Invoices> GetAll()
        {
            return dal.GetAll();
        }

        public bool Insert(Invoices model)
        {
            return dal.Insert(model);
        }

        public bool Update(Invoices model)
        {
            return dal.Update(model);
        }
    }
}
