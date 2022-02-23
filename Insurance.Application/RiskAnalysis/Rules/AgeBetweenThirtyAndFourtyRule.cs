namespace Insurance.Application.RiskAnalysis.Rules
{
    public class AgeBetweenThirtyAndFourtyRule : IRiskAnalysisRule
    {
        public Domain.Entities.RiskAnalysis CalculateRiskAnalisysScore(Domain.Entities.RiskAnalysis riskAnalysis)
        {
            if (riskAnalysis.Age >= 30 && riskAnalysis.Age <= 40)
            {
                riskAnalysis.AutoScore -= 1;
                riskAnalysis.HomeScore -= 1;
                riskAnalysis.LifeScore -= 1;
                riskAnalysis.DisabilityScore -= 1;
            }

            return riskAnalysis;
        }
    }
}
