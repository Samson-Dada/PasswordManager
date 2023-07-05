using API.Entities;
using API.Models.UserDto;
using AutoMapper;

namespace API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Get Mapping
            CreateMap<User, UserForGetDto>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

            CreateMap<UserForGetDto, User>()
             .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

            //
            CreateMap<UserForSignupDto, User>();

            // Create Mapping
            CreateMap<UserPasswordCreationDto, User>();

            // Get Mapping
            CreateMap<User, UserPasswordCreationDto>();


            //Update Map

            CreateMap<UserForUpdateDto,User>();
        }
    }
}
