using FluentAssertions;
using Insurance.Application.RiskAnalysis.Commands;
using Insurance.Domain.Enums;
using Xunit;

namespace Insurance.Tests.Application.RiskAnalysis.Commands
{
    public class RiskAnalysisCommandHandlerTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(int.MinValue)]
        public void CalculateRiskProfile_ZeroOrBelow_ShouldReturnEconomic(int score)
        {
            //Arrange

            //Act
            var result = RiskAnalysisCommandHandler.CalculateRiskProfile(score);

            //Assert
            result.Should().Be(ProfileStatus.Economic.Name);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void CalculateRiskProfile_OneAndTwo_ShouldReturnRegular(int score)
        {
            //Arrange

            //Act
            var result = RiskAnalysisCommandHandler.CalculateRiskProfile(score);

            //Assert
            result.Should().Be(ProfileStatus.Regular.Name);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(int.MaxValue)]
        public void CalculateRiskProfile_ThreeOrMore_ShouldReturnResponsible(int score)
        {
            //Arrange

            //Act
            var result = RiskAnalysisCommandHandler.CalculateRiskProfile(score);

            //Assert
            result.Should().Be(ProfileStatus.Responsible.Name);
        }
    }
}
