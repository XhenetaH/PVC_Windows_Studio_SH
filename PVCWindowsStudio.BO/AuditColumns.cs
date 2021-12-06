using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCWindowsStudio.BO
{
    public class AuditColumns
    {
        public int InsertBy { get; set; }
        public DateTime InsertDate { get; set; }
        public int LUB { get; set; }
        public int LUN { get; set; }

        private DateTime _LUD;

        public DateTime LUD
        {
            get
            {
                return _LUD;
            }
            set
            {
                if (LUN == 0)
                    _LUD = DateTime.MinValue;
                else
                    _LUD = value;
            }
        }

    }
}
