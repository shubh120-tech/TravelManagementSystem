using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS.Client.Models
{
    public class ExpenseAndResponse
    {
       

        public int ExpenseReportId { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int AmountSpent { get; set; }
        public int MRNumber { get; set; }
        public string ExpenseStatus { get; set; }
        public string ReasonForRejection { get; set; }
        public DateTime RejectionDate { get; set; }
        
        public int AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }

    }
}