namespace Wurk.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Wurk.Infrastructure.Data.Common.Models;
    using Wurk.Infrastructure.Data.Models.Enumeration;
    using static Wurk.Common.GlobalConstants.BlogPost;

    public class Network : BaseDeletableModel<int>
    {
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        public string Description { get; set; }

        [MaxLength(ContentMaxLength)]
        public string Tags { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }

        public int EmployerId { get; set; }
    }
}
