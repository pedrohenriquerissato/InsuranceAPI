using Insurance.Application.RiskAnalysis.Commands;

namespace Insurance.Application.RiskAnalysis.Rules
{
    public interface IRiskAnalysisRule
    {
        Domain.Entities.RiskAnalysis CalculateRiskAnalisysScore(Domain.Entities.RiskAnalysis riskAnalysis);
    }
}
