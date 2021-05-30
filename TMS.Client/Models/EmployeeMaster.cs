using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMS.Client.Models
{
    public class EmployeeMaster
    {
        [Display(Name ="Employee ID")]
        public int EmployeeId { get; set; }

        [Display(Name = "First Name")]
        public string EmployeeFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string EmployeeLastName { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Account Number")]
        public int ReimbursementAccountNo { get; set; }
    }
}