namespace Wurk.Infrastructure.Data.Models
{
    using Wurk.Infrastructure.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;
    using static Wurk.Common.GlobalConstants.ContactForm;

    public class ContactForm : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; init; }

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; init; }

        [Required]
        [EmailAddress]
        public string Email { get; init; }

        [Required]
        [MaxLength(SubjectMaxLength)]
        public string Subject { get; init; }

        [Required]
        [MaxLength(MessageMaxLength)]
        public string Message { get; init; }
    }
}
