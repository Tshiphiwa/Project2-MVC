using System;
using System.Collections.Generic;

namespace DimensionData.Models
{
    public partial class EmployeePerformance
    {
        public int PerformanceId { get; set; }
        public int? PerformanceRating { get; set; }
        public string WorkLifeBalance { get; set; }
        public int? JobInvolvement { get; set; }
    }
}
