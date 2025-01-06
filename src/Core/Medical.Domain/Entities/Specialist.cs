using Medical.Domain.Common;
using Medical.Domain.Enums;

namespace Medical.Domain.Entities;

public class Specialist : BaseAuditableEntity<int>
{
    public TypeDocument TypeDocument { get; set; }
    public string NumDocument { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string SpecialtyName { get; set; }
    public string CollegeName { get; set; }
    public string CollegeId { get; set; }
    public TypeSex TypeSex { get; set; }
    public DateTime Birthdate { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
}
