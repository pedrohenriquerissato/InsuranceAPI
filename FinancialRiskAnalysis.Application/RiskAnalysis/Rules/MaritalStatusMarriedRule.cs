namespace Insurance.Application.RiskAnalysis.Rules
{
    public class MaritalStatusMarriedRule : IRiskAnalysisRule
    {
        public Domain.Entities.RiskAnalysis CalculateRiskAnalisysScore(Domain.Entities.RiskAnalysis riskAnalysis)
        {
            if (riskAnalysis.MaritalStatus == Domain.Enums.MaritalStatus.Married)
            {
                riskAnalysis.LifeScore += 1;
                riskAnalysis.DisabilityScore -= 1;
            }

            return riskAnalysis;
        }
    }
}
