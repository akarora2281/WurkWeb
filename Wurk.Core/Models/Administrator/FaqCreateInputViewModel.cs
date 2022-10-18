namespace Wurk.Core.Models.Administrator
{
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;
    using static Wurk.Common.GlobalConstants.FaqEntity;
    using static Wurk.Common.MessageConstants;

    public class FaqCreateInputViewModel
    {
        [Required(ErrorMessage = EmptyField)]
        [MaxLength(QuestionMaxLength)]
        [MinLength(QuestionMinLength)]
        [BindProperty]
        public string Question { get; set; }

        [Required(ErrorMessage = EmptyField)]
        [MaxLength(AnswerMaxLength)]
        [MinLength(AnswerMinLength)]
        [BindProperty]

        public string Answer { get; set; }
    }
}
