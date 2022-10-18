namespace Wurk.Infrastructure.Data.Common.Models
{
    using Wurk.Data.Common.Models;
    using Wurk.Infrastructure.Data.Common.Models.Contracts;
    using System;

    public abstract class BaseDeletableModel<TKey> : BaseModel<TKey>, IDeletableEntity
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
