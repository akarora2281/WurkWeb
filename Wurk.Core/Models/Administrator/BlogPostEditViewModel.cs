namespace Wurk.Core.Models.Administrator
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;
    using static Wurk.Common.GlobalConstants.BlogPost;
    using static Wurk.Common.GlobalConstants.DisplayNames;
    using static Wurk.Common.MessageConstants;

    public class BlogPostEditViewModel 
    {
        [Required]
        [MaxLength(TitleMaxLength)]
        [MinLength(TitleMinLength)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string UrlImage { get; set; }

        [Required(ErrorMessage = EmptyField)]
        [DataType(DataType.Upload)]
        [Display(Name = CoverImageDisplayName)]
        public IFormFile CoverImage { get; set; }

        [Required]
        [MaxLength(ContentMaxLength)]
        [MinLength(ContentMinLength)]
        public string Content { get; set; }
    }
}
