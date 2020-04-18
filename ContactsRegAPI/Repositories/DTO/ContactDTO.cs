using FluentValidation;
using System;

namespace RepoViewModels
{
    public class ContactDTO
    {
        public string ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class ContactDTOValidator : AbstractValidator<ContactDTO>
    {
        public ContactDTOValidator()
        {
            RuleFor(register => register.FirstName).NotEmpty().WithMessage("FirstName name cannot be empty");
            RuleFor(register => register.LastName).NotEmpty().WithMessage("LastName name cannot be empty");
        }
    }
}
