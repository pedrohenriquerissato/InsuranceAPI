namespace Insurance.Application.RiskAnalysis.Rules
{
    public class IncomeOver200KRule : IRiskAnalysisRule
    {
        public Domain.Entities.RiskAnalysis CalculateRiskAnalisysScore(Domain.Entities.RiskAnalysis riskAnalysis)
        {
            if (riskAnalysis.Income > 200000)
            {
                riskAnalysis.AutoScore -= 1;
                riskAnalysis.LifeScore -= 1;
                riskAnalysis.HomeScore -= 1;
                riskAnalysis.DisabilityScore -= 1;
            }

            return riskAnalysis;
        }
    }
}
