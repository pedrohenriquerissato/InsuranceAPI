﻿using FluentValidation;
using Insurance.Application.Common;
using Insurance.Domain.Enums;
using Insurance.Domain.InputModels;

namespace Insurance.Application.RiskAnalysis.Validators
{
    /// <summary>
    /// Validates all Risk Analysis business rules.
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

            #region Marital Status
            var maritalStatuses = EnumUtils.GetNames<MaritalStatus>();

            RuleFor(x => x.MaritalStatus)
                .NotNull()
                .WithMessage($"Marital Status should not be null. Please, choose one of these statuses: {maritalStatuses}.");

            RuleFor(x => x.MaritalStatus)
                .NotEmpty()
                .WithMessage($"Marital Status should not be empty. Please, choose one of these statuses: {maritalStatuses}.");

            When(x => !string.IsNullOrEmpty(x.MaritalStatus) && !string.IsNullOrWhiteSpace(x.MaritalStatus), () =>
            {
                RuleFor(x => x.MaritalStatus).IsEnumName(typeof(MaritalStatus), false)
                .WithMessage($"Marital Status does not seem to be valid. Please, choose one of these statuses: {maritalStatuses}.");
            });

            #endregion

            #region Risk Questions
            RuleFor(x => x.RiskQuestions)
                .NotEmpty()
                .WithMessage("Risk Questions must not be null or empty.");

            RuleFor(x => x.RiskQuestions)
                .Must(x => x.Length == 3)
                .When(x => x.RiskQuestions is not null && x.RiskQuestions.Length != 0)
                .WithMessage("Risk Questions must contain exactly three answers.");

            RuleForEach(x => x.RiskQuestions)
                .Must(x => x == 0 || x == 1)
                .WithMessage("Risk Questions must be filled with zero (0) for false and one (1) for true.");
            #endregion

            #region House
            When(x => x.House is not null, () =>
            {
                var ownershipStatuses = EnumUtils.GetNames<OwnershipStatus>();

                RuleFor(x => x.House.OwnershipStatus)
                .NotNull()
                .WithMessage($"House Ownership Status must not be null. Please, choose one of these statuses: {ownershipStatuses}.");

                RuleFor(x => x.House.OwnershipStatus)
                .NotEmpty()
                .WithMessage($"House Ownership Status must not be empty. Please, choose one of these statuses: {ownershipStatuses}.");

                When(x => !string.IsNullOrEmpty(x.House.OwnershipStatus) && !string.IsNullOrWhiteSpace(x.House.OwnershipStatus), () =>
                {
                    RuleFor(x => x.House.OwnershipStatus).IsEnumName(typeof(OwnershipStatus), false)
                .WithMessage($"House Ownership Status does not seem to be valid. Please, choose one of these statuses: {ownershipStatuses}.");
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
