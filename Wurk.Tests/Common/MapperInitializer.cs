namespace Wurk.Test.Common
{
    using Wurk.Core.Mapping;
    using Wurk.Core.Models.Users;
    using Wurk.Infrastructure.Data.Models;
    using System.Reflection;
    public class MapperInitializer
    {
        public void InitializerMapper()
        {
            AutoMapperConfig
            .RegisterMappings(
            typeof(UserViewModel).GetTypeInfo().Assembly,
            typeof(ArtGalleryUser).GetTypeInfo().Assembly);

         
        }
    }
}
