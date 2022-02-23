using FluentAssertions;
using Insurance.Application.RiskAnalysis.Rules;
using Insurance.Domain.Enums;
using Xunit;

namespace Insurance.Tests.Application.RiskAnalysis.Rules
{
    public class VehicleNoneRuleTest
    {
        [Fact]
        public void CalculateRiskAnalisysScore_VehicleIsNull_ShouldChangeAutoProfile()
        {
            //Arrange
            var riskAnalysis = new Domain.Entities.RiskAnalysis(new int[] { 1, 1, 1 });

            var rule = new VehicleNoneRule();

            //Act
            var result = rule.CalculateRiskAnalisysScore(riskAnalysis);

            //Assert
            result.AutoProfile.Should().Be(ProfileStatus.Ineligible.Name);
        }

        [Fact]
        public void CalculateRiskAnalisysScore_VehicleIsNotNull_ShouldNotChangeAutoProfile()
        {
            //Arrange
            var riskAnalysis = new Domain.Entities.RiskAnalysis(new int[] { 1, 1, 1 });

            var rule = new VehicleNoneRule();

            //Act
            var result = rule.CalculateRiskAnalisysScore(riskAnalysis);

            //Assert
            result.AutoProfile.Should().BeSameAs(riskAnalysis.AutoProfile);
        }
    }
}
