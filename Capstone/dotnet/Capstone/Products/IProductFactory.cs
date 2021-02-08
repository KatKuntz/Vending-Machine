namespace Capstone.Products
{
    public interface IProductFactory
    {
        public Product MakeProduct(string productName, decimal price, string productType, int initialQuantity);
    }
}
