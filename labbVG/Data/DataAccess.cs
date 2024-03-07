using labbVG.Client.Classes;
using labbVG.Client.Interfaces;
using labbVG.Client.Models;
using labbVG.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace labbVG.Data;

public class DataAccess : IDataAccess
{
    private readonly ApplicationDbContext _context;
    public DataAccess(ApplicationDbContext applicationDbContext) => _context = applicationDbContext;

    public async Task<List<Product>> GetAllProducts() {
        var products = await _context.Products.ToListAsync();
        return products;
    }
    public async Task<Product?> GetProduct(int id) {
        var product = await _context.Products.FindAsync(id); 
        return product;
    }
    public async Task AddToUserCart(ApplicationUser user, Product product) {
        await _context.ProductsInUserCart.AddAsync(new ProductInUserCart {User = user, Product = product});
        await _context.SaveChangesAsync();
    }
    public async Task<List<Product>> GetUserCart(string userId) {
        var productsInCart = await _context.ProductsInUserCart
                                .Include(p => p.Product)
                                .Where(p => p.User.Id == userId)
                                .ToListAsync();
        List<Product> products = [];
        foreach(var p in productsInCart) {
            products.Add(p.Product);
        }
        return products;
    }
    public async Task ClearUserCart(string userId) {        
        foreach(var productInCart in _context.ProductsInUserCart.Where(p => p.User.Id == userId))
        _context.ProductsInUserCart.Remove(productInCart);
        await _context.SaveChangesAsync();
    }
    public async Task FinalizePurhcase(string userId) {
        var userCart = await GetUserCart(userId);
        foreach(var productInCart in userCart.GroupBy(p => p.Name)) {
            _context.Products.Single(p => p.Name == productInCart.Key).QuantityInStock -= productInCart.Count();
        }
        await ClearUserCart(userId);
        await _context.SaveChangesAsync();
    }
    public async Task CreateExampleData() {
        var products = await _context.Products.ToListAsync();
        if(products.Count == 0) {
            await _context.Products.AddAsync(new Product("Phone","Cool phone","images/phone.jpg",200,100));
            await _context.Products.AddAsync(new Product("MacBook","Good laptop","images/macbook.jpg",2000,50));
            await _context.Products.AddAsync(new Product("Apple Watch","Tells the time","images/watch.jpg",100,75));
            await _context.Products.AddAsync(new Product("Headphones","Good quality audio","images/headphones.jpg",50,150));
            await _context.Products.AddAsync(new Product("Car","Fast car","images/car.jpg",10000,20));
            await _context.SaveChangesAsync();
        }
    }
}
