namespace Insurance.Application.RiskAnalysis.Rules
{
    public class AgeOverSixtyRule : IRiskAnalysisRule
    {
        public Domain.Entities.RiskAnalysis CalculateRiskAnalisysScore(Domain.Entities.RiskAnalysis riskAnalysis)
        {
            if (riskAnalysis.Age > 60)
            {
                riskAnalysis.LifeProfile = "ineligible";
                riskAnalysis.DisabilityProfile = "ineligible";
            }

            return riskAnalysis;
        }
    }
}
