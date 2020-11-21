using System;
using System.Collections.Generic;

namespace DimensionData.Models
{
    public partial class Employee
    {
        public int EmployeeNumber { get; set; }
        [System.ComponentModel.DisplayName("JobId")]

        public int? JobId { get; set; }
        [System.ComponentModel.DisplayName("DetailsId")]
        public int? DetailsId { get; set; }
        public int? PayId { get; set; }
        public int? EducationId { get; set; }
        public int? SurveryId { get; set; }
        public int? HistoryId { get; set; }
        public string PercentSalaryHike { get; set; }
        public int? StockOptionLevel { get; set; }
    }
}
