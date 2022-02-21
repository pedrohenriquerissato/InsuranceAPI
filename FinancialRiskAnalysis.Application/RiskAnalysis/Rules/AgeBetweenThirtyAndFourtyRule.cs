using Insurance.Application.RiskAnalysis.Commands;

namespace Insurance.Application.RiskAnalysis.Rules
{
    public class AgeBetweenThirtyAndFourtyRule : IRiskAnalysisRule
    {
        public Domain.Entities.RiskAnalysis CalculateRiskAnalisysScore(Domain.Entities.RiskAnalysis riskAnalysis)
        {
            if (riskAnalysis.Age >= 30 && riskAnalysis.Age <= 40)
                riskAnalysis.SubtractFromScore(1);

            return riskAnalysis;
        }
    }
}
