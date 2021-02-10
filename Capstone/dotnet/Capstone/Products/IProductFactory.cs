namespace Capstone.Products
{
    public interface IProductFactory
    {
        Product MakeProduct(string productName, decimal price, string productType, int initialQuantity);
    }
}
