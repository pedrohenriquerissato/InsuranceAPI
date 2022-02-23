namespace Insurance.Application.RiskAnalysis.Rules
{
    public class AgeUnderThirtyRule : IRiskAnalysisRule
    {
        public Domain.Entities.RiskAnalysis CalculateRiskAnalisysScore(Domain.Entities.RiskAnalysis riskAnalysis)
        {
            if (riskAnalysis.Age < 30)
            {
                riskAnalysis.AutoScore -= 2;
                riskAnalysis.LifeScore -= 2;
                riskAnalysis.HomeScore -= 2;
                riskAnalysis.DisabilityScore -= 2;
            }

            return riskAnalysis;
        }
    }
}
