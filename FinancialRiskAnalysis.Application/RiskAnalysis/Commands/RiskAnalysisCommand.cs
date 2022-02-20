using Insurance.Domain.Entitities;
using Insurance.Domain.Enums;
using Insurance.Domain.InputModels;
using Insurance.Domain.ViewModels;
using Mapster;
using MediatR;

namespace Insurance.Application.RiskAnalysis.Commands
{
    public class RiskAnalysisCommand : IRequest<RiskAnalysisViewModel>
    {
        public int Age { get; set; }
        public int Dependents { get; set; }
        public House? House { get; set; }
        public int Income { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public int[] RiskQuestions { get; set; }
        public Vehicle? Vehicle { get; set; }

        public RiskAnalysisCommand(RiskAnalysisInputModel model)
        {
            TypeAdapterConfig<RiskAnalysisInputModel, RiskAnalysisCommand>.NewConfig();

            model.Adapt(this);
        }
    }
}
