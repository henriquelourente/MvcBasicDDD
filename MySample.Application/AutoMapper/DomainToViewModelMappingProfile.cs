using AutoMapper;
using MySample.Application.ViewModels;
using MySample.Domain.Entities;

namespace MySample.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Cliente, ClienteViewModel>();
        }
    }
}