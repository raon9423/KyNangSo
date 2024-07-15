using System;
using WebAppCore.Models;

namespace WebAppCore.ModelViews
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Amount { get; set; }

        public double TotalMoney
        {
            get
            {
                return Amount * Product?.Price ?? 0.0;
            }
        }

        public CartItem(Product product, int amount
            )
        {
            Product = product;
            Amount = amount;
        }
    }
}
