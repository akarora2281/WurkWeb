namespace Wurk.Core.Services
{
    using System.Collections.Generic;
    using Wurk.Core.Contracts;
    using Wurk.Core.Mapping;
    using Wurk.Infrastructure.Data.Models;
    using Wurk.Infrastructure.Data.Repositories;
    public class SettingsService : ISettingsService
    {
        private readonly IAppRepository _settingsRespository;

        public SettingsService(IAppRepository settingsRespository)
        {
            this._settingsRespository = settingsRespository;
        }

        public IEnumerable<T> GetAll<T>() => this._settingsRespository.All<Setting>().To<T>().ToList();

        public int GetCount() => this._settingsRespository.All<Setting>().Count();
    }
}