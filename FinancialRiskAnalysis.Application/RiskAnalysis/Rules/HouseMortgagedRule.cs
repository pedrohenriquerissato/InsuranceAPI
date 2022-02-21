using Insurance.Domain.Enums;

namespace Insurance.Application.RiskAnalysis.Rules
{
    public class HouseMortgagedRule : IRiskAnalysisRule
    {
        public Domain.Entities.RiskAnalysis CalculateRiskAnalisysScore(Domain.Entities.RiskAnalysis riskAnalysis)
        {
            //if (model.House?.OwnershipStatus == OwnershipStatus.Mortgaged)
            //{
            //    riskAnalysis.HomeScore += 1;
            //    riskAnalysis.DisabilityScore += 1;
            //}

            return riskAnalysis;
        }
    }
}
