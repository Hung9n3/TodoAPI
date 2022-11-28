using AutoMapper;
using TodoApi.Core.Entities;

namespace TodoApi.DataObjects.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDTO, User>().
                ForMember(des => des.Id, opt => opt.Ignore());
            CreateMap<User, UserDTO>();

            CreateMap<Work, WorkDTO>();
            CreateMap<WorkDTO, Work>().ForMember(des => des.Id, opt => opt.Ignore());

            CreateMap<Calendar, CalendarDTO>();
            CreateMap<CalendarDTO, Calendar>()
                .ForMember(des => des.Id, opt => opt.Ignore());
        }
    }
}
