using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMS.ClientSide.Models
{
    public class TravelDetails
    {
        public int MRNumber { get; set; }
        public int EmployeeId { get; set; }
        [DataType(DataType.Date), Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public System.DateTime Applydate { get; set; }
        public string ReasonForTravel { get; set; }
        [DataType(DataType.Date), Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public System.DateTime TravelDate { get; set; }
        public string TravelMode { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }

        public System.TimeSpan TravelDuration { get; set; }
        public string Status { get; set; }
    }
}