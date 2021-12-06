using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVCWindowsStudio.BO
{
    public class Invoices : AuditColumns
    {
        public int InvoiceID { get; set; }
        public int OrderID { get; set; }
        public virtual Orders Order { get; set; }
        public decimal Paid { get; set; }
        public decimal Debt { get; set; }
        public DateTime Date { get; set; }

    }
}
