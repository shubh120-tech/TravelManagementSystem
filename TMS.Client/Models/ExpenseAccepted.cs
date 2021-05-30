using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS.ClientSide.Models
{
    public class ExpenseAccepted
    {
        public int ExpenseReportId { get; set; }
        public int AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}