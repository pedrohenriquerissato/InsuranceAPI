using Insurance.Domain.Enums;

namespace Insurance.Domain.Entities
{
    public class RiskAnalysis
    {
        public int Age { get; set; }
        public int Dependents { get; set; }
        public House? House { get; set; }
        public int Income { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public int[] RiskQuestions { get; set; }
        public Vehicle? Vehicle { get; set; }

        public int AutoScore { get; set; }
        public int LifeScore { get; set; }
        public int HomeScore { get; set; }
        public int DisabilityScore { get; set; }

        public string AutoProfile { get; set; }
        public string LifeProfile { get; set; }
        public string HomeProfile { get; set; }
        public string DisabilityProfile { get; set; }

        public RiskAnalysis(int[] riskQuestions)
        {
            var baseScore = riskQuestions.Sum();

            AutoScore = baseScore;
            HomeScore = baseScore;
            DisabilityScore = baseScore;
            LifeScore = baseScore;
        }
    }
}
