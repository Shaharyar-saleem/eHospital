using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eHospital.Models
{
    public class Filter
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? Department { get; set; }
        public int? Doctor { get; set; }

    }
}