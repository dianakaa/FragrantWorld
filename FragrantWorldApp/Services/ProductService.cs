using FragrantWorldApp.Data;
using FragrantWorldApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FragrantWorldApp.Services
{
    public class ProductService
    {
        private readonly FragrantWorldContext _context;

        public ProductService(FragrantWorldContext context)
        {
            _context = context;
        }

        // Метод для получения всех продуктов
        public async Task<List<Product>> GetProductsAsync()
        {
            using var context = new FragrantWorldContext();
            return await _context.Products.ToListAsync();
        }
    }
}
