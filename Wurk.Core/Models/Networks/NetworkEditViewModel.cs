namespace Wurk.Core.Models.Administrator
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;
    using static Wurk.Common.GlobalConstants.BlogPost;
    using static Wurk.Common.GlobalConstants.DisplayNames;
    using static Wurk.Common.MessageConstants;

    public class NetworkEditViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        [MinLength(TitleMinLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(ContentMaxLength)]
        [MinLength(ContentMinLength)]
        public string Tags { get; set; }

        [Required]
        [MaxLength(ContentMaxLength)]
        [MinLength(ContentMinLength)]
        public string Description { get; set; }

        public int EmployeeId { get; set; }
    }
}
