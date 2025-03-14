using Medical.Domain.Common;
using Medical.Domain.Enums;

namespace Medical.Domain.Entities;

public class Category : BaseAuditableEntity<int>
{
    public string? Name { get; set; }
    public string? Code { get; set; }
    public TypeArticleId TypeArticleId { get; set; }
}
