using Insurance.Application.RiskAnalysis.Rules;
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

            foreach (var rule in _rules)
            {
                request.RiskAnalysis = rule.CalculateRiskAnalisysScore(request.RiskAnalysis);    
            }

            return new RiskAnalysisViewModel();
        }
    }
}
