using PVCWindowsStudio.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCWindowsStudio.BLL.FormModels
{
    public class CalculatorModel
    {
        public Clients client;
        public ClientBLL clientBll;
        public OrderDetails details;
        public OrderDetailsBLL detailsBll;
        public Orders order;
        public OrderBLL orderBll;
        public ProductBLL productBll;
        public ProfileBLL profileBll;
        public BlindBLL blindBll;
        public WindowPaneBLL windowpaneBll;
        public HandiWorkBLL workBll;

        public CalculatorModel()
        {
            workBll = new HandiWorkBLL();
            order = new Orders();
            orderBll = new OrderBLL();
            client = new Clients();
            clientBll = new ClientBLL();
            details = new OrderDetails();
            detailsBll = new OrderDetailsBLL();
            productBll = new ProductBLL();
            profileBll = new ProfileBLL();
            blindBll = new BlindBLL();
            windowpaneBll = new WindowPaneBLL();

        }
    }
}
