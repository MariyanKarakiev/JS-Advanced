using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO.Input;
using CarDealer.DTO.Output;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        private static IMapper mapper;
        public static void Main(string[] args)
        {
            var dbContext = new CarDealerContext();

            InitializeXmlImport(dbContext);

            Console.WriteLine(GetCarsFromMakeBmw(dbContext));

            dbContext.Database.EnsureDeleted();
        }
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var sb = new StringBuilder();

            var serializer = GenerateXmlSerializer("cars", typeof(CarsFromBMWOutput[]));
            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(String.Empty, String.Empty);
            using var stringWriter = new StringWriter(sb);

            var carsDtos = context.Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new CarsFromBMWOutput()
                {
                    Id = c.Id,
                    Model = c.Model,
                    TraveledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ToArray();

            serializer.Serialize(stringWriter, carsDtos, namespaces);

            return sb.ToString();
        }
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var sb = new StringBuilder();


            var serializer = GenerateXmlSerializer("cars", typeof(CarsWithDistanceOutputDTO[]));
            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(String.Empty, String.Empty);
            using var stringWriter = new StringWriter(sb);


            var carDtos = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Select(c => new CarsWithDistanceOutputDTO()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TravelledDistance.ToString()
                })
                .Take(10)
                .ToArray();


            serializer.Serialize(stringWriter, carDtos, namespaces);

            return sb.ToString();
        }
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = GenerateXmlSerializer("Sales", typeof(SalesInputDTO[]));

            using var stringReader = new StringReader(inputXml);

            var dtos = (SalesInputDTO[])xmlSerializer.Deserialize(stringReader);

            /* InitializeMapper();
              var sales = mapper.Map<Sale[]>(dtos);
*/
            ICollection<Sale> sales = new HashSet<Sale>();

            foreach (var dto in dtos)
            {
                var currentCar = context.Cars.Find(dto.CarId);
                var currentCustomer = context.Customers.Find(dto.CustomerId);

                if (currentCar == null)
                {
                    continue;
                }


                var currentSales = new Sale()
                {
                    Discount = dto.Discount,
                    Car = currentCar,
                    Customer = currentCustomer
                };
                sales.Add(currentSales);
            }

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}";
        }
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var root = new XmlRootAttribute("Customers");

            using var stringReader = new StringReader(inputXml);

            var serializer = new XmlSerializer(typeof(CustomersInputDTO[]), root);

            var dtos = (CustomersInputDTO[])serializer.Deserialize(stringReader);

            InitializeMapper();
            var customers = mapper.Map<Customer[]>(dtos)
                .Where(c => c.Name != null);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}";
        }
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var xmlRoot = new XmlRootAttribute("Cars");
            var xmlSerializer = new XmlSerializer(typeof(CarsImportDTO[]), xmlRoot);

            using var stringReader = new StringReader(inputXml);

            var carDtos = (CarsImportDTO[])xmlSerializer.Deserialize(stringReader);

            ICollection<Car> cars = new HashSet<Car>();


            foreach (var carDto in carDtos)
            {
                var car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TraveledDistance,
                };

                ICollection<PartCar> carParts = new HashSet<PartCar>();

                foreach (var partId in carDto.Parts.Select(p => p.Id).Distinct())
                {
                    Part part = context
                        .Parts
                        .Find(partId);

                    if (part == null)
                    {
                        continue;
                    }

                    var cp = new PartCar()
                    {
                        Car = car,
                        Part = part
                    };
                    carParts.Add(cp);
                }
                car.PartCars = carParts;
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var xmlRoot = new XmlRootAttribute("Parts");
            var xmlSerializer = new XmlSerializer(typeof(PartsImportDTO[]), xmlRoot);

            using var stringReader = new StringReader(inputXml);

            var dtos = (PartsImportDTO[])xmlSerializer.Deserialize(stringReader);

            ICollection<Part> parts = new HashSet<Part>();

            foreach (var dto in dtos)
            {
                var supplier = context
                    .Suppliers
                    .Find(dto.SupplierID);

                if (supplier == null)
                {
                    continue;
                }

                Part part = new Part()
                {
                    Name = dto.Name,
                    Price = decimal.Parse(dto.Price),
                    Quantity = dto.Quantity,
                    //SupplierId = dto.SupplierID,
                    Supplier = supplier
                };
                parts.Add(part);
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Suppliers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SuppliersInputDTO[]), xmlRoot);

            using StringReader stringReader = new StringReader(inputXml);

            var dtos = (SuppliersInputDTO[])xmlSerializer.Deserialize(stringReader);


            ICollection<Supplier> suppliers = new HashSet<Supplier>();

            foreach (var dto in dtos)
            {
                Supplier s = new Supplier()
                {
                    Name = dto.Name,
                    IsImporter = bool.Parse(dto.IsImporter)
                };
                suppliers.Add(s);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        public static XmlSerializer GenerateXmlSerializer(string rootName, Type dto)
        {
            var xmlRoot = new XmlRootAttribute(rootName);
            var xmlSerializer = new XmlSerializer(dto, xmlRoot);

            return xmlSerializer;
        }
        public static void InitializeMapper()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = new Mapper(mapperConfig);
        }
        public static void InitializeXmlImport(CarDealerContext dbContext)
        {
            dbContext.Database.EnsureCreated();


            var xmlSuppliersString = File.ReadAllText("../../../Datasets/suppliers.xml");
            var xmlPartsString = File.ReadAllText("../../../Datasets/parts.xml");
            var xmlCarsString = File.ReadAllText("../../../Datasets/cars.xml");
            var xmlCustomersString = File.ReadAllText("../../../Datasets/customers.xml");
            var xmlSalesString = File.ReadAllText("../../../Datasets/sales.xml");


            Console.WriteLine(ImportSuppliers(dbContext, xmlSuppliersString));
            Console.WriteLine(ImportParts(dbContext, xmlPartsString));
            Console.WriteLine(ImportCars(dbContext, xmlCarsString));
            Console.WriteLine(ImportCustomers(dbContext, xmlCustomersString));
            Console.WriteLine(ImportSales(dbContext, xmlSalesString));

            Console.WriteLine("Database ready!");
        }
    }
}
