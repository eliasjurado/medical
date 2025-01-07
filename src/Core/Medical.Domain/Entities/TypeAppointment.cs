using Medical.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Medical.Domain.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class TypeAppointment
    {
        public TypeAppointment()
        {
        }
        public TypeAppointmentId TypeAppointmentId { get; set; }

        public string Name { get; set; }
    }
}
