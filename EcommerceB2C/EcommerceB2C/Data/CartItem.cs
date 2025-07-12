namespace EcommerceB2C.Data;

public class CartItem
{
    public Product Product { get; set; } = new();
    public int Quantity { get; set; }
}
