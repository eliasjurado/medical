using Medical.Domain.Dto.Appointment;

namespace Medical.Domain.Dto.Treatment;

public class TreatmentDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int DurationMinutes { get; set; }
    public virtual List<AppointmentDto> Appointments { get; set; } = new List<AppointmentDto>();
    public bool IsActive { get; set; } = true;
    public bool Editing { get; set; } = false;
    public bool IsNew { get; set; } = false;
}

