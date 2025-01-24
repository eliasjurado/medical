using Medical.Domain.Enums;

namespace Medical.App.Models
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int PacientId { get; set; }
        public string PacientFullName { get; set; }
        public int TreatmentId { get; set; }
        public string TreatmentName { get; set; }
        public int SpecialistId { get; set; }
        public string SpecialistFullName { get; set; }
        public TypeShiftId? TypeShiftId { get; set; }
        public TypeAppointmentId? TypeAppointmentId { get; set; }
    }
}
