namespace Medical.App.Models
{
    public class Appointment
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string PacientFullName { get; set; }
        public string TreatmentName { get; set; }
        public string SpecialistFullName { get; set; }       
    }
}
