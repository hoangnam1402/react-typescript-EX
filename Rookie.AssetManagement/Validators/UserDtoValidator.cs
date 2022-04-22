using FluentValidation;
using Rookie.AssetManagement.Contracts.Constants;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Rookie.AssetManagement.Validators
{
    public class UserDtoValidator : BaseValidator<UserCreateDto>
    {
        public UserDtoValidator()
        {
            var checkSpecialCharacterFirstName =new Regex(@"^[a-zA-Z]+$");
            var checkSpecialCharacterLastName =new Regex(@"^[a-zA-Z ]+$");
            
            RuleFor(m => m.LastName)
                .NotNull()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.LastName)))
                .NotEmpty()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.LastName)))
                .Matches(checkSpecialCharacterLastName)
                .WithMessage(x=>string.Format(ErrorTypes.Common.SpecialCharacterError,nameof(x.LastName)));
                
            RuleFor(m => m.FirstName)
                .NotNull()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.FirstName)))
                .NotEmpty()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.FirstName)))
                .Matches(checkSpecialCharacterFirstName)
                .WithMessage(x=>string.Format(ErrorTypes.Common.SpecialCharacterError,nameof(x.FirstName)));
                
            RuleFor(m => m.DOB)
                .NotNull()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.DOB)))
                .LessThan(System.DateTime.Now.AddYears(-18))
                .WithMessage(x =>string.Format(ErrorTypes.Common.DOBLessThan18));

            RuleFor(m => m.Gender)
                .NotNull()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Gender)));

            RuleFor(m=>m.Type)
                .NotNull()
                .WithMessage(x=>string.Format(ErrorTypes.Common.RequiredError,nameof(x.Type)));

            RuleFor(m=>m.JoinDate)
                .NotNull()
                .WithMessage(x=>string.Format(ErrorTypes.Common.RequiredError,nameof(x.JoinDate)))
                .GreaterThan(m=>m.DOB.AddYears(18))
                .WithMessage(x=>string.Format(ErrorTypes.Common.JoinDateLessThan18YearsOld));                               

            RuleFor(m=>m.JoinDate.Date.DayOfWeek)
                .NotEqual(System.DayOfWeek.Sunday)
                .WithMessage(x=>string.Format(ErrorTypes.Common.JoinDateIsNotSaturdayOrSunDay))
                .NotEqual(System.DayOfWeek.Saturday)
                .WithMessage(x=>string.Format(ErrorTypes.Common.JoinDateIsNotSaturdayOrSunDay));
        }
    }
}
