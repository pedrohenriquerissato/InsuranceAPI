using FluentValidation.TestHelper;
using Insurance.Application.RiskAnalysis.Validators;
using Insurance.Domain.InputModels;
using Xunit;


namespace Insurance.Tests.Application.RiskAnalysis.Validators
{
    public class RiskAnalysisValidatorTest
    {
        private RiskAnalysisValidator validator;

        public RiskAnalysisValidatorTest()
        {
            validator = new RiskAnalysisValidator();
        }

        #region Age

        [Theory]
        [InlineData(-1)]
        [InlineData(int.MinValue)]
        public void Age_Negative_ReturnsErrorEqualGreaterThanZero(int? age)
        {
            //Arrange
            var model = new RiskAnalysisInputModel
            {
                Age = age
            };

            //Act
            var result = validator.TestValidate(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Age)
                .WithErrorMessage("Please input your age as a number equal or greater than zero (0).");
        }

        [Fact]
        public void Age_NullOrEmpty_ReturnsErrorCanNotBeNullOrEmpty()
        {
            //Arrange
            var model = new RiskAnalysisInputModel
            {
                Age = null
            };

            //Act
            var result = validator.TestValidate(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Age)
                .WithErrorMessage("Age is a required field.");
        }

        [Theory]
        [InlineData(123)]
        [InlineData(int.MaxValue)]
        public void Age_MoreThanTheOldest_ReturnsErrorOutsideBoundaries(int? age)
        {
            //Arrange
            var model = new RiskAnalysisInputModel
            {
                Age = age
            };

            //Act
            var result = validator.TestValidate(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Age)
                .WithErrorMessage("The age range has a limit of 122 years old. If you need to insert an age older than that, we congratulate you and ask you to please get in touch with us at itsupport@useorigin.com.");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(122)]
        public void Age_ValidAges_ReturnsWithoutErrors(int? age)
        {
            //Arrange
            var model = new RiskAnalysisInputModel
            {
                Age = age
            };

            //Act
            var result = validator.TestValidate(model);

            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Age);
        }
        #endregion

        #region Dependents
        [Fact]
        public void Dependents_NullOrEmpty_ReturnsErrorCanNotBeNullOrEmpty()
        {
            //Arrange
            var model = new RiskAnalysisInputModel
            {
                Dependents = null
            };

            //Act
            var result = validator.TestValidate(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Dependents)
                .WithErrorMessage("Dependents is a required field.");
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(int.MinValue)]
        public void Dependents_Negative_ReturnsErrorEqualGreaterThanZero(int? dependents)
        {
            //Arrange
            var model = new RiskAnalysisInputModel
            {
                Dependents = dependents
            };

            //Act
            var result = validator.TestValidate(model);

            //Result
            result.ShouldHaveValidationErrorFor(x => x.Dependents)
                .WithErrorMessage("Please input your number of Dependents equal or greater than zero (0).");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(int.MaxValue)]
        public void Dependents_ValidQuantity_ReturnsWithoutErrors(int? dependents)
        {
            //Arrange
            var model = new RiskAnalysisInputModel
            {
                Dependents = dependents
            };

            //Act
            var result = validator.TestValidate(model);

            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Dependents);
        }
        #endregion

        #region Income
        [Fact]
        public void Income_NullOrEmpty_ReturnsErrorCanNotBeNullOrEmpty()
        {
            //Arrange
            var model = new RiskAnalysisInputModel
            {
                Income = null
            };

            //Act
            var result = validator.TestValidate(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Income)
                .WithErrorMessage("Income is a required field.");
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(int.MinValue)]
        public void Income_Negative_ReturnsErrorEqualGreaterThanZero(int? income)
        {
            //Arrange
            var model = new RiskAnalysisInputModel
            {
                Income = income
            };

            //Act
            var result = validator.TestValidate(model);

            //Result
            result.ShouldHaveValidationErrorFor(x => x.Income)
                .WithErrorMessage("Please input your total income as a number equal or greater than zero (0).");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(int.MaxValue)]
        public void Income_ValidQuantity_ReturnsWithoutErrors(int? income)
        {
            //Arrange
            var model = new RiskAnalysisInputModel
            {
                Income = income
            };

            //Act
            var result = validator.TestValidate(model);

            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Income);
        }
        #endregion

        #region Risk Questions
        [Fact]
        public void RiskQuestions_Empty_ReturnsErrorEmpty()
        {
            //Arrange
            var model = new RiskAnalysisInputModel
            {
                RiskQuestions = System.Array.Empty<int>()
            };

            //Act
            var result = validator.TestValidate(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.RiskQuestions)
                .WithErrorMessage("Risk Questions must not be null or empty.");
        }

        [Theory]
        [InlineData(new int[] {0, 0})]
        [InlineData(new int[] {0})]
        public void RiskQuestions_MinimumRequiredAnswers_ReturnsErrorMinimumRequiredAnswers(int[] riskQuestions)
        {
            //Arrange
            var model = new RiskAnalysisInputModel
            {
                RiskQuestions = riskQuestions
            };

            //Act
            var result = validator.TestValidate(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.RiskQuestions)
                .WithErrorMessage("Risk Questions must contain exactly three answers.");
        }
        #endregion
    }
}
