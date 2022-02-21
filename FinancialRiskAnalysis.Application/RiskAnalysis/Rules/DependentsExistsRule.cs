namespace Insurance.Application.RiskAnalysis.Rules
{
    public class DependentsExistsRule : IRiskAnalysisRule
    {
        public Domain.Entities.RiskAnalysis CalculateRiskAnalisysScore(Domain.Entities.RiskAnalysis riskAnalysis)
        {
            if (riskAnalysis.Dependents > 0)
            {
                riskAnalysis.DisabilityScore += 1;
                riskAnalysis.LifeScore += 1;
            }

            return riskAnalysis;
        }
    }
}
