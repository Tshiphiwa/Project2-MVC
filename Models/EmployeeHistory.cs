using System;
using System.Collections.Generic;

namespace DimensionData.Models
{
    public partial class EmployeeHistory
    {
        public int HistoryId { get; set; }
        public string NumCompaniesWorked { get; set; }
        public string TotalWorkingYears { get; set; }
        public string TrainingTimesLastYear { get; set; }
        public string WorkLifeBalance { get; set; }
        public string YearsAtCompany { get; set; }
        public string YearsInCurrentRole { get; set; }
        public string YearsSinceLastPromotion { get; set; }
        public string YearsWithCurrManager { get; set; }
    }
}
