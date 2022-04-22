using System;
using FluentValidation;
using Rookie.AssetManagement.Contracts.Constants;
using Rookie.AssetManagement.Contracts.Dtos.AssignmentDtos;

namespace Rookie.AssetManagement.Validators
{
    public class AssignmentDtoValidator : BaseValidator<AssignmentCreateDTO>
    {
        public AssignmentDtoValidator()
        {

            RuleFor(m => m.AssignToID)
                .NotNull()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.AssignToID)))
                .NotEmpty()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.AssignToID)));

            RuleFor(m => m.AssetID)
                .NotNull()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.AssetID)))
                .NotEmpty()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.AssetID)));

            RuleFor(m => m.AssignDate)
                .NotNull()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.AssignDate)))
                .GreaterThanOrEqualTo(DateTime.Now.Date)
                .WithMessage(x => string.Format(ErrorTypes.Common.SelectDateGreaterThanOrEqualToday, nameof(x.AssignDate)));

            RuleFor(m => m.Note)
                .NotNull()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Note)));
        }
    }
}

