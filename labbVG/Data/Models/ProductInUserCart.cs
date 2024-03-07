using labbVG.Client.Models;

namespace labbVG.Data.Models;

public class ProductInUserCart 
{
    public int Id { get; set; }
    public ApplicationUser User { get; set; }
    public Product Product { get; set; }
}