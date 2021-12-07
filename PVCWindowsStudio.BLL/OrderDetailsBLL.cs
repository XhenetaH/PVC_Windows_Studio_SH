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
    public class OrderDetailsBLL : IRepository<OrderDetails>
    {
        private readonly OrderDetailsDAL dal = new OrderDetailsDAL();
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }
        public bool Delete_Temporary()
        {
            return dal.Delete_Temporary();
        }
        public bool Delete(OrderDetails model)
        {
            throw new NotImplementedException();
        }

        public OrderDetails Get(int id)
        {
            throw new NotImplementedException();
        }

        public OrderDetails Get(OrderDetails model)
        {
            throw new NotImplementedException();
        }

        public List<OrderDetails> GetAll()
        {
            throw new NotImplementedException();
        }
        public List<OrderDetails> GetAll(int id)
        {
            return dal.GetAll(id);
        }
        public decimal GetPriceByDate(int month,int year)
        {
            return dal.GetPriceByDate(month,year);
        }
        public List<DateTime> GetDateChart()
        {
            return dal.GetDateChart();
        }
        public bool Insert(OrderDetails model)
        {
            return dal.Insert(model);
        }
        public bool Insert_Temporary(OrderDetails model)
        {
            return dal.Insert_Temporary(model);
        }
        public List<OrderDetails> GetAll_Temporary()
        {
            return dal.GetAll_Temporary();
        }
        public List<PriceCalculation> GetPrice(int profileId,int productId)
        {
            return dal.GetPrice(profileId, productId);
        }

        public bool Update(OrderDetails model)
        {
            return dal.Update(model);
        }
    }
}
