using Insurance.Application.RiskAnalysis.Rules;
using Insurance.Domain.Enums;
using Insurance.Domain.ViewModels;
using MediatR;

namespace Insurance.Application.RiskAnalysis.Commands
{
    public class RiskAnalysisCommandHandler : IRequestHandler<RiskAnalysisCommand, RiskAnalysisViewModel>
    {
        private readonly List<IRiskAnalysisRule> _rules = new();

        public async Task<RiskAnalysisViewModel> Handle(RiskAnalysisCommand request, CancellationToken cancellationToken)
        {
            _rules.Add(new AgeBetweenThirtyAndFourtyRule());
            _rules.Add(new AgeOverSixtyRule());
            _rules.Add(new AgeUnderThirtyRule());
            _rules.Add(new HouseMortgagedRule());
            _rules.Add(new HouseNoneRule());
            _rules.Add(new IncomeNoneRule());
            _rules.Add(new IncomeOver200kRule());
            _rules.Add(new VehicleNoneRule());
            _rules.Add(new DependentsExistsRule());
            _rules.Add(new MaritalStatusMarriedRule());
            _rules.Add(new VehicleLast5YearsRule());

            throw new Exception();

            await Task.Run(() =>
            {
                foreach (var rule in _rules)
                {
                    request.RiskAnalysis = rule.CalculateRiskAnalisysScore(request.RiskAnalysis);
                }
            }, cancellationToken);

            return new RiskAnalysisViewModel
            {
                Auto = request.RiskAnalysis.AutoProfile ?? CalculateRiskProfile(request.RiskAnalysis.AutoScore),
                Life = request.RiskAnalysis.LifeProfile ?? CalculateRiskProfile(request.RiskAnalysis.LifeScore),
                Home = request.RiskAnalysis.HomeProfile ?? CalculateRiskProfile(request.RiskAnalysis.HomeScore),
                Disability = request.RiskAnalysis.DisabilityProfile ?? CalculateRiskProfile(request.RiskAnalysis.DisabilityScore)
            };
        }

        /// <summary>
        /// Provides risk profile based on theme score
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        public static string CalculateRiskProfile(int score)
        {
            return score switch
            {
                <= 0 => ProfileStatus.Economic.Name,
                >= 1 and <= 2 => ProfileStatus.Regular.Name,
                >= 3 => ProfileStatus.Responsible.Name
            };
        }
    }
}
