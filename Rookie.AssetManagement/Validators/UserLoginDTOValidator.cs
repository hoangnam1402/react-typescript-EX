using FluentValidation;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;

namespace Rookie.AssetManagement.Validators
{

    public class UserLoginDTOValidator : BaseValidator<UserLoginDTO>
    {
        public UserLoginDTOValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("UserName is required");
            RuleFor(x => x.Password)
             .NotEmpty()
             .WithMessage("Password is required");


        }
    }
}
