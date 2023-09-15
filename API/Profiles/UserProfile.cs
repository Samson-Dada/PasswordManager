using API.Shared.Entities;
using API.Shared.Models.UserDto;
using AutoMapper;

namespace API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Get Mapping
            CreateMap<User, UserForGetDto>();
              //.ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

            //CreateMap<UserForGetDto, User>()
            // .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));


            // Update Username

            CreateMap<User,UserForUpdateUserNameDto>();

            //
            CreateMap<UserForSignupDto, User>();

            // Create Mapping
            CreateMap<UserPasswordCreationDto, User>();

            // Get Mapping
            CreateMap<User, UserPasswordCreationDto>();


            //Update Map

            CreateMap<UserForUpdateDto1,User>();
        }
    }
}
