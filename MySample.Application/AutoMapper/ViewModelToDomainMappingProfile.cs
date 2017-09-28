using AutoMapper;
using MySample.Application.ViewModels;
using MySample.Domain.Entities;

namespace MySample.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ClienteViewModel, Cliente>();
        }
    }
}