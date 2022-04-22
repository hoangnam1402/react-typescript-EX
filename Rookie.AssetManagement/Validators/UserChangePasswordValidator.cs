using FluentValidation;
using Rookie.AssetManagement.Contracts.Dtos.UserDtos;
namespace Rookie.AssetManagement.Validators
{
    public class UserChangePasswordValidator : BaseValidator<UserChangePasswordDTO>
    {
        public UserChangePasswordValidator() 
        {
            RuleFor(x => x.NewPassword)
                .NotEmpty()
                .WithMessage("New Password is required");
            RuleFor(x => x.CurrentPassword)
             .NotEmpty()
             .WithMessage("Current Password is required");
        }
    }
}
