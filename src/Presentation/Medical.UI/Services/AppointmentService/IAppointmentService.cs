using Medical.Domain.Dto.Appointment;

namespace Medical.UI.Services.AppointmentService
{
    public interface IAppointmentService
    {
        event Action OnChange;
        List<AppointmentDto> Appointments { get; set; }
        List<AppointmentDto> AdminAppointments { get; set; }
        Task GetAppointments();
        Task GetAdminAppointments();
        Task AddAppointment(AppointmentDto appointment);
        Task UpdateAppointment(AppointmentDto appointment);
        Task DeleteAppointment(int appointmentId);
        AppointmentDto CreateNewAppointment();
    }
}
