using labbVG.Client.Classes;
using labbVG.Client.Models;

namespace labbVG.Client.Interfaces;
public interface IDataAccess 
{
    public Task<List<Product>> GetUserCart(string userId);
}