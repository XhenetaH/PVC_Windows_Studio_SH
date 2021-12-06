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

        private int _ProfileID;
        public int ProfileID
        {
            get
            {
                return _ProfileID;
            }
            set
            {
                if (ProfileID == 0)
                    _ProfileID = -1;
                else
                    _ProfileID = value;
            }
        }

    }
}
