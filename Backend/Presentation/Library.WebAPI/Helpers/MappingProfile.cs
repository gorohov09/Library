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
            CreateMap<BookEntity, BookDetailsVm>().ReverseMap();
            CreateMap<ReaderEntity, ReaderVm>().ReverseMap();

            CreateMap<OrderEntity, OrderDetailsForReaderVm>()
                .ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.BookInsatnce.BookInfo.Title))
                .ForMember(dest => dest.BookPublisher, opt => opt.MapFrom(src => src.BookInsatnce.BookInfo.Publisher))
                .ForMember(dest => dest.BookYear, opt => opt.MapFrom(src => src.BookInsatnce.BookInfo.Year))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.GetStatus()))
                .ReverseMap();

            CreateMap<OrderEntity, OrderDetailsForLibrarianVm>()
                .ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.BookInsatnce.BookInfo.Title))
                .ForMember(dest => dest.BookPublisher, opt => opt.MapFrom(src => src.BookInsatnce.BookInfo.Publisher))
                .ForMember(dest => dest.BookYear, opt => opt.MapFrom(src => src.BookInsatnce.BookInfo.Year))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.GetStatus()))
                .ReverseMap();

            CreateMap<RecordEntity, RecordDetailsForReaderVm>()
                .ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.BookInsatnce.BookInfo.Title))
                .ForMember(dest => dest.BookPublisher, opt => opt.MapFrom(src => src.BookInsatnce.BookInfo.Publisher))
                .ForMember(dest => dest.BookYear, opt => opt.MapFrom(src => src.BookInsatnce.BookInfo.Year))
                .ReverseMap();
        }
    }
}
