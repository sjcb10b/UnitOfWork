using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using UnitOfWork.Data.Base;
using UnitOfWork.Models;

namespace UnitOfWork.Data.Services
{
    public class ProductServices : EntityBaseRepository<Products>, IProductServices
    {
        private readonly ApplicationDbContext _context;

        public ProductServices(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        
        public async Task<Products> GetProductsAsync(int Id)
        {
            var product = await _context.products.FirstOrDefaultAsync(x => x.Id == Id);
            return product;
        }


       


        public async Task AddProductAsync(Products data)
        {
            var newProduct = new Products
            {
                Title = data.Title,
                Description = data.Description,
                Price = data.Price,
                Qty = data.Qty,

                CreatedDate = data.CreatedDate,
            };
            await _context.products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
        }
        
        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            var allproducts = await _context.products.ToListAsync();
            return allproducts;
        }


        public async Task<IEnumerable<Products>> MediumProducts()
        {
            int recordCount = 8;
            var allproducts = await _context.products.Take(recordCount).ToListAsync();
            return allproducts;

        }




        public async Task<bool> DeleteProductAsync(int Id)
        {
        
            if (Id > 0)
            {
                var prod = await _context.products.FirstOrDefaultAsync(n => n.Id == Id);
                if (prod != null)
                {
                    _context.products.Remove(prod);
                    await _context.SaveChangesAsync();
                    return true;
                }
                
            }
            return false;
        
        
        }

        

       

        public async Task UpdateProductAsync(Products data)
        {
            var result = await _context.products.FirstOrDefaultAsync(n => n.Id == data.Id);
            if(result != null)
            {
                result.Title = data.Title;
                result.Description = data.Description;
                result.Price = data.Price;
                result.Qty = data.Qty;
                result.CreatedDate = data.CreatedDate;
                await _context.products.AddAsync(result);
                await _context.SaveChangesAsync();

            }


        }

       

        //public async Task<Products> GetProductsSlugAsync(string slug)
        //{
        //    var allp = await _context.products.FirstOrDefaultAsync(n => n.slug == slug);
        //    return allp;

        //}
    }
}
