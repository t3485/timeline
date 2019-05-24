using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TimeLine.Axis.Dto;

namespace TimeLine.Validators.Axis
{
    public class TimeAxisValidator: AbstractValidator<CreateAxisDto>
    {
        public TimeAxisValidator()
        {
            RuleFor(x => x.title).NotEmpty().WithMessage("dsfasfd");
        }
    }
}
