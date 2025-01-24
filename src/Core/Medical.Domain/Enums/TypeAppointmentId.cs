using System.ComponentModel.DataAnnotations;

namespace Medical.Domain.Enums;

public enum TypeAppointmentId
{
    [Display(Description = "Consulta")]
    Consulta,
    [Display(Description = "Control")]
    Control
}
