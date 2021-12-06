using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCWindowsStudio.BO
{
    public class Orders : AuditColumns
    {
        public int OrderID { get; set; }
        public int ClientID { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public decimal Discount { get; set; }
        public string DiscountType { get; set; }
        public string FullDiscount { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual Clients Clients { get; set; }
    }
}
