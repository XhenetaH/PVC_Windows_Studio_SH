using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCWindowsStudio.BO
{
    public class ProductItems : AuditColumns
    {
        public int ProductItemsID { get; set; }
        public int ProductID { get; set; }
        public int MaterialID { get; set; }
        public int FormulaID { get; set; }
        public virtual Materials Materials { get; set; }
        public virtual Products Products { get; set; }
        public virtual Formula Formula { get; set; }

    }
}
