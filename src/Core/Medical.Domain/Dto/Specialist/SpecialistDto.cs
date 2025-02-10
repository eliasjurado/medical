using Medical.Domain.Dto.Appointment;
using Medical.Domain.Enums;

namespace Medical.Domain.Dto.Specialist;
public class SpecialistDto
{
    public int Id { get; set; }
    public TypeDocumentId? TypeDocumentId { get; set; }
    public string NumDocument { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string ProfessionName { get; set; } = string.Empty;
    public string CollegeName { get; set; } = string.Empty;
    public string CollegeCode { get; set; } = string.Empty;
    public string SpecialtyName { get; set; } = string.Empty;
    public string RneCode { get; set; } = string.Empty;
    public TypeSexId? TypeSexId { get; set; }
    public DateTime Birthdate { get; set; } = DateTime.MinValue;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public virtual List<AppointmentDto> Appointments { get; set; } = new List<AppointmentDto>();
    public bool IsActive { get; set; } = true;
    public bool Editing { get; set; } = false;
    public bool IsNew { get; set; } = false;
}

