using API.Entities;
using API.Models.PasswordDto;
using AutoMapper;

namespace API.Profiles
{
    public class PasswordProfile:Profile
    {
        public PasswordProfile()
        {
            CreateMap<PasswordCreationDto, Password>();
            CreateMap<Password, PasswordCreationDto>();
            CreateMap<PasswordForGetDto, Password>();
            CreateMap<Password, PasswordForGetDto>();

            //


        }
    }
}
