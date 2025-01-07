namespace Medical.Application.MappingProfıles;

public class AppointmentProfile : Profile
{
    public AppointmentProfile()
    {
        CreateMap<Appointment, AppointmentDto>().ReverseMap();
    }
}
