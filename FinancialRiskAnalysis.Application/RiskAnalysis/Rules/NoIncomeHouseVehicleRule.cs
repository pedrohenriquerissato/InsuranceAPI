using Insurance.Application.RiskAnalysis.Commands;

namespace Insurance.Application.RiskAnalysis.Rules
{
    public class NoIncomeHouseVehicleRule : IRiskAnalysisRule
    {
        public Domain.Entities.RiskAnalysis CalculateRiskAnalisysScore(Domain.Entities.RiskAnalysis riskAnalysis)
        {
            riskAnalysis.AutoProfile = riskAnalysis.Vehicle is null ? "ineligible" : riskAnalysis.AutoProfile;

            riskAnalysis.HomeProfile = riskAnalysis.House is null ? "ineligigle" : riskAnalysis.HomeProfile;

            riskAnalysis.DisabilityProfile = riskAnalysis.Income == 0 ? "ineligigle" : riskAnalysis.DisabilityProfile;

            return riskAnalysis;
        }
    }
}
