using System;
using System.Collections.Generic;
using System.Linq;
using EcommerceB2C.Data;

public class CartService
{
    public List<CartItem> Items { get; } = new();

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();

    public void AddToCart(Product product)
    {
        var existingItem = Items.FirstOrDefault(i => i.Product.Id == product.Id);
        if (existingItem != null)
        {
            existingItem.Quantity++;
        }
        else
        {
            Items.Add(new CartItem { Product = product, Quantity = 1 });
        }

        NotifyStateChanged();
    }

    public void RemoveFromCart(Product product)
    {
        var item = Items.FirstOrDefault(i => i.Product.Id == product.Id);
        if (item != null)
        {
            Items.Remove(item);
            NotifyStateChanged();
        }
    }

    public decimal GetTotal()
    {
        return Items.Sum(i => i.Product.Price * i.Quantity);
    }

    public void ClearCart()
    {
        Items.Clear();
        NotifyStateChanged();
    }
}
