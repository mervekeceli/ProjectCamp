using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules_FluentValidation_
{
    public class CategoryValidatior : AbstractValidator<Category>
    {
        public CategoryValidatior() 
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş olamaz!");
            RuleFor(x=>x.CategoryDescription).NotEmpty().WithMessage("Açıklama boş olamaz!");
            RuleFor(x => x.CategoryName).Length(50).WithMessage("50 karakterden fazla değer girişi yapamazsınız!");
        }
    }
}
