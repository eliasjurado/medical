using Medical.Domain.Common;
using Medical.Domain.Enums;

namespace Medical.Domain.Entities;

public class AppUser : BaseAuditableEntity<int>
{
    public string? UserId { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public TypeDocumentId? TypeDocumentId { get; set; }
    public string? NumDocument { get; set; }
    public bool? IsTaxExempted { get; set; }
    public List<Serie> Series { get; set; } = new List<Serie>();
}
