using AutoMapper;
using Domain.Entity;
using Domain.Model;
using Infra.Data.Model;

namespace Infra.Data.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
             CreateMap<Adm, AdmModel>().ReverseMap();
             CreateMap<Buy, BuyModel>().ReverseMap();
             CreateMap<Buy, BuyDetailsModel>().ReverseMap();
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Client, ClientModel>().ReverseMap();
            CreateMap<Order, OrderModel>().ReverseMap();
            CreateMap<OrderDetails,OrderDetailsModel>().ReverseMap();
            CreateMap<Payment,PaymentModel>().ReverseMap();
            CreateMap<Product,ProductModel>().ReverseMap();
             CreateMap<Provider,ProviderModel>().ReverseMap();
        }
    }
}