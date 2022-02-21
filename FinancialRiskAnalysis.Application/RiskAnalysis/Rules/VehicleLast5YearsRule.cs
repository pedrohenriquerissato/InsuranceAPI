namespace Insurance.Application.RiskAnalysis.Rules
{
    public class VehicleLast5YearsRule : IRiskAnalysisRule
    {
        public Domain.Entities.RiskAnalysis CalculateRiskAnalisysScore(Domain.Entities.RiskAnalysis riskAnalysis)
        {
            if (riskAnalysis.Vehicle?.Year >= DateTime.Now.AddYears(-5).Year)
                riskAnalysis.AutoScore += 1;

            return riskAnalysis;
        }
    }
}
