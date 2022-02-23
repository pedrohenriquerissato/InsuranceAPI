using Insurance.Domain.InputModels;
using Insurance.Domain.ViewModels;
using Mapster;
using MediatR;

namespace Insurance.Application.RiskAnalysis.Commands
{
    public class RiskAnalysisCommand : IRequest<RiskAnalysisViewModel>
    {
        public Domain.Entities.RiskAnalysis RiskAnalysis;

        public RiskAnalysisCommand(RiskAnalysisInputModel model)
        {
            TypeAdapterConfig<RiskAnalysisInputModel, Domain.Entities.RiskAnalysis>.NewConfig().MapToConstructor(true);

            RiskAnalysis = new Domain.Entities.RiskAnalysis(model.RiskQuestions);
            model.Adapt(RiskAnalysis);
        }
    }
}
