using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCWindowsStudio.BO
{
    public class Payments : AuditColumns
    {
        public int PaymentID { get; set; }
        public Clients ClientID { get; set; }
        public decimal Debt { get; set; }
        public decimal Paid { get; set; }
    }
}
