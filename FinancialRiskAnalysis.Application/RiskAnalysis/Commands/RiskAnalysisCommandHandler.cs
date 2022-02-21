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

            foreach (var rule in _rules)
            {
                request.RiskAnalysis = rule.CalculateRiskAnalisysScore(request.RiskAnalysis);    
            }

            return new RiskAnalysisViewModel();
        }
    }
}
