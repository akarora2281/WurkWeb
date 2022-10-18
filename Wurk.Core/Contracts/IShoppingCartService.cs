namespace Wurk.Core.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Wurk.Core.Models.ShoppingCart;

    public interface IShoppingCartService
    {
        IEnumerable<ShoppingCartViewModel> AddArt(int artId, string userId, decimal price);

        void BuyArts(string userId);

        IEnumerable<ShoppingCartViewModel> GetArts(string userId);

        void IncreaseQuatity(string artId, bool isIncreased);

        Task ClearCartAsync(string userId);
    }
}
