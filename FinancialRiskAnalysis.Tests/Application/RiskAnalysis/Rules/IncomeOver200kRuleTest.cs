using FluentAssertions;
using Insurance.Application.RiskAnalysis.Rules;
using Xunit;

namespace Insurance.Tests.Application.RiskAnalysis.Rules
{
    public class IncomeOver200kRuleTest
    {
        [Theory]
        [InlineData(200001)]
        [InlineData(int.MaxValue)]
        public void CalculateRiskAnalisysScore_IncomeOver200k_ShouldChangeAllScores(int income)
        {
            //Arrange
            var riskAnalysis = new Domain.Entities.RiskAnalysis(new int[] { 1, 1, 1 })
            {
                Income = income
            };

            var rule = new IncomeOver200kRule();

            //Act
            var result = rule.CalculateRiskAnalisysScore(riskAnalysis);

            //Assert
            result.AutoScore.Should().Be(2);
            result.LifeScore.Should().Be(2);
            result.HomeScore.Should().Be(2);
            result.DisabilityScore.Should().Be(2);
        }

        [Theory]
        [InlineData(200000)]
        [InlineData(0)]
        public void CalculateRiskAnalisysScore_IncomeUnder200k_ShouldNotChangeAnyScore(int income)
        {
            //Arrange
            var riskAnalysis = new Domain.Entities.RiskAnalysis(new int[] { 1, 1, 1 })
            {
                Income = income
            };

            var rule = new IncomeOver200kRule();

            //Act
            var result = rule.CalculateRiskAnalisysScore(riskAnalysis);

            //Assert
            result.AutoScore.Should().Be(riskAnalysis.AutoScore);
            result.LifeScore.Should().Be(riskAnalysis.LifeScore);
            result.HomeScore.Should().Be(riskAnalysis.HomeScore);
            result.DisabilityScore.Should().Be(riskAnalysis.DisabilityScore);
        }
    }
}
