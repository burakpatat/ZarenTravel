using Microsoft.Extensions.Localization;
using WordyWellHero.Domain.Entities.ExtendedAttributes;
using WordyWellHero.Domain.Entities.Misc;

namespace WordyWellHero.Application.Validators.Features.ExtendedAttributes.Commands.AddEdit
{
    public class AddEditDocumentExtendedAttributeCommandValidator : AddEditExtendedAttributeCommandValidator<int, int, Document, DocumentExtendedAttribute>
    {
        public AddEditDocumentExtendedAttributeCommandValidator(IStringLocalizer<AddEditExtendedAttributeCommandValidatorLocalization> localizer) : base(localizer)
        {
            // you can override the validation rules here
        }
    }
}