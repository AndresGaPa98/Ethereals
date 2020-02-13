using AutoMapper;
using Scm.Controllers.Dtos;
using Scm.Domain;

namespace Scm.Infrastructure.Mapping
{
    public class MappingProfile : Profile {
    public MappingProfile() {
            CreateMap<AppUser, RegisterUserResponseDto>();
            CreateMap<BoardDto,Board>().ReverseMap();
            CreateMap<BoardRegisterDto,Board>().ReverseMap();
            CreateMap<BoardRegisterDto,BoardDto>().ReverseMap();
        }
    }
}