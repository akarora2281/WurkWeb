namespace Wurk.Infrastructure.Data.Models
{
    using Wurk.Infrastructure.Data.Common.Models;

    public class Setting : BaseDeletableModel<int>
    {
       public string Name { get; set; }

       public string Value { get; set; }
    }
}
