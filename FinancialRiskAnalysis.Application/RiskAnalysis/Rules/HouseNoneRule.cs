namespace Insurance.Application.RiskAnalysis.Rules
{
    public class HouseNoneRule : IRiskAnalysisRule
    {
        public Domain.Entities.RiskAnalysis CalculateRiskAnalisysScore(Domain.Entities.RiskAnalysis riskAnalysis)
        {
            if (riskAnalysis.House is null)
                riskAnalysis.HomeProfile = "ineligigle";

            return riskAnalysis;
        }
    }
}
