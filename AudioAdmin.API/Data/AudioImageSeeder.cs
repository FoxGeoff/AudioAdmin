using AudioAdmin.API.Data.Entities;
using Microsoft.AspNetCore.Hosting;
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

        public void Seed()
        {
            
            if (!_context.ProductImages.Any())
            {
                var filepath = Path.Combine(_hosting.ContentRootPath, "Resources/product_images.json");
                var json = File.ReadAllText(filepath);
                var productImages = JsonConvert.DeserializeObject<IEnumerable<ProductImage>>(json);
                productImages = ConvertImagesBase64ToBinary(productImages);
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

        /* The seed file is .Json this method ensures
         * that the string representation is stored in 
         * the database as a binary image and not text
         * to match the legacy data
         */

        public IEnumerable<ProductImage> ConvertImagesBase64ToBinary(IEnumerable<ProductImage> productImages)
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

        public IEnumerable<Customer> ConvertImagesBase64ToBinary(IEnumerable<Customer> customerImages)
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