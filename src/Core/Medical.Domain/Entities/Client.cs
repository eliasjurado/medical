using Medical.Domain.Common;
using Medical.Domain.Enums;

namespace Medical.Domain.Entities;

public class Client : BaseAuditableEntity<int>
{
    public TypeDocumentId TypeDocumentId { get; set; }
    public string? NumDocument { get; set; }
    public string? FullName { get; set; }
    public DateTime Birthdate { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public virtual List<Sale> Sales { get; set; } = new List<Sale>();
}
