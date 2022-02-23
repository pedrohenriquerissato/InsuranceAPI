using FluentAssertions;
using Insurance.Application.RiskAnalysis.Rules;
using System;
using Xunit;

namespace Insurance.Tests.Application.RiskAnalysis.Rules
{
    public class VehicleLast5YearsRuleTest
    {
        [Theory]
        [InlineData(-5)]
        [InlineData(0)]
        [InlineData(1)]
        public void CalculateRiskAnalisysScore_VehicleNotOlderThanFiveYears_ShouldChangeAutoScore(int yearsOld)
        {
            //Arrange
            var riskAnalysis = new Domain.Entities.RiskAnalysis(new int[] { 1, 1, 1 })
            {
                Vehicle = new()
                {
                    Year = DateTime.Now.AddYears(yearsOld).Year
                }
            };

            var rule = new VehicleLast5YearsRule();

            //Act
            var result = rule.CalculateRiskAnalisysScore(riskAnalysis);

            //Assert
            result.AutoScore.Should().Be(4);
        }

        [Fact]
        public void CalculateRiskAnalisysScore_VehicleOlderThanFiveYears_ShouldNotChangeAutoScore()
        {
            //Arrange
            var riskAnalysis = new Domain.Entities.RiskAnalysis(new int[] { 1, 1, 1 })
            {
                Vehicle = new()
                {
                    Year = DateTime.Now.AddYears(-6).Year
                }
            };

            var rule = new VehicleLast5YearsRule();

            //Act
            var result = rule.CalculateRiskAnalisysScore(riskAnalysis);

            //Assert
            result.AutoScore.Should().Be(3);
        }

        [Fact]
        public void CalculateRiskAnalisysScore_VehicleIsNull_ShouldNotChangeAutoScore()
        {
            //Arrange
            var riskAnalysis = new Domain.Entities.RiskAnalysis(new int[] { 1, 1, 1 });

            var rule = new VehicleLast5YearsRule();

            //Act
            var result = rule.CalculateRiskAnalisysScore(riskAnalysis);

            //Assert
            result.AutoScore.Should().Be(riskAnalysis.AutoScore);
        }
    }
}
