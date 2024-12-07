﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules_FluentValidation_
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresini boş geçemezsiniz!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu boş geçemezsiniz!");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj içeriğini boş geçemezsiniz!");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın!");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lütfen 50 karekterden fazla değer girişi yapmayın!");
            RuleFor(x => x.SenderMail).EmailAddress().WithMessage("Geçerli bir e-posta adresi girin!");
        }
    }
}