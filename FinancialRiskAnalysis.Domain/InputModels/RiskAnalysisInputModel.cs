using Insurance.Domain.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.InputModels
{
    public class RiskAnalysisInputModel
    {
        public int? Age { get; set; }
        public int? Dependents { get; set; }
        public House? House { get; set; }
        public int? Income { get; set; }
        public string MaritalStatus { get; set; }
        public int[] RiskQuestions { get; set; }
        public Vehicle? Vehicle { get; set; }
    }
}
