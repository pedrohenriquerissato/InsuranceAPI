using FluentAssertions;
using Insurance.Application.RiskAnalysis.Rules;
using Xunit;

namespace Insurance.Tests.Application.RiskAnalysis.Rules
{
    public class DependentsExistsRuleTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(int.MaxValue)]
        public void CalculateRiskAnalisysScore_OneOrMoreDependents_ShouldChangeDisabilityAndLifeScores(int dependents)
        {
            //Arrange
            var riskAnalysis = new Domain.Entities.RiskAnalysis(new int[] { 1, 1, 1 })
            {
                Dependents = dependents
            };

            var rule = new DependentsExistsRule();

            //Act
            var result = rule.CalculateRiskAnalisysScore(riskAnalysis);

            //Assert
            result.DisabilityScore.Should().Be(4);
            result.LifeScore.Should().Be(4);
        }

        [Fact]
        public void CalculateRiskAnalisysScore_ZeroDependents_ShouldNotChangeLifeAndDisabilityScores()
        {
            //Arrange
            var riskAnalysis = new Domain.Entities.RiskAnalysis(new int[] { 1, 1, 1 })
            {
                Dependents = 0
            };

            var rule = new DependentsExistsRule();

            //Act
            var result = rule.CalculateRiskAnalisysScore(riskAnalysis);

            //Assert
            result.DisabilityScore.Should().Be(3);
            result.LifeScore.Should().Be(3);
        }
    }
}
