using Medical.Domain.Enums;

namespace Medical.Domain.Dto.Specialist;
public class SpecialistDto
{
    public int Id { get; set; }
    public TypeDocument TypeDocument { get; set; } = TypeDocument.None;
    public string NumDocument { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string SpecialtyName { get; set; } = string.Empty;
    public string CollegeName { get; set; } = string.Empty;
    public string CollegeId { get; set; } = string.Empty;
    public TypeSex TypeSex { get; set; } = TypeSex.None;
    public DateTime Birthdate { get; set; } = DateTime.MinValue;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public bool Editing { get; set; } = false;
    public bool IsNew { get; set; } = false;
}

