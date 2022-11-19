using AutoMapper;
using Library.Domain.Entities;
using Library.Application.Vm;

namespace Library.WebAPI.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookEntity, BookVm>().ReverseMap();
            CreateMap<AuthorEntity, AuthorVm>().ReverseMap();
            CreateMap<BookInsatnceEntity, BookInsatnceVm>().ReverseMap();
        }
    }
}
