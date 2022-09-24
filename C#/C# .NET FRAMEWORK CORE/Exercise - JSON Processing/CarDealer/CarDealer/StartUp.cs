using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        private static IMapper mapper;
        public static void Main(string[] args)
        {
            using (var dbContext = new CarDealerContext())
            {
                dbContext.Database.EnsureCreated();
                Console.WriteLine("DbCreated!");

                string suppliersJsonString = File.ReadAllText("../../../Datasets/suppliers.json");
                string partsJsonString = File.ReadAllText("../../../Datasets/parts.json");
                string carsJsonString = File.ReadAllText("../../../Datasets/cars.json");
                string customersJsonString = File.ReadAllText("../../../Datasets/customers.json");
                string salesJsonString = File.ReadAllText("../../../Datasets/sales.json");




                Console.WriteLine(ImportSuppliers(dbContext, suppliersJsonString));
                Console.WriteLine(ImportParts(dbContext, partsJsonString));
                Console.WriteLine(ImportCars(dbContext, carsJsonString));
                Console.WriteLine(ImportCustomers(dbContext, customersJsonString));
                Console.WriteLine(ImportSales(dbContext, salesJsonString));

                //  Console.WriteLine(GetOrderedCustomers(dbContext));
                Console.WriteLine(GetSalesWithAppliedDiscount(dbContext).Count());

                dbContext.Database.EnsureDeleted();
                Console.WriteLine("DbDeleted!");
            }
        }
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },

                    customerName = s.Customer.Name,
                    Discount = $"{s.Discount:F2}",
                    price = $"{s.Car.PartCars.Select(pc => pc.Part.Price).Sum():F2}",
                    priceWithDiscount = $"{(s.Car.PartCars.Sum(pc => pc.Part.Price)) * (1-(s.Discount / 100)):F2}"
                })
                .Take(10)
                .ToList();

            return JsonConvert.SerializeObject(sales,JsonSettings());
        }
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            InitializeMapper();

            var sales = context.Customers
                            .Where(c => c.Sales.Count() > 0)
                            .Select(c => new
                            {
                                FullName = c.Name,
                                BoughtCars = c.Sales.Count(),
                                SpentMoney = c.Sales.SelectMany(s => s.Car.PartCars)
                                                    .Select(s => s.Part.Price)
                                                    .Sum()
                            })
                            .ToList();


            return JsonConvert.SerializeObject(sales, JsonSettings());
        }
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                                .Select(c => new
                                {
                                    car = new
                                    {
                                        c.Make,
                                        c.Model,
                                        c.TravelledDistance
                                    },
                                    parts = c.PartCars.Select(pc => new

                                    {
                                        Name = pc.Part.Name,
                                        Price = $"{pc.Part.Price:F2}"
                                    })
                                        .ToArray()
                                })
                                .ToList();


            return JsonConvert.SerializeObject(carsWithParts, JsonSettings());

        }
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                                .Where(s => s.IsImporter == false)
                                .ToList();
            InitializeMapper();
            var mappedSupplies = mapper.Map<IEnumerable<SuppliersLocalOutputDTO>>(suppliers);

            return JsonConvert.SerializeObject(mappedSupplies, JsonSettings());
        }
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            InitializeMapper();

            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .ToList();


            var mappedCustomers = mapper.Map<IEnumerable<CustomersOutputDTO>>(customers);



            return JsonConvert.SerializeObject(mappedCustomers, JsonSettings());
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            InitializeMapper();
            var cars = context.Cars
                                .Where(c => c.Make == "Toyota")
                                .OrderBy(c => c.Model)
                                .ThenByDescending(c => c.TravelledDistance)
                                .ToList();

            var mappedCarsFromToyota = mapper.Map<IEnumerable<CarsFromToyotaOutputDTO>>(cars);

            return JsonConvert.SerializeObject(mappedCarsFromToyota, JsonSettings());
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            var salesDTOs = JsonConvert.DeserializeObject<IEnumerable<SalesInputDTO>>(inputJson);
            var sales = mapper.Map<IEnumerable<Sale>>(salesDTOs);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customersJson = JsonConvert.DeserializeObject<IEnumerable<CustomersInputDTO>>(inputJson);
            InitializeMapper();

            var mappedCustomers = mapper.Map<IEnumerable<Customer>>(customersJson);

            context.Customers.AddRange(mappedCustomers);
            context.SaveChanges();

            return $"Successfully imported {mappedCustomers.Count()}.";

        }
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carDTOs = JsonConvert.DeserializeObject<IEnumerable<CarsInputDTO>>(inputJson);

            List<Car> carsToMap = new List<Car>();

            foreach (var c in carDTOs)
            {
                Car carsToMapAdd = new Car()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                };

                foreach (var partId in c.PartsId.Distinct())
                {
                    carsToMapAdd.PartCars.Add(new PartCar
                    {
                        PartId = partId
                    });

                }
                carsToMap.Add(carsToMapAdd);
            }

            context.AddRange(carsToMap);
            context.SaveChanges();

            return $"Successfully imported {carsToMap.Count()}.";

        }
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            var parts = JsonConvert.DeserializeObject<IEnumerable<PartsInputDTO>>(inputJson)
                        .Where(p => context.Suppliers
                                           .Select(s => s.Id)
                        .Contains(p.SupplierId));
            var mappedParts = mapper.Map<IEnumerable<Part>>(parts);

            context.AddRange(mappedParts);
            context.SaveChanges();

            return $"Successfully imported {mappedParts.Count()}.";
        }
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            var suppliers = JsonConvert.DeserializeObject<IEnumerable<SupplierInputDTO>>(inputJson)
                                 .Where(s => s.Name != null);
            var mappedSuppliers = mapper.Map<IEnumerable<Supplier>>(suppliers);

            context.Suppliers.AddRange(mappedSuppliers);
            context.SaveChanges();

            return $"Successfully imported {mappedSuppliers.Count()}.";
        }

        public static void InitializeMapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = new Mapper(mapperConfiguration);
        }

        public static JsonSerializerSettings JsonSettings()
        {
            return new JsonSerializerSettings
            {
                //ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            };
        }

    }
}