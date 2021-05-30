using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS.ClientSide.Models
{
    public class ExpenseRejected
    {
        public int ExpenseReportId { get; set; }
        public string ReasonForRejection { get; set; }
        public DateTime RejectionDate { get; set; }
    }
}