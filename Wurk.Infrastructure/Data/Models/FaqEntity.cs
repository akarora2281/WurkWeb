namespace Wurk.Infrastructure.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Wurk.Infrastructure.Data.Common.Models;
    using static Wurk.Common.GlobalConstants.FaqEntity;

    public class FaqEntity : BaseDeletableModel<int>
    {
        // Faq could be only created and updated from admin.
        // User are only able to read.
        [Required]
        [MaxLength(QuestionMaxLength)]
        public string Question { get; set; }

        [Required]
        [MaxLength(AnswerMaxLength)]
        public string Answer { get; set; }
    }
}
