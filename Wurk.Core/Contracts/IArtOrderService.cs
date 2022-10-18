namespace Wurk.Core.Contracts
{
    using Wurk.Core.Models.ArtStore;
    public interface IArtOrderService
    {
        Task CreateOrder(ArtOrderViewModel model);

        Task<bool> ReceivedOrder(string artId);

        Task<bool> CancleOrder(string artId);
    }
}
