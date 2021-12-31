using PVCWindowsStudio.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PVCWindowsStudio.Session
{
    public static class Methods
    {
       
        public static decimal CalcPrice(int productId, string width,string height, int profileId,int blindId, decimal blindPrice, decimal panePrice, int paneId, List<PriceCalculation> details,decimal handworkPrice)
        { 

            for (int i = 0; i < details.Count; i++)
            {
                if (details[i].Formula.Contains("Price"))
                {
                    details[i].Formula = details[i].Formula.Replace("Price", details[i].Price);
                }
                if (details[i].Formula.Contains("Width"))
                {
                    details[i].Formula = details[i].Formula.Replace("Width", width);
                }
                if (details[i].Formula.Contains("Height"))
                {
                    details[i].Formula = details[i].Formula.Replace("Height", height);
                }
            }
            string total = "";

            for (int i = 0; i < details.Count; i++)
            {
                total = total + "+" + details[i].Formula;
            }

            decimal price = Convert.ToDecimal(new DataTable().Compute(total, null));

            decimal width_d = Convert.ToDecimal(width);
            decimal height_d = Convert.ToDecimal(height);
            var paneprice = GetWindowPanePrice(paneId, width_d,height_d,panePrice);
            var blindprice = GetBlindPrice(blindId, width_d, height_d,blindPrice);
            var handiworkprice = HandiWorkPrice(width_d, height_d, handworkPrice);
            return Math.Round(price + paneprice + handiworkprice + blindprice);

        }

        private static decimal GetWindowPanePrice(int id, decimal width, decimal height,decimal price)
        {            
            if (price != -1)
                return (height / 100) * (width / 100) * price;
            else return 0;

        }
        private static decimal GetBlindPrice(int id, decimal width, decimal height,decimal price)
        {
            if (price != -1)
                return (height / 100) * (width / 100) * price;
            else return 0;

        }

        private static decimal HandiWorkPrice(decimal width, decimal height,decimal price)
        {
            if (price != -1)
                return price;
            else return 0;
        }
    }
}
