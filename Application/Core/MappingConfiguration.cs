using Application.DTOs;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<Book, BookDTO<int>>()
                .ForMember(bd => bd.Rating,
                    o => o.MapFrom(b => b.Ratings.Select(r => r.Score).DefaultIfEmpty().Average()))
                .ForMember(bd => bd.ReviewsNumber,
                    o => o.MapFrom(b => b.Reviews.Count));

            CreateMap<Book, BookDetailsDTO<int>>()
                .ForMember(bd => bd.Rating,
                    o => o.MapFrom(b => b.Ratings.Select(r => r.Score).DefaultIfEmpty().Average()));
            
            CreateMap<Review, ReviewDTO<int>>().ReverseMap();
            CreateMap<SaveBookDTO<int>, Book>(); 
            CreateMap<RatingDTO<int>, Rating>();
        }
    }
}