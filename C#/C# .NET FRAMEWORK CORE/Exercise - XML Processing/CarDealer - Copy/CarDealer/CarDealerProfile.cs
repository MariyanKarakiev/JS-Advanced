using AutoMapper;
using CarDealer.DTO.Input;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<CustomersInputDTO, Customer>();
            CreateMap<SalesInputDTO, Sale>();
        }
    }
}
