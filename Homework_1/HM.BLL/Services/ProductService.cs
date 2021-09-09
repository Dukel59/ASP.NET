using HM.BLL.Interfaces;
using HM.BLL.ViewModels.Product;
using HM.DAL.Patterns;
using HM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.BLL.Services
{
    public class ProductService : IProductService
    {
        public ProductService(IUnitOfWork _db)
        {
            db = _db;
        }
        private readonly IUnitOfWork db;

        public async Task<Guid> CreateProductAsync(CreateProduct product)
        {
            try
            {
                var dbProduct = new Product()
                {
                    Name = product.Name,
                    Category = product.Category
                };
                dbProduct = await db.Products.CreateAsync(dbProduct);
                return dbProduct.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CreateProduct> FindProductsByFunc(Func<Product, bool> func)
        {
            try
            {
                var dbProducts = db.Products.GetAll().Where(func).Select(m =>
                {
                    return new CreateProduct()
                    {
                        Name = m.Name,
                        Category = m.Category
                    };
                }).ToList();

                return dbProducts;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
