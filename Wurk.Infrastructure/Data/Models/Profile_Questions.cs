namespace Wurk.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Wurk.Infrastructure.Data.Common.Models;
    using Wurk.Infrastructure.Data.Models.Enumeration;

    public class Profile_Questions : BaseDeletableModel<int>
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public Questions_Category QuestionCategory { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }
    }
}
