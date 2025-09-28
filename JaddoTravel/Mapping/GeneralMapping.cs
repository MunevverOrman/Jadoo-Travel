using AutoMapper;
using JadooTravel.Dtos.CategoryDtos;
using JadooTravel.Dtos.DestinationDtos;
using JadooTravel.Entities;

namespace JadooTravel.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category,ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryByIdDto>().ReverseMap();

            CreateMap<Destination, ResultDestinationDto>().ReverseMap();
            CreateMap<Destination, CreateDestinationDto>().ReverseMap();
            CreateMap<Destination, UpdateDestinationDto>().ReverseMap();
            CreateMap<Destination, GetDestinationByIdDto>().ReverseMap();

        }
    }
}
