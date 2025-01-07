using Medical.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Medical.Domain.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class TypeShift
    {
        public TypeShift()
        {
        }
        public TypeShiftId TypeShiftId { get; set; }

        public string Name { get; set; }
    }
}
