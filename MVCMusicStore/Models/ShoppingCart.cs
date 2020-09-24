using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVCMusicStore.Models
{
    public class ShoppingCart
    {
        private readonly MusicStoreContext _dbContext;
        private readonly string _shoppingCartId;

        private ShoppingCart(MusicStoreContext dbContext, string id)
        {
            _dbContext = dbContext;
            _shoppingCartId = id;
        }

        public static ShoppingCart GetCart(MusicStoreContext db, HttpContext context)
            => GetCart(db, GetCartId(context));

        public static ShoppingCart GetCart(MusicStoreContext db, string cartId)
            => new ShoppingCart(db, cartId);

        public async Task AddToCart(Album album)
        {
            var cartItem = await _dbContext.Carts.SingleOrDefaultAsync(
                c => c.CartId == _shoppingCartId
                && c.AlbumId == album.AlbumId);

            if (cartItem == null)
            {
                cartItem = new Cart
                {
                    AlbumId = album.AlbumId,
                    CartId = _shoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };

                _dbContext.Carts.Add(cartItem);
            }
            else
            {
                cartItem.Count++;
            }
        }

        //public int RemoveFromCart(int id)
        //{
        //    
        //    var cartItem = _dbContext.Carts.SingleOrDefault(
        //        cart => cart.CartId == _shoppingCartId
        //        && cart.Cart == id);

        //    int itemCount = 0;

        //    if (cartItem != null)
        //    {
        //        if (cartItem.Count > 1)
        //        {
        //            cartItem.Count--;
        //            itemCount = cartItem.Count;
        //        }
        //        else
        //        {
        //            _dbContext.Carts.Remove(cartItem);
        //        }
        //    }

        //    return itemCount;
        //}

        public async Task EmptyCart()
        {
            var cartItems = await _dbContext
                .Carts
                .Where(cart => cart.CartId == _shoppingCartId)
                .ToArrayAsync();

            _dbContext.Carts.RemoveRange(cartItems);
        }

        public Task<List<Cart>> GetCartItems()
        {
            return _dbContext
                .Carts
                .Where(cart => cart.CartId == _shoppingCartId)
                .Include(c => c.Album)
                .ToListAsync();
        }

        public Task<List<string>> GetCartAlbumTitles()
        {
            return _dbContext
                .Carts
                .Where(cart => cart.CartId == _shoppingCartId)
                .Select(c => c.Album.Title)
                .OrderBy(n => n)
                .ToListAsync();
        }

        public Task<int> GetCount()
        {
            return _dbContext
                .Carts
                .Where(c => c.CartId == _shoppingCartId)
                .Select(c => c.Count)
                .SumAsync();
        }

        public async Task<decimal> GetTotal()
        {
            return (await _dbContext
                .Carts
                .Where(c => c.CartId == _shoppingCartId)
                .Select(c => c.Album.Price * c.Count)
                .ToListAsync())
                .Sum();
        }

        public async Task CreateOrder(Order order)
        {
            decimal orderTotal = 0;

            var cartItems = await GetCartItems();

            foreach (var item in cartItems)
            {
                var album = await _dbContext.Albums.SingleAsync(a => a.AlbumId == item.AlbumId);

                var orderDetail = new OrderDetail
                {
                    AlbumId = item.AlbumId,
                    Order = order,
                    UnitPrice = album.Price,
                    Quantity = item.Count,
                };

                orderTotal += (item.Count * album.Price);

                _dbContext.OrderDetails.Add(orderDetail);
            }

            order.Total = orderTotal;

            await EmptyCart();
        }

        private static string GetCartId(HttpContext context)
        {
            var cartId = context.Session.GetString("Session");

            if (cartId == null)
            {
                cartId = Guid.NewGuid().ToString();

                context.Session.SetString("Session", cartId);
            }

            return cartId;
        }
    }
}
