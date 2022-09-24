using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Dtos;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static IMapper mapper;
        public static void Main(string[] args)
        {
            var db = InitializeData();
            Console.WriteLine(GetUsersWithProducts(db));

        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(b => b.Buyer != null))
                .Include(u => u.ProductsSold)
                .ToArray()
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold
                                        .Where(x => x.BuyerId != null)
                                        .Count(),
                        products = u.ProductsSold
                                        .Where(x => x.BuyerId != null)
                                        .Select(p => new
                                        {
                                            p.Name,
                                            p.Price
                                        })
                                        .ToList()
                    }
                })
                .OrderByDescending(u => u.soldProducts.count)
                .ToList();

            dynamic resultObject = new
            {
                usersCount = users.Count(),
                users
            };


            var usersAsJson = JsonConvert.SerializeObject(resultObject, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            });

            return usersAsJson;
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesByProductsCount = context.Categories
                .Select(c => new
                {
                    Category = c.Name,
                    ProductsCount = c.CategoryProducts
                                    .Count(),
                    AveragePrice = $"{c.CategoryProducts.Average(cp => cp.Product.Price):F2}",
                    TotalRevenue = $"{c.CategoryProducts.Sum(cp => cp.Product.Price):F2}"
                })
                .OrderByDescending(c => c.ProductsCount)
                .ToList();

            var usersAsJson = JsonConvert.SerializeObject(categoriesByProductsCount, jsonSerializerSettings());

            return usersAsJson;
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProducts = context.Users
                .Where(p => p.ProductsSold.Any(y => y.BuyerId != null))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    SoldProducts = u.ProductsSold
                    .Select(ps => new
                    {
                        ps.Name,
                        ps.Price,
                        BuyerFirstName = ps.Buyer.FirstName,
                        BuyerLastName = ps.Buyer.LastName
                    })
                    .ToList()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToList();

            var serializedUsers = JsonConvert.SerializeObject(soldProducts, jsonSerializerSettings());

            return serializedUsers;
        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context.Products
                                          .Where(p => p.Price >= 500 && p.Price <= 1000)
                                          .Select(p => new
                                          {
                                              p.Name,
                                              p.Price,
                                              Seller = p.Seller.FirstName + ' ' + p.Seller.LastName
                                          })
                                          .OrderBy(p => p.Price)
                                          .ToList();


            var jsonSettings = jsonSerializerSettings();

            var serializedProducts = JsonConvert.SerializeObject(productsInRange, jsonSettings);

            return $"{serializedProducts}";
        }
      
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(inputJson);

            InitializeMapper();

            var mappedUsers = mapper.Map<IEnumerable<User>>(users);

            context.Users.AddRange(mappedUsers);
            context.SaveChanges();

            return $"Successfully imported {mappedUsers.Count()}";
        }
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(inputJson);

            InitializeMapper();

            var mappedProducts = mapper.Map<IEnumerable<Product>>(products);

            context.Products.AddRange(mappedProducts);
            context.SaveChanges();

            return $"Successfully imported {mappedProducts.Count()}";
        }
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<IEnumerable<CategoryDto>>(inputJson)
                        .Where(c => c.Name != null);
            InitializeMapper();

            var mappedCategories = mapper.Map<IEnumerable<Category>>(categories);

            context.Categories.AddRange(mappedCategories);
            context.SaveChanges();

            return $"Successfully imported {mappedCategories.Count()}";
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var catProds = JsonConvert.DeserializeObject<IEnumerable<CategoryProductsInputDto>>(inputJson);
            InitializeMapper();

            var mappedCategProds = mapper.Map<IEnumerable<CategoryProduct>>(catProds);

            context.CategoryProducts.AddRange(mappedCategProds);
            context.SaveChanges();

            return $"Successfully imported {mappedCategProds.Count()}";
        }
       
        public static JsonSerializerSettings jsonSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };
        }
        private static ProductShopContext InitializeData()
        {
            var context = new ProductShopContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var usersJsonString = File.ReadAllText("../../../Datasets/users.json");
            var productsJsonString = File.ReadAllText("../../../Datasets/products.json");
            var categoriesJsonString = File.ReadAllText("../../../Datasets/categories.json");
            var categoriesproductsJsonString = File.ReadAllText("../../../Datasets/categories-products.json");

            Console.WriteLine(ImportUsers(context, usersJsonString));
            Console.WriteLine(ImportProducts(context, productsJsonString));
            Console.WriteLine(ImportCategories(context, categoriesJsonString));
            Console.WriteLine(ImportCategoryProducts(context, categoriesproductsJsonString));

            return context;
        }
        private static void InitializeMapper()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = new Mapper(mapperConfig);
        }
    }
}
