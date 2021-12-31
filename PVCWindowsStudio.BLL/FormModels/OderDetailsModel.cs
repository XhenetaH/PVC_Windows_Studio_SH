using PVCWindowsStudio.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCWindowsStudio.BLL.FormModels
{
    public class OderDetailsModel
    {
        public OrderBLL ordersBLL;
        public Orders order;
        public BlindBLL blindBll;
        public OrderDetailsBLL detailsBLL;
        public OrderDetails details;
        public ProfileBLL profileBll;
        public WindowPaneBLL windowpaneBll;
        public ProductBLL productBLL;
        public HandiWorkBLL handiWorkBLL;

        public OderDetailsModel()
        {
            productBLL = new ProductBLL();
            ordersBLL = new OrderBLL();
            order = new Orders();
            blindBll =new BlindBLL();
            detailsBLL = new OrderDetailsBLL();
            details = new OrderDetails();
            profileBll = new ProfileBLL();
            windowpaneBll = new WindowPaneBLL();
            handiWorkBLL = new HandiWorkBLL();

        }
    }
}
