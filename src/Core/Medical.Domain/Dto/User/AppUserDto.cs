using Medical.Domain.Dto.Appointment;
using Medical.Domain.Entities;
using Medical.Domain.Enums;

namespace Medical.Domain.Dto.User;

public class AppUserDto
{
    public int Id { get; set; }
    public string? UserId { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public TypeDocumentId? TypeDocumentId { get; set; }
    public string? NumDocument { get; set; }
    public bool IsTaxExempted { get; set; }
    public List<Serie> Series { get; set; } = new List<Serie>();
    public bool IsActive { get; set; } = true;
    public bool Editing { get; set; } = false;
    public bool IsNew { get; set; } = false;
}
