using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCWindowsStudio.BO
{
    public class OrderDetails : AuditColumns
    {
        public int OrderDetailsID { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public int ProfileID { get; set; }
        public int BlindID { get; set; }
        public int WindowPaneID { get; set; }
        public int Quantity { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public decimal HandWorkPrice { get; set; }
        public virtual Products Product { get; set; }
        public virtual Profiles Profile { get; set; }
        public virtual Blinds Blind { get; set; }
        public virtual WindowPanes WindowPane { get; set; }
    }

}
