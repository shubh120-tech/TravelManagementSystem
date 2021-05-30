using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS.ClientSide.Models
{
    public class ExpenseDetails
    {
        public int EmployeeId { get; set; }

        public int ExpenseReportId { get; set; }
        public string ExpenseType { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int AmountSpent { get; set; }
        public string PaymentType { get; set; }
        public int MRNumber { get; set; }
        public int ReimbursementAccountNo { get; set; }
        public string ExpenseStatus { get; set; }
    }
}