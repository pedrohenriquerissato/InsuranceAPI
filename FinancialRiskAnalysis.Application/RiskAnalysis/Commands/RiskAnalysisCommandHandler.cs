using Insurance.Domain.ViewModels;
using MediatR;

namespace Insurance.Application.RiskAnalysis.Commands
{
    public class RiskAnalysisCommandHandler : IRequestHandler<RiskAnalysisCommand, RiskAnalysisViewModel>
    {
        public async Task<RiskAnalysisViewModel> Handle(RiskAnalysisCommand request, CancellationToken cancellationToken)
        {

            return new RiskAnalysisViewModel();
        }
    }
}
