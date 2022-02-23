using FluentAssertions;
using Insurance.Application.RiskAnalysis.Rules;
using Xunit;

namespace Insurance.Tests.Application.RiskAnalysis.Rules
{
    public class AgeUnderThirtyRuleTest
    {
        [Theory]
        [InlineData(29)]
        [InlineData(0)]
        public void CalculateRiskAnalisysScore_AgeUnderThirty_ChangeAllScores(int age)
        {
            //Arrange
            var riskAnalysis = new Domain.Entities.RiskAnalysis(new int[] { 1, 1, 1 })
            {
                Age = age
            };

            var rule = new AgeUnderThirtyRule();

            //Act
            var result = rule.CalculateRiskAnalisysScore(riskAnalysis);

            //Assert
            result.AutoScore.Should().Be(1);
            result.LifeScore.Should().Be(1);
            result.HomeScore.Should().Be(1);
            result.DisabilityScore.Should().Be(1);
        }

        [Theory]
        [InlineData(30)]
        [InlineData(122)]
        public void CalculateRiskAnalisysScore_AgeThirtyAndAbove_DontChangeAnyScores(int age)
        {
            //Arrange
            var riskAnalysis = new Domain.Entities.RiskAnalysis(new int[] { 1, 1, 1 })
            {
                Age = age
            };

            var rule = new AgeUnderThirtyRule();

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
