﻿using FluentValidation;
using Microsoft.Extensions.Localization;
using WordyWellHero.Application.Requests.Identity;

namespace WordyWellHero.Application.Validators.Requests.Identity
{
    public class RoleRequestValidator : AbstractValidator<RoleRequest>
    {
        public RoleRequestValidator(IStringLocalizer<RoleRequestValidator> localizer)
        {
            RuleFor(request => request.Name)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["Name is required"]);
        }
    }
}
