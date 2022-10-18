namespace Wurk.Core.Models.Administrator
{
    using System.ComponentModel.DataAnnotations;
    using static Wurk.Common.MessageConstants;
    using static Wurk.Common.GlobalConstants.FaqEntity;

    public class FaqEditViewModel
    {
        public int FaqId { get; set; }

        [Required(ErrorMessage = EmptyField)]
        [MaxLength(QuestionMaxLength)]
        [MinLength(QuestionMinLength)]
        public string Question { get; set; }

        [Required(ErrorMessage = EmptyField)]
        [MaxLength(AnswerMaxLength)]
        [MinLength(AnswerMinLength)]
        public string Answer { get; set; }
    }
}
