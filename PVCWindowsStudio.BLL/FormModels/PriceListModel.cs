using PVCWindowsStudio.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCWindowsStudio.BLL.FormModels
{
    public class PriceListModel
    {
        public ProfileBLL profilebll;
        public MaterialBLL materialbll;
        public PriceList pricelist;
        public PriceListBLL pricelistbll;

        public PriceListModel()
        {
            profilebll = new ProfileBLL();
            materialbll = new MaterialBLL();
            pricelist = new PriceList();
            pricelistbll = new PriceListBLL();
        }
    }
}
