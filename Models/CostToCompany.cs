using System;
using System.Collections.Generic;

namespace DimensionData.Models
{
    public partial class CostToCompany
    {
        public int PayId { get; set; }
        public string HourlyRate { get; set; }
        public string MonthlyRate { get; set; }
        public string MonthlyIncome { get; set; }
        public string DailyRate { get; set; }
        public string OverTime { get; set; }
    }
}
