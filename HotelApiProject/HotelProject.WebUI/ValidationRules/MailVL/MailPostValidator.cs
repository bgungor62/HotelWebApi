using FluentValidation;
using HotelProject.WebUI.Models.Mail;

namespace HotelProject.WebUI.ValidationRules.MailVL
{
    public class MailPostValidator : AbstractValidator<AdminMailViewModel>
    {
        public MailPostValidator()
        {
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Geçerli Bir Mail adresi giriniz!").NotEmpty().WithMessage("Alıcı mail alanı boş olamaz!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanı boş olamaz, kontrol ediniz!").MinimumLength(5).WithMessage("En az 5 karakter olabilir konu başlığı").MaximumLength(20).WithMessage("En fazla 20 karakter olabilir..");

            RuleFor(x => x.Body).NotEmpty().WithMessage("Lütfen içerik alanının boş olmadığından emin olunuz!").MinimumLength(20).WithMessage("En az 20 karakter olmalıdır!").MaximumLength(100).WithMessage("En fazla 100 karakter olabilir!");
        }
    }
}
