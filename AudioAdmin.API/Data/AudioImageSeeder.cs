using AudioAdmin.API.Data.Dtos;
using AudioAdmin.API.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AudioAdmin.API.Data
{
    public class AudioImageSeeder
    {
        private readonly AudioDbContext _context;
        private readonly IHostingEnvironment _hosting;

        public AudioImageSeeder(AudioDbContext context, IHostingEnvironment hosting)
        {
            _context = context;
            _hosting = hosting;
        }

        public static void InitializeData(IServiceProvider services, ILoggerFactory loggerFactory)
        {
            var logger = loggerFactory.CreateLogger("SampleData");

            using (var serviceScope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var env = serviceScope.ServiceProvider.GetService<IHostingEnvironment>();
                if (!env.IsDevelopment()) { return; }

                var seederManager = serviceScope.ServiceProvider.GetRequiredService<AudioImageSeeder>();
                seederManager.Seed();
                logger.LogInformation($"==> Seed Product data has been added to the development database");
            }
        }

        public void Seed()
        {
            
            if (!_context.ProductImages.Any())
            {
                var filepath = Path.Combine(_hosting.ContentRootPath, "Resources/product_images.json");
                var json = File.ReadAllText(filepath);
                var product_images = JsonConvert.DeserializeObject<IEnumerable<product_image>>(json);
                var productImages = ConvertToProductImage(product_images);
                //productImages = ConvertImagesBase64ToBinary(productImages);
                _context.ProductImages.AddRange(productImages);
                _context.SaveChanges();
            }

            ////if (!_context.Products.Any())
            ////{
            ////    var filepath = Path.Combine(_hosting.ContentRootPath, "Data/product_mod.json");
            ////    var json = File.ReadAllText(filepath);
            ////    var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
            ////    _context.Products.AddRange(products);
            ////    _context.SaveChanges();
            ////}


            //TODO: fix customer data file
            ////if (!_context.Customers.Any())
            ////{
            ////    var filepath = Path.Combine(_hosting.ContentRootPath, "Data/customers_one.json");
            ////    var json = File.ReadAllText(filepath);
            ////    var customers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(json);
            ////    customers = ConvertImagesBase64ToBinary(customers);
            ////    _context.Customers.AddRange(customers);
            ////    _context.SaveChanges();
            ////}
        }

        // Used to read snake variable names from a JSON file
        private IEnumerable<ProductImage> ConvertToProductImage(IEnumerable<product_image> product_images)
        {
            var productImages =  new List<ProductImage>();

            foreach (var prod in product_images)
            {
                var productImage = new ProductImage
                {
                    Id = prod.id,
                    DateUpdated = prod.date_updated,
                    FileName = prod.file_name,
                    ImageFull = prod.image_full,
                    ImageThumb = prod.image_thumb 
                };

                productImages.Add(productImage);
            }

            return productImages;
        }

        // TODO: Remove no references
        private byte[] TrimByteArray(byte[] data)
        {
            bool data_found = false;
            byte[] new_data = data.Reverse().SkipWhile(point =>
            {
                if (data_found) return false;
                if (point == 0xff) return true; else { data_found = true; return false; } //0x00
            }).Reverse().ToArray();

            return new_data;
        }

        /* The seed file is .Json this method ensures
         * that the string representation is stored in 
         * the database as a binary image and not text
         * to match the legacy data
         */

        // TODO: Remove no references
        private IEnumerable<ProductImage> ConvertImagesBase64ToBinary(IEnumerable<ProductImage> productImages)
        {
            foreach (var product in productImages)
            {
                var imageString = Convert.ToBase64String(product.ImageFull);
                var imageArray = Convert.FromBase64String(imageString);
                product.ImageFull = imageArray;

                var imageStringThb = Convert.ToBase64String(product.ImageThumb);
                var imageArrayThb = Convert.FromBase64String(imageString);
                product.ImageThumb = imageArrayThb;
            }

            return productImages;
        }

        // TODO: Remove no references
        private IEnumerable<Customer> ConvertImagesBase64ToBinary(IEnumerable<Customer> customerImages)
        {
            foreach (var customer in customerImages)
            {
                var imageString = Convert.ToBase64String(customer.Password);
                var imageArray = Convert.FromBase64String(imageString);
                customer.Password = imageArray;

                var imageTaxId = Convert.ToBase64String(customer.TaxIdImage);
                var imageArrayThb = Convert.FromBase64String(imageString);
                customer.TaxIdImage = imageArrayThb;
            }

            return customerImages;
        }


        public string ReadImageFile(string path)
        {
            byte[] imageArray = System.IO.File.ReadAllBytes(path);
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);

            return base64ImageRepresentation;
        }
    }
}