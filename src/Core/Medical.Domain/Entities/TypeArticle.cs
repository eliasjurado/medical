using Medical.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Medical.Domain.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class TypeArticle
    {
        public TypeArticle()
        {
        }
        public TypeArticleId Id { get; set; }

        public string? Name { get; set; }
    }
}
