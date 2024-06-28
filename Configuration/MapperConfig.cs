using AutoMapper;
using SummerWebinarApp.Data;
using SummerWebinarApp.DTO;

namespace SummerWebinarApp.Configuration
{
    // AutoMapper configuration for mapping between User entities and DTOs
    public class MapperConfig : Profile
    {
        // Constructor where mapping configurations are defined
        public MapperConfig()
        {
       
            CreateMap<User, UserPatchDTO>().ReverseMap();
            CreateMap<User, UserSignupDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
         
      

        }
    }
}
