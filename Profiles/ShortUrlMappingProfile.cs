using AutoMapper;
using url_shortener.DTOs;
using url_shortener.Models;
namespace url_shortener.Profiles
{
    public class ShortUrlMappingProfile : Profile
    {

        public ShortUrlMappingProfile()
        {
            CreateMap<ShortUrl, ShortUrlResponse>()
            .ForMember(dest => dest.ShortUrl,
                       opt => opt.MapFrom((src, _, __, context) =>
                           $"{context.Items["domain"]}/{src.ShortCode}"));
        }
    }
}
