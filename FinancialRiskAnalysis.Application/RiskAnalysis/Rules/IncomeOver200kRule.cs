namespace Insurance.Application.RiskAnalysis.Rules
{
    public class IncomeOver200kRule : IRiskAnalysisRule
    {
        public Domain.Entities.RiskAnalysis CalculateRiskAnalisysScore(Domain.Entities.RiskAnalysis riskAnalysis)
        {
            if (riskAnalysis.Income > 200000)
                riskAnalysis.SubtractFromScore(1);

            return riskAnalysis;
        }
    }
}
