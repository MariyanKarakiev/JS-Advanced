using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using CarDealer.DTO;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SupplierInputDTO, Supplier>();
            CreateMap<PartsInputDTO, Part>();
            CreateMap<CarsInputDTO, Car>();
            CreateMap<CustomersInputDTO, Customer>();
            CreateMap<SalesInputDTO, Sale>();

            CreateMap<Customer, CustomersOutputDTO>()
                .ForMember(d => d.BirthDate, y => y.MapFrom(s => s.BirthDate
                                 .ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)));

            CreateMap<Car, CarsFromToyotaOutputDTO>();

            CreateMap<Supplier, SuppliersLocalOutputDTO>()
                .ForMember(d => d.PartsCount, y => y.MapFrom(s => s.Parts.Count));

        }
    }
}
