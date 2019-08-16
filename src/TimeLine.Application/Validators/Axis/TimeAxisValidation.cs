using Abp.Localization;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TimeLine.Axis.Dto;

namespace TimeLine.Validators.Axis
{
    public class TimeAxisValidator : AbstractValidator<CreateAxisDto>
    {
        public TimeAxisValidator(ILocalizationManager _localizationManager)
        {
            var emptyMessage = _localizationManager.GetString("local", "EmptyError");

            RuleFor(x => x.title).NotEmpty()
                .WithMessage(string.Format(emptyMessage, "title"));
        }
    }

    public class RemoveAuthorityValidator : AbstractValidator<RemoveAuthorityDto>
    {
        public RemoveAuthorityValidator(ILocalizationManager _localizationManager)
        {
            var emptyMessage = _localizationManager.GetString("local", "EmptyError");
            RuleFor(x => x.AuthorizeType).NotEmpty()
                .WithMessage(string.Format(emptyMessage, "AuthorizeType"));
        }
    }
}
