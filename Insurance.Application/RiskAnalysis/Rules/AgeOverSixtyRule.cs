using Insurance.Domain.Enums;

namespace Insurance.Application.RiskAnalysis.Rules
{
    public class AgeOverSixtyRule : IRiskAnalysisRule
    {
        public Domain.Entities.RiskAnalysis CalculateRiskAnalisysScore(Domain.Entities.RiskAnalysis riskAnalysis)
        {
            if (riskAnalysis.Age > 60)
            {
                riskAnalysis.LifeProfile = ProfileStatus.Ineligible.Name;
                riskAnalysis.DisabilityProfile = ProfileStatus.Ineligible.Name;
            }

            return riskAnalysis;
        }
    }
}
