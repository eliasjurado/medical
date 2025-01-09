using Medical.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Medical.Domain.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class TypeDocument
    {
        public TypeDocument()
        {
        }
        public TypeDocumentId TypeDocumentId { get; set; }

        public string? Name { get; set; }
    }
}
