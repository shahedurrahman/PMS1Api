using AutoMapper;
using PMS1Api.Models.ApiModels;
using PMS1Api.Models.EFModels;

namespace PMS1Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Drug
            CreateMap<DrugCreateRequest, Drug>();
            CreateMap<DrugUpdateRequest, Drug>();
            CreateMap<Drug, DrugGetResponse>();

            // Order
            CreateMap<OrderCreateRequest, Order>();
            CreateMap<OrderUpdateRequest, Order>();
            CreateMap<Order, OrderGetResponse>();
        }
    }
}
