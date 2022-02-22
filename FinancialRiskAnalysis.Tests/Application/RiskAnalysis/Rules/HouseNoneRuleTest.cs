using FluentAssertions;
using Insurance.Application.RiskAnalysis.Rules;
using Insurance.Domain.Enums;
using Xunit;

namespace Insurance.Tests.Application.RiskAnalysis.Rules
{
    public class HouseNoneRuleTest
    {
        [Fact]
        public void CalculateRiskAnalisysScore_HouseIsNull_ShouldHomeProfileShouldBeIneligible()
        {
            //Arrange
            var riskAnalysis = new Domain.Entities.RiskAnalysis(new int[] { 1, 1, 1 });

            var rule = new HouseNoneRule();

            //Act
            var result = rule.CalculateRiskAnalisysScore(riskAnalysis);

            //Assert
            result.HomeProfile.Should().Be(ProfileStatus.Ineligible.Name);
        }

        [Fact]
        public void CalculateRiskAnalisysScore_HouseIsNotNull_ShouldNotChangeHomeProfile()
        {
            //Arrange
            var riskAnalysis = new Domain.Entities.RiskAnalysis(new int[] { 1, 1, 1 })
            {
                House = new Domain.Entities.House()
            };

            var rule = new HouseNoneRule();

            //Act
            var result = rule.CalculateRiskAnalisysScore(riskAnalysis);

            //Assert
            result.HomeProfile.Should().BeSameAs(riskAnalysis.HomeProfile);
        }
    }
}
