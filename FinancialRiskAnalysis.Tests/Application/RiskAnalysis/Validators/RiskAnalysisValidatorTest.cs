using FluentValidation.TestHelper;
using Insurance.Application.RiskAnalysis.Validators;
using Insurance.Domain.InputModels;
using System;
using Xunit;


namespace Insurance.Tests.Application.RiskAnalysis.Validators
{
    /// <summary>
    /// Unit tests of <see cref="RiskAnalysisValidator"/> rules.
    /// </summary>
    public class RiskAnalysisValidatorTest
    {
        private readonly RiskAnalysisValidator _validator;

        public RiskAnalysisValidatorTest()
        {
            _validator = new RiskAnalysisValidator();
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
            var result = _validator.TestValidate(model);

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
            var result = _validator.TestValidate(model);

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
            var result = _validator.TestValidate(model);

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
            var result = _validator.TestValidate(model);

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
            var result = _validator.TestValidate(model);

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
            var result = _validator.TestValidate(model);

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
            var result = _validator.TestValidate(model);

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
            var result = _validator.TestValidate(model);

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
            var result = _validator.TestValidate(model);

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
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Income);
        }
        #endregion

        #region Marital Status
        [Fact]
        public void MaritalStatus_Null_ReturnsErrorNotNull()
        {
            //Arrange
            var model = new RiskAnalysisInputModel
            {
                MaritalStatus = null
            };

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.MaritalStatus)
                .WithErrorMessage("Marital Status should not be null. Please, choose one of these statuses: ");
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void MaritalStatus_Empty_ReturnsErrorNotEmpty(string maritalStatus)
        {
            //Arrange
            var model = new RiskAnalysisInputModel
            {
                MaritalStatus = maritalStatus
            };

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.MaritalStatus)
                .WithErrorMessage("Marital Status should not be empty. Please, choose one of these statuses: ");
        }

        [Fact]
        public void MaritalStatus_InvalidStatus_ReturnsErrorInvalidStatus()
        {
            //Arrange
            var model = new RiskAnalysisInputModel
            {
                MaritalStatus = "any"
            };

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.MaritalStatus)
                .WithErrorMessage("Marital Status does not seem to be valid. Please, choose one of these statuses: ");
        }

        [Fact]
        public void MaritalStatus_StatusNone_ReturnsErrorStatusNone()
        {
            //Arrange
            var model = new RiskAnalysisInputModel
            {
                MaritalStatus = "none"
            };

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.MaritalStatus)
                .WithoutErrorMessage("Marital Status is not valid. Please select one of these statuses: ");
        }

        [Theory]
        [InlineData("single")]
        [InlineData("Single")]
        [InlineData("SiNgLe")]
        [InlineData("married")]
        [InlineData("Married")]
        [InlineData("MaRrIeD")]
        public void MaritalStatus_ValidStatus_ReturnsWithoutErrors(string maritalStatus)
        {
            //Arrange
            var model = new RiskAnalysisInputModel
            {
                MaritalStatus = maritalStatus
            };

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.MaritalStatus);
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
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.RiskQuestions)
                .WithErrorMessage("Risk Questions must not be null or empty.");
        }

        [Theory]
        [InlineData(new int[] { 0, 0 })]
        [InlineData(new int[] { 0 })]
        public void RiskQuestions_MinimumRequiredAnswers_ReturnsErrorMinimumRequiredAnswers(int[] riskQuestions)
        {
            //Arrange
            var model = new RiskAnalysisInputModel
            {
                RiskQuestions = riskQuestions
            };

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.RiskQuestions)
                .WithErrorMessage("Risk Questions must contain exactly three answers.");
        }

        [Theory]
        [InlineData(new int[] { 0, 0, int.MinValue })]
        [InlineData(new int[] { 0, 0, int.MaxValue })]
        public void RiskQuestions_NonBooleans_ReturnsErrorOnlyZerosAndOnes(int[] riskQuestions)
        {
            //Arrange
            var model = new RiskAnalysisInputModel
            {
                RiskQuestions = riskQuestions
            };

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.RiskQuestions)
                .WithErrorMessage("Risk Questions must be filled with zero (0) for false and one (1) for true.");
        }

        [Theory]
        [InlineData(new int[] { 0, 0, 0 })]
        [InlineData(new int[] { 0, 0, 1 })]
        [InlineData(new int[] { 0, 1, 0 })]
        [InlineData(new int[] { 0, 1, 1 })]
        [InlineData(new int[] { 1, 0, 0 })]
        [InlineData(new int[] { 1, 0, 1 })]
        [InlineData(new int[] { 1, 1, 0 })]
        [InlineData(new int[] { 1, 1, 1 })]
        public void RiskQuestions_Valid_ReturnsWithoutErrors(int[] riskQuestions)
        {
            //Arrange
            var model = new RiskAnalysisInputModel
            {
                RiskQuestions = riskQuestions
            };

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.RiskQuestions);
        }
        #endregion

        #region House
        [Fact]
        public void House_NullOrEmpty_ReturnsWithoutErrors()
        {
            //Arrange
            var model = new RiskAnalysisInputModel();

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.House);
        }

        [Fact]
        public void OwnershipStatus_Null_ReturnsErrorNull()
        {
            //Arrange
            var model = new RiskAnalysisInputModel
            {
                House = new Domain.Entitities.House()
            };

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.House.OwnershipStatus)
                .WithErrorMessage("House Ownership Status must not be null. Please, choose one of these statuses: ");
        }

        [Fact]
        public void OwnershipStatus_Empty_ReturnsErrorEmpty()
        {
            //Arrange
            var model = new RiskAnalysisInputModel
            {
                House = new Domain.Entitities.House
                {
                    OwnershipStatus = ""
                }
            };

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.House.OwnershipStatus)
                .WithErrorMessage("House Ownership Status must not be empty. Please, choose one of these statuses: ");
        }

        [Fact]
        public void OwnershipStatus_InvalidStatus_ReturnsErrorInvalidStatus()
        {
            //Arrange
            var model = new RiskAnalysisInputModel
            {
                House = new Domain.Entitities.House
                {
                    OwnershipStatus = "any"
                }
            };

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.House.OwnershipStatus)
                .WithErrorMessage("House Ownership Status does not seem to be valid. Please, choose one of these statuses: ");
        }

        [Fact]
        public void OwnershipStatus_StatusNone_ReturnsErrorInvalidStatus()
        {
            //Arrange
            var model = new RiskAnalysisInputModel
            {
                House = new Domain.Entitities.House
                {
                    OwnershipStatus = "none"
                }
            };

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.House.OwnershipStatus)
                .WithErrorMessage("House Ownership Status is not valid. Please select one of these statuses: ");
        }

        [Theory]
        [InlineData("owned")]
        [InlineData("Owned")]
        [InlineData("OwNeD")]
        [InlineData("mortgaged")]
        [InlineData("Mortgaged")]
        [InlineData("MoRtGaGed")]
        public void OwnershipStatus_ValidStatus_ReturnsWithoutErrors(string ownershipStatus)
        {
            //Arrange
            var model = new RiskAnalysisInputModel
            {
                House = new Domain.Entitities.House
                {
                    OwnershipStatus = ownershipStatus
                }
            };

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.House.OwnershipStatus);
        }
        #endregion

        #region Vehicle
        [Fact]
        public void Vehicle_Null_ReturnsWithoutErrors()
        {
            //Arrange
            var model = new RiskAnalysisInputModel();

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Vehicle);
        }

        [Fact]
        public void Vehicle_InvalidMinimumValue_ReturnsErrorInvalidYear()
        {
            //Arrange
            var model = new RiskAnalysisInputModel
            {
                Vehicle = new Domain.Entitities.Vehicle
                {
                    Year = 1768
                }
            };

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Vehicle.Year);
        }

        [Fact]
        public void Vehicle_InvalidMaximumValue_ReturnsErrorInvalidYear()
        {
            //Arrange
            var model = new RiskAnalysisInputModel
            {
                Vehicle = new Domain.Entitities.Vehicle
                {
                    Year = DateTime.Now.AddYears(2).Year
                }
            };

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Vehicle.Year);
        }

        [Fact]
        public void Vehicle_ValidMinimumYear_ReturnsWithoutErrors()
        {
            //Arrange
            var model = new RiskAnalysisInputModel
            {
                Vehicle = new Domain.Entitities.Vehicle
                {
                    Year = 1769
                }
            };

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Vehicle.Year);
        }

        [Fact]
        public void Vehicle_ValidMaximumYear_ReturnsWithoutErrors()
        {
            //Arrange
            var model = new RiskAnalysisInputModel
            {
                Vehicle = new Domain.Entitities.Vehicle
                {
                    Year = DateTime.Now.AddYears(1).Year
                }
            };

            //Act
            var result = _validator.TestValidate(model);

            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Vehicle.Year);
        }

        #endregion
    }
}
