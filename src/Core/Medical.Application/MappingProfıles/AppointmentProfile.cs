namespace Medical.Application.MappingProfıles;

public class AppointmentProfile : Profile
{
    public AppointmentProfile()
    {
        CreateMap<AppointmentDto, Appointment>().ReverseMap()
            .ForMember(d => d.PacientFullName, o => o.MapFrom(src => src.Pacient != null ? src.Pacient.FullName : string.Empty))
            .ForMember(d => d.TreatmentName, o => o.MapFrom(src => src.Treatment != null ? src.Treatment.Name : string.Empty))
            .ForMember(d => d.SpecialistFullName, o => o.MapFrom(src => src.Specialist != null ? src.Specialist.FullName : string.Empty));
    }
}
