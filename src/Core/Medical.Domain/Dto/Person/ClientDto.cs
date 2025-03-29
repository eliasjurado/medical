using Medical.Domain.Dto.Appointment;
using Medical.Domain.Enums;

namespace Medical.Domain.Dto.Person;

public class ClientDto
{
    public int Id { get; set; }
    public TypeDocumentId? TypeDocumentId { get; set; }
    public string NumDocument { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public DateTime Birthdate { get; set; } = DateTime.MinValue;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public virtual List<AppointmentDto> Invoices { get; set; } = new List<AppointmentDto>();
    public bool IsActive { get; set; } = true;
    public bool Editing { get; set; } = false;
    public bool IsNew { get; set; } = false;
}
