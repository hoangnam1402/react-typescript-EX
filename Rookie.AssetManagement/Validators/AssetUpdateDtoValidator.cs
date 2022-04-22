﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentValidation;
using Rookie.AssetManagement.Business;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Contracts.Constants;
using Rookie.AssetManagement.Contracts.Dtos.AssetDtos;
using Rookie.AssetManagement.DataAccessor.Enums;

namespace Rookie.AssetManagement.Validators
{
    public class AssetUpdateDtoValidator : BaseValidator<AssetUpdateDTO>
    {
        public AssetUpdateDtoValidator()
        {

            RuleFor(m => m.Name)
                .NotNull()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Name)))
                .NotEmpty()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Name)));

            RuleFor(m => m.Specification)
                .NotNull()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Specification)))
                .NotEmpty()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.Specification)));

            RuleFor(m => m.InstallDate)
                .NotNull()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.InstallDate)));

            RuleFor(m => m.State)
                .NotNull()
                .WithMessage(x => string.Format(ErrorTypes.Common.RequiredError, nameof(x.State)))
                .IsInEnum()
                .WithMessage(x => string.Format(ErrorTypes.Common.EnumError, nameof(x.State)));
        }
    }
}

