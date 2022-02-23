using FluentAssertions;
using Insurance.Application.RiskAnalysis.Rules;
using Insurance.Domain.Enums;
using Xunit;

namespace Insurance.Tests.Application.RiskAnalysis.Rules
{
    public class AgeOverSixtyRuleTest
    {
        [Theory]
        [InlineData(61)]
        [InlineData(122)]
        public void CalculateRiskAnalisysScore_AgeGreaterThan60_ChangeLifeAndDisabilityProfilesIntoIneligible(int age)
        {
            //Arrange
            var riskAnalysis = new Domain.Entities.RiskAnalysis(new int[] { 1, 1, 1 })
            {
                Age = age
            };

            var rule = new AgeOverSixtyRule();

            //Act
            var result = rule.CalculateRiskAnalisysScore(riskAnalysis);

            //Assert
            result.LifeProfile.Should().Be(ProfileStatus.Ineligible.Name);
            result.DisabilityProfile.Should().Be(ProfileStatus.Ineligible.Name);
        }

        [Theory]
        [InlineData(60)]
        [InlineData(0)]
        public void CalculateRiskAnalisysScore_AgeLessThan60_DontChangeLifeAndDisabilityProfiles(int age)
        {
            //Arrange
            var riskAnalysis = new Domain.Entities.RiskAnalysis(new int[] { 1, 1, 1 })
            {
                Age = age
            };

            var rule = new AgeOverSixtyRule();

            //Act
            var result = rule.CalculateRiskAnalisysScore(riskAnalysis);

            //Assert
            result.LifeProfile.Should().BeSameAs(riskAnalysis.LifeProfile);
            result.DisabilityProfile.Should().BeSameAs(riskAnalysis.DisabilityProfile);
        }
    }
}
