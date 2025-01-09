using Medical.Domain.Enums;

namespace Medical.Domain.Dto.Appointment;

public class AppointmentDto
{
    public int Id { get; set; }
    public int IdPacient { get; set; }
    public virtual Entities.Pacient Pacient { get; set; } = new Entities.Pacient();
    public int IdTreatment { get; set; }
    public virtual Entities.Treatment Treatment { get; set; } = new Entities.Treatment();
    public int IdSpecialist { get; set; }
    public virtual Entities.Specialist Specialist { get; set; } = new Entities.Specialist();
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public string? Note { get; set; }
    public TypeShiftId TypeShiftId { get; set; }
    public TypeAppointmentId TypeAppointmentId { get; set; }
    public bool IsActive { get; set; } = true;
    public bool Editing { get; set; } = false;
    public bool IsNew { get; set; } = false;
}
