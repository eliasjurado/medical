using Medical.Domain.Common;
using Medical.Domain.Enums;

namespace Medical.Domain.Entities;

public class Serie : BaseAuditableEntity<int>
{
    public TypeSaleId TypeSaleId { get; set; }
    public int NumSerie { get; set; }
    public int NumCorrelative { get; set; }
    public int AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
}
