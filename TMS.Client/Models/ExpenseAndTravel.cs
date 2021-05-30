using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS.ClientSide.Models;

namespace TMS.Client.Models
{
    public class ExpenseAndTravel
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