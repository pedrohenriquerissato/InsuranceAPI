namespace Insurance.Application.RiskAnalysis.Rules
{
    public class AgeUnderThirtyRule : IRiskAnalysisRule
    {
        public Domain.Entities.RiskAnalysis CalculateRiskAnalisysScore(Domain.Entities.RiskAnalysis riskAnalysis)
        {
            if (riskAnalysis.Age < 30)
                riskAnalysis.SubtractFromScore(2);

            return riskAnalysis;
        }
    }
}
