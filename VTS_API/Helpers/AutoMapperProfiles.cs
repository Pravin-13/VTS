using AutoMapper;
using VTS_API.Dtos;
using VTS_API.Models;

namespace VTS_API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserReqDto>().ReverseMap();
        }
    }
}
