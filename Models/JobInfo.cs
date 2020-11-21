using System;
using System.Collections.Generic;

namespace DimensionData.Models
{
    public partial class JobInfo
    {
        public int JobId { get; set; }
        public string JobRole { get; set; }
        public string Department { get; set; }
        public int? StandardHours { get; set; }
        public int? EmployeeCount { get; set; }
        public string BusinessTravel { get; set; }
    }
}
