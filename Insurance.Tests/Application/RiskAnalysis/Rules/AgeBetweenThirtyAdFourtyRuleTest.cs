using FluentAssertions;
using Insurance.Application.RiskAnalysis.Rules;
using Xunit;

namespace Insurance.Tests.Application.RiskAnalysis.Rules
{
    public class AgeBetweenThirtyAdFourtyRuleTest
    {
        [Theory]
        [InlineData(30)]
        [InlineData(31)]
        [InlineData(39)]
        [InlineData(40)]
        public void CalculateRiskAnalisysScore_AgeBetweenThirtyAndFourty_SubtractsOneFromAllScores(int age)
        {
            //Arrange
            var riskAnalysis = new Domain.Entities.RiskAnalysis(new int[] { 1, 1, 1 })
            {
                Age = age
            };

            var rule = new AgeBetweenThirtyAndFourtyRule();

            //Act
            var result = rule.CalculateRiskAnalisysScore(riskAnalysis);

            //Assert
            result.AutoScore.Should().Be(2);
            result.DisabilityScore.Should().Be(2);
            result.LifeScore.Should().Be(2);
            result.HomeScore.Should().Be(2);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(122)]
        public void CalculateRiskAnalisysScore_AnyAgeButThirtyOrFourty_DontChangeScores(int age)
        {
            //Arrange
            var riskAnalysis = new Domain.Entities.RiskAnalysis(new int[] { 1, 1, 1 })
            {
                Age = age
            };

            var rule = new AgeBetweenThirtyAndFourtyRule();

            //Act
            var result = rule.CalculateRiskAnalisysScore(riskAnalysis);

            //Assert
            result.AutoScore.Should().Be(3);
            result.DisabilityScore.Should().Be(3);
            result.LifeScore.Should().Be(3);
            result.HomeScore.Should().Be(3);
        }
    }
}
