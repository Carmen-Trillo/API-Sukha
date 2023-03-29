using Data;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;
using Microsoft.EntityFrameworkCore;
using Resource.RequestModels;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Logic
{
    public class ProductLogic : IProductLogic
    {
        private readonly ServiceContext _serviceContext;
        public ProductLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        public async Task<int> InsertProductAsync(ProductItem productItem)
        {
            await _serviceContext.Products.AddAsync(productItem);
            await _serviceContext.SaveChangesAsync();
            return productItem.Id;
        }

        public async Task UpdateProductAsync(ProductItem productItem)
        {
            _serviceContext.Products.Update(productItem);
            await _serviceContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var productToDelete = await _serviceContext.Set<ProductItem>()
                .Where(u => u.Id == id).FirstAsync();

            productToDelete.IsActive = false;

            await _serviceContext.SaveChangesAsync();
        }

        public async Task DeleteProductMarcaAsync(string brand)
        {
            var productMarcaToDelete = await _serviceContext.Set<ProductItem>()
                .Where(u => u.Brand == brand).FirstAsync();

            productMarcaToDelete.IsActive = false;

            await _serviceContext.SaveChangesAsync();
        }

        public async Task<List<ProductItem>> GetAllProductsAsync()
        {
            return await _serviceContext.Set<ProductItem>().ToListAsync();
        }

        public async Task<List<ProductItem>> GetProductsByCriteriaAsync(ProductFilter productFilter)
        {
            var resultList = _serviceContext.Set<ProductItem>()
                                        .Where(u => u.IsActive == true);

            //.Where(u => u.Marca = productFilter.Marca);

            if (productFilter.InsertDateFrom != null)
            {
                resultList = resultList.Where(u => u.InsertDate > productFilter.InsertDateFrom);
            }

            if (productFilter.InsertDateTo != null)
            {
                resultList = resultList.Where(u => u.InsertDate < productFilter.InsertDateTo);
            }
            if (productFilter.PriceFrom != null)
            {
                resultList = resultList.Where(u => u.Price > productFilter.PriceFrom);
            }

            if (productFilter.PriceTo != null)
            {
                resultList = resultList.Where(u => u.Price < productFilter.PriceTo);
            }

            return await resultList.ToListAsync();
        }

        public async Task<List<ProductItem>> GetProductsByBrandAsync(string brand)
        {
            var resultList = await _serviceContext.Set<ProductItem>()
                        .Where(p => p.Brand == brand).ToListAsync();
            return resultList;
        }

        


        public async Task<List<ProductItem>> GetProductsByCategoryAsync(string category)
        {
            var resultList = await _serviceContext.Set<ProductItem>()
                        .Where(p => p.Category == category).ToListAsync();
            return resultList;
        }
    }
}
