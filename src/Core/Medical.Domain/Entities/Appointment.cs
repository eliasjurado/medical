using Medical.Domain.Common;
using Medical.Domain.Enums;

namespace Medical.Domain.Entities;

public class Appointment : BaseAuditableEntity<int>
{
    public int IdPacient { get; set; }
    public virtual Pacient? Pacient { get; set; }
    public int IdTreatment { get; set; }
    public virtual Treatment? Treatment { get; set; }
    public int IdSpecialist { get; set; }
    public virtual Specialist? Specialist { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public TypeShiftId TypeShiftId { get; set; }
    public TypeAppointment? TypeAppointment { get; set; }
}
