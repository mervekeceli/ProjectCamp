using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules_FluentValidation_
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş olamaz!");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar soyadı boş olamaz!");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında kısmı boş olamaz!");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("2 karakterden az değer girişi yapamazsınız!");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("50 karakterden fazla değer girişi yapamazsınız!");
            RuleFor(x => x.WriterSurName).MinimumLength(2).WithMessage("2 karakterden az değer girişi yapamazsınız!");
            RuleFor(x => x.WriterSurName).MaximumLength(50).WithMessage("50 karakterden fazla değer girişi yapamazsınız!");
        }
    }
}
