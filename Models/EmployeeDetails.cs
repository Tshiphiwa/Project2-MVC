using System;
using System.Collections.Generic;

namespace DimensionData.Models
{
    public partial class EmployeeDetails
    {
        public int DetailsId { get; set; }
        public int? Age { get; set; }
        public string Attrition { get; set; }
        public string DistanceFromHome { get; set; }
        public string Over18 { get; set; }
        public int? MaritalId { get; set; }
        public int? GenderId { get; set; }
    }
}
