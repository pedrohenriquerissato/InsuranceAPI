using FluentAssertions;
using Insurance.Application.RiskAnalysis.Rules;
using Insurance.Domain.Enums;
using Xunit;

namespace Insurance.Tests.Application.RiskAnalysis.Rules
{
    public class IncomeNoneRuleTest
    {
        [Fact]
        public void CalculateRiskAnalisysScore_NoIncome_ShouldChangeDisabilityProfile()
        {
            //Arrange
            var riskAnalysis = new Domain.Entities.RiskAnalysis(new int[] { 1, 1, 1 })
            {
                Income = 0
            };

            var rule = new IncomeNoneRule();

            //Act
            var result = rule.CalculateRiskAnalisysScore(riskAnalysis);

            //Assert
            result.DisabilityProfile.Should().Be(ProfileStatus.Ineligible.Name);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(int.MaxValue)]
        public void CalculateRiskAnalisysScore_AnyIncome_ShouldNotChangeDisabilityProfile(int income)
        {
            //Arrange
            var riskAnalysis = new Domain.Entities.RiskAnalysis(new int[] { 1, 1, 1 })
            {
                Income = income
            };

            var rule = new IncomeNoneRule();

            //Act
            var result = rule.CalculateRiskAnalisysScore(riskAnalysis);

            //Assert
            result.DisabilityProfile.Should().BeSameAs(riskAnalysis.DisabilityProfile);
        }
    }
}
