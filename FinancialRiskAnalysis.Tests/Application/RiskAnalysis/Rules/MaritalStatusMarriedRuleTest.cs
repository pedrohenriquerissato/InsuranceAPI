using FluentAssertions;
using Insurance.Application.RiskAnalysis.Rules;
using Insurance.Domain.Enums;
using Xunit;

namespace Insurance.Tests.Application.RiskAnalysis.Rules
{
    public class MaritalStatusMarriedRuleTest
    {
        [Fact]
        public void CalculateRiskAnalisysScore_MaritalStatusMarried_ShouldChangeLifeAndDisabilityScore()
        {
            //Arrange
            var riskAnalysis = new Domain.Entities.RiskAnalysis(new int[] { 1, 1, 1 })
            {
                MaritalStatus = MaritalStatus.Married
            };

            var rule = new MaritalStatusMarriedRule();

            //Act
            var result = rule.CalculateRiskAnalisysScore(riskAnalysis);

            //Assert
            result.LifeScore.Should().Be(4);
            result.DisabilityScore.Should().Be(2);
        }

        [Theory]
        [InlineData(MaritalStatus.Single)]
        public void CalculateRiskAnalisysScore_AnyMaritalStatusButMarried_ShouldNotChangeAnyScore(MaritalStatus maritalStatus)
        {
            //Arrange
            var riskAnalysis = new Domain.Entities.RiskAnalysis(new int[] { 1, 1, 1 })
            {
                MaritalStatus = maritalStatus
            };

            var rule = new MaritalStatusMarriedRule();

            //Act
            var result = rule.CalculateRiskAnalisysScore(riskAnalysis);

            //Assert
            result.LifeScore.Should().Be(riskAnalysis.LifeScore);
            result.DisabilityScore.Should().Be(riskAnalysis.DisabilityScore);
        }
    }
}
