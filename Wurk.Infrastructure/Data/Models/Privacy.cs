namespace Wurk.Infrastructure.Data.Models
{ 
    using System.ComponentModel.DataAnnotations;
    using Wurk.Infrastructure.Data.Common.Models;
    using static Wurk.Common.GlobalConstants.Privacy;

    public class Privacy : BaseDeletableModel<int>
    {
      [Required]
      [MaxLength(PageContentMaxLength)]
      public string PageContent { get; set; }
    }
}
