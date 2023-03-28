using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using API.Enums;
using Entities.Entities;

namespace Resource.RequestModels
{
    public class NewProductRequest
    {
        public IFormFile File { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
        public FileExtensionEnum FileExtension { get; set; }
        public int Id { get; set; }

        public ProductItem ToProductItem()
        {
            var productItem = new ProductItem();
            {
                productItem.Id = 0;
                productItem.Name = Name;
                productItem.Category = Category;
                productItem.Brand = Brand;
                productItem.Description = Description;
                productItem.InsertDate = DateTime.Now;
                productItem.UpdateDate = DateTime.Now;
                productItem.FileExtension = FileExtension;
                productItem.IsActive = IsActive;
            }

            // Convert the image content to a byte array
            using (var stream = new MemoryStream())
            {
                File.CopyToAsync(stream);
                byte[] bytes = stream.ToArray();
                productItem.Content = Convert.ToBase64String(bytes);
            }

            return productItem;

        }
    }
}

