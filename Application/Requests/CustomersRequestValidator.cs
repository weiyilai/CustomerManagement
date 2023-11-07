using FluentValidation;

namespace Application.Requests
{
    public class CustomersRequestValidator : AbstractValidator<CustomersRequest>
    {
        public CustomersRequestValidator() 
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("信箱必填")
                .EmailAddress().WithMessage("信箱格式有誤");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(5)
                .Matches("[a-z]").WithMessage("密碼至少要一個數字和一個英文字母")
                .Matches("[0-9]").WithMessage("密碼至少要一個數字和一個英文字母");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("姓名必填");

            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("性別必填");

            RuleFor(x => x.AreaName)
                .NotEmpty().WithMessage("所在省份必填");

            RuleFor(x => x.CityName)
                .NotEmpty().WithMessage("所在城市必填");
        }
    }
}
