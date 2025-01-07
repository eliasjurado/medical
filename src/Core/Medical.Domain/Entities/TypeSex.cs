using Medical.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Medical.Domain.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class TypeSex
    {
        public TypeSex()
        {
        }
        public TypeSexId TypeSexId { get; set; }

        public string Name { get; set; }
    }
}
