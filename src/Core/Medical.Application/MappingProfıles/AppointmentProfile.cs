using AutoMapper;
using Medical.Domain.Dto.AppointmentDto;
using Medical.Domain.Entities;

namespace Medical.Application.MappingProfıles;

public class AppointmentProfile : Profile
{
    public AppointmentProfile()
    {
        CreateMap<Appointment, AppointmentDto>().ReverseMap();
    }
}
