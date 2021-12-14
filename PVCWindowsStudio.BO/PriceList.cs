using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCWindowsStudio.BO
{
    public class PriceList : AuditColumns
    {
        public int PriceListID { get; set; }
        public int MaterialID { get; set; }       
        public decimal Price { get; set; }
        public virtual Materials Materials { get; set; }
        public virtual Profiles Profiles { get; set; }       
        public int ProfileID { get; set; }

    }
}
