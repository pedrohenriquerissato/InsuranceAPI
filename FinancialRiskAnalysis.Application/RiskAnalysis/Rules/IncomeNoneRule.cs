using Insurance.Domain.Enums;

namespace Insurance.Application.RiskAnalysis.Rules
{
    public class IncomeNoneRule : IRiskAnalysisRule
    {
        public Domain.Entities.RiskAnalysis CalculateRiskAnalisysScore(Domain.Entities.RiskAnalysis riskAnalysis)
        {
            if (riskAnalysis.Income == 0)
                riskAnalysis.DisabilityProfile = ProfileStatus.Ineligible.Name;

            return riskAnalysis;
        }
    }
}
