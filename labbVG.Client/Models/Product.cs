namespace labbVG.Client.Models;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? ImageUrl { get; set; }
    public int PriceInUsd { get; set; }
    public int? QuantityInStock { get; set; }
    public Product(string name, string description, string? imageUrl, int priceInUsd, int? quantityInStock) => 
        (Name, Description, ImageUrl, PriceInUsd, QuantityInStock) = 
        (name, description, imageUrl, priceInUsd, quantityInStock);
}