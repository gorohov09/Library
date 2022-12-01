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
            CreateMap<ReaderEntity, SearchReaderInfoVm>().ReverseMap();

            CreateMap<OrderEntity, OrderDetailsForReaderVm>()
                .ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.BookInsatnce.BookInfo.Title))
                .ForMember(dest => dest.BookPublisher, opt => opt.MapFrom(src => src.BookInsatnce.BookInfo.Publisher))
                .ForMember(dest => dest.BookYear, opt => opt.MapFrom(src => src.BookInsatnce.BookInfo.Year))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.GetStatusOrder()))
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.BookInsatnce.BookInfo.Authors))
                .ReverseMap();

            CreateMap<OrderEntity, OrderDetailsForLibrarianVm>()
                .ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.BookInsatnce.BookInfo.Title))
                .ForMember(dest => dest.BookPublisher, opt => opt.MapFrom(src => src.BookInsatnce.BookInfo.Publisher))
                .ForMember(dest => dest.BookYear, opt => opt.MapFrom(src => src.BookInsatnce.BookInfo.Year))
                .ForMember(dest => dest.RowNumber, opt => opt.MapFrom(src => src.BookInsatnce.RowNumber))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.GetStatusOrder()))
                .ForMember(dest => dest.Reader, opt => opt.MapFrom(src => src.Reader))
                .ForMember(dest => dest.BookAuthors, opt => opt.MapFrom(src => src.BookInsatnce.BookInfo.Authors))
                .ReverseMap();
            
            CreateMap<OrderEntity, BriefOrderInfoForLibrarians>()
                .ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.BookInsatnce.BookInfo.Title))
                .ForMember(dest => dest.BookPublisher, opt => opt.MapFrom(src => src.BookInsatnce.BookInfo.Publisher))
                .ForMember(dest => dest.BookYear, opt => opt.MapFrom(src => src.BookInsatnce.BookInfo.Year))
                .ForMember(dest => dest.RowNumber, opt => opt.MapFrom(src => src.BookInsatnce.RowNumber))
                .ForMember(dest => dest.ReaderFullName, opt => opt.MapFrom(src => src.Reader.FullName))
                .ReverseMap();

            CreateMap<RecordEntity, RecordDetailsForReaderVm>()
                .ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.BookInsatnce.BookInfo.Title))
                .ForMember(dest => dest.BookPublisher, opt => opt.MapFrom(src => src.BookInsatnce.BookInfo.Publisher))
                .ForMember(dest => dest.BookYear, opt => opt.MapFrom(src => src.BookInsatnce.BookInfo.Year))
                .ForMember(dest => dest.BookAuthors, opt => opt.MapFrom(src => src.BookInsatnce.BookInfo.Authors))
                .ReverseMap();
        }
    }
}
