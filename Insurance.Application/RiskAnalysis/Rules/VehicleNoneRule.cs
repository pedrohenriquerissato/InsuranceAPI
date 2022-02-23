using Insurance.Domain.Enums;

namespace Insurance.Application.RiskAnalysis.Rules
{
    public class VehicleNoneRule : IRiskAnalysisRule
    {
        public Domain.Entities.RiskAnalysis CalculateRiskAnalisysScore(Domain.Entities.RiskAnalysis riskAnalysis)
        {
            if (riskAnalysis.Vehicle is null)
                riskAnalysis.AutoProfile = ProfileStatus.Ineligible.Name;

            return riskAnalysis;
        }
    }
}
