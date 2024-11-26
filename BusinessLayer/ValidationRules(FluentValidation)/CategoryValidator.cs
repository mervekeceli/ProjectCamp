using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules_FluentValidation_
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator() 
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş olamaz!");
            RuleFor(x=>x.CategoryDescription).NotEmpty().WithMessage("Açıklama boş olamaz!");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("3 karakterden az değer girişi yapamazsınız!");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("50 karakterden fazla değer girişi yapamazsınız!");
        }
    }
}
