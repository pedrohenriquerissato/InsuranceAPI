using FluentAssertions;
using Insurance.Application.RiskAnalysis.Rules;
using Insurance.Domain.Enums;
using Xunit;

namespace Insurance.Tests.Application.RiskAnalysis.Rules
{
    public class HouseMortgagedRuleTest
    {
        [Fact]
        public void CalculateRiskAnalisysScore_HouseIsMortgaged_ShouldChangeHomeAndDisabilityScore()
        {
            //Arrange
            var riskAnalysis = new Domain.Entities.RiskAnalysis(new int[] { 1, 1, 1 })
            {
                House = new Domain.Entities.House
                {
                    OwnershipStatus = OwnershipStatus.Mortgaged
                }
            };

            var rule = new HouseMortgagedRule();

            //Act
            var result = rule.CalculateRiskAnalisysScore(riskAnalysis);

            //Assert
            result.HomeScore.Should().Be(4);
            result.DisabilityScore.Should().Be(4);
        }

        [Theory]
        [InlineData(OwnershipStatus.Owned)]
        public void CalculateRiskAnalisysScore_HouseOwnershipStatusDifferentThanMortgaged_ShouldNotChangeHomeAndDisabilityScore(OwnershipStatus ownershipStatus)
        {
            //Arrange
            var riskAnalysis = new Domain.Entities.RiskAnalysis(new int[] { 1, 1, 1 })
            {
                House = new Domain.Entities.House
                {
                    OwnershipStatus = ownershipStatus
                }
            };

            var rule = new HouseMortgagedRule();

            //Act
            var result = rule.CalculateRiskAnalisysScore(riskAnalysis);

            //Assert
            result.HomeScore.Should().Be(3);
            result.DisabilityScore.Should().Be(3);
        }

        [Fact]
        public void CalculateRiskAnalisysScore_HouseIsNull_ShouldNotChangeHomeAndDisabilityScore()
        {
            //Arrange
            var riskAnalysis = new Domain.Entities.RiskAnalysis(new int[] { 1, 1, 1 });

            var rule = new HouseMortgagedRule();

            //Act
            var result = rule.CalculateRiskAnalisysScore(riskAnalysis);

            //Assert
            result.HomeScore.Should().Be(3);
            result.DisabilityScore.Should().Be(3);
        }
    }
}
