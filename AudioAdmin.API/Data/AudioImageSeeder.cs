using AudioAdmin.API.Data;
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
                var dtoProductImages = JsonConvert.DeserializeObject<IEnumerable<Dtos.product_image>>(json);
                var productImages = ConvertToProductImages(dtoProductImages);
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

            if (!_context.Customers.Any())
            {
                var filepath = Path.Combine(_hosting.ContentRootPath, "Resources/customers_one.json");
                var json = File.ReadAllText(filepath);
                var customers = JsonConvert.DeserializeObject<IEnumerable<Dtos.customer>>(json);
                IEnumerable<Customer> Customers = ConvertToCustomers(customers);
                _context.Customers.AddRange(Customers);
                _context.SaveChanges();
            }
        }

        private IEnumerable<Customer> ConvertToCustomers(IEnumerable<Dtos.customer> dtoCustomers)
        {
            var customers = new List<Customer>();

            foreach (var cust in dtoCustomers)
            {
                var customer = new Customer
                {
                    Id = cust.id,
                    Address = cust.address,
                    Address2 = cust.address_2,
                    AssociatedCustomerId = cust.associated_customer_id,
                    AssociatedEmployeeId = cust.associated_employee_id, 
                    AssociatedLocation = cust.associated_location,
                    BillAddress = cust.bill_address,
                    BillAddress2 = cust.bill_address_2,
                    BillAddressDifferent = cust.bill_address_different,
                    BillCity = cust.bill_city,
                    BillState = cust.bill_state,
                    BillZipCode = cust.bill_zip_code,
                    City = cust.city,
                    CompanyName = cust.company_name,
                    CreatedAt = cust.created_at,
                    DateAdded = cust.date_added,
                    Email1 = cust.email_1,
                    Email2 = cust.email_2,
                    Email3 = cust.email_3,
                    FirstName = cust.first_name,
                    GateCode = cust.gate_code,
                    IsNotExportedContact = cust.is_not_export_contact,
                    IsRegisteredToC4 = cust.is_registered_to_c4,
                    LastName = cust.last_name,
                    Latitude = cust.latitude,
                    Longitude = cust.longitude,
                    Notes = cust.notes,
                    Phone1Extension = cust.phone_1_extension,
                    Phone2Extension = cust.phone_2_extension,
                    Phone3Extension = cust.phone_3_extension,
                    Password = cust.password,
                    Phone1Description = cust.phone_1_description,
                    Phone2Description = cust.phone_1_description,
                    Phone3Description = cust.phone_1_description,
                    Phone1Value = cust.phone_1_value,
                    Phone2Value = cust.phone_2_value,
                    Phone3Value = cust.phone_3_value,
                    SmallNote = cust.small_note,
                    State = cust.state,
                    TaxId = cust.tax_id,
                    TaxIdImage = cust.tax_id_image,
                    UpdatedAt = cust.updated_at,
                    Username = cust.username,
                    ZipCode = cust.zip_code
                };
                customers.Add(customer);
            }

            return customers;
        }

        // Used to read snake variable names from a JSON file
        private IEnumerable<ProductImage> ConvertToProductImages(IEnumerable<Dtos.product_image> product_images)
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

        public string ReadImageFile(string path)
        {
            byte[] imageArray = System.IO.File.ReadAllBytes(path);
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);

            return base64ImageRepresentation;
        }
    }
}