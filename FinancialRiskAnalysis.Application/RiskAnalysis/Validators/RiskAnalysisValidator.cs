using FluentValidation;
using Insurance.Domain.Enums;
using Insurance.Domain.InputModels;

namespace Insurance.Application.RiskAnalysis.Validators
{
    /// <summary>
    /// Validates all RiskAnalysis business rules
    /// </summary>
    public class RiskAnalysisValidator : AbstractValidator<RiskAnalysisInputModel>
    {
        public RiskAnalysisValidator()
        {
            #region Age
            RuleFor(x => x.Age)
                .NotNull()
                .WithMessage("Age is a required field.");

            RuleFor(x => x.Age)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Please input your age as a number equal or greater than zero (0).");

            RuleFor(x => x.Age)
                .LessThanOrEqualTo(122)
                .WithMessage("The age range has a limit of 122 years old. If you need to insert an age older than that, we congratulate you and ask you to please get in touch with us at itsupport@useorigin.com.");
            #endregion

            #region Dependents
            RuleFor(x => x.Dependents)
                .NotNull()
                .WithMessage("Dependents is a required field.");

            RuleFor(x => x.Dependents)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Please input your number of Dependents equal or greater than zero (0).");
            #endregion

            #region Income
            RuleFor(x => x.Income)
                .NotNull()
                .WithMessage("Income is a required field.");

            RuleFor(x => x.Income)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Please input your total income as a number equal or greater than zero (0).");
            #endregion

            #region Risk Questions
            RuleFor(x => x.RiskQuestions)
                .NotEmpty()
                .WithMessage("Risk Questions must not be null or empty.");

            RuleFor(x => x.RiskQuestions)
                .Must(x => x.Length == 3)
                .When(x => x.RiskQuestions.Length != 0)
                .WithMessage("Risk Questions must contain exactly three answers.");

            RuleForEach(x => x.RiskQuestions)
                .Must(x => x == 0 || x == 1)
                .WithMessage("Risk Questions must be filled with zero (0) for false and one (1) for true.");
            #endregion

            #region House
            When(x => x.House is not null, () =>
            {
                RuleFor(x => x.House.OwnershipStatus)
                .NotNull()
                .NotEmpty()
                .WithMessage("House Ownership Status must not be null or empty. Please, choose one of these statuses: ");

                When(x => !string.IsNullOrEmpty(x.House.OwnershipStatus) && !string.IsNullOrWhiteSpace(x.House.OwnershipStatus), () =>
                {
                    RuleFor(x => x.House.OwnershipStatus).IsEnumName(typeof(OwnershipStatus), false)
                    .WithMessage("House Ownership Status does not seem to be valid. Please, choose one of these statuses: ");
                });

            });
            #endregion

            #region Vehicle
            When(x => x.Vehicle is not null, () =>
            {
                var vehicleYearMin = 1769;
                var vehicleYearMax = DateTime.Now.AddYears(1).Year;

                RuleFor(x => x.Vehicle.Year).InclusiveBetween(vehicleYearMin, vehicleYearMax)
                .WithMessage($"Your vehicle year must be a four-digit number between {vehicleYearMin} and {vehicleYearMax}.");
            });
            #endregion
        }
    }
}
