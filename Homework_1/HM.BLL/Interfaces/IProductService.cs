using HM.BLL.ViewModels.Product;
using HM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HM.BLL.Interfaces
{
    public interface IProductService
    {
        Task<Guid> CreateProductAsync(CreateProduct product);  //вернем ID созданного продукта
        List<CreateProduct> FindProductsByFunc(Func<Product, bool> func);
    }
}
