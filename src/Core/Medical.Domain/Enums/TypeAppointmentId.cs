using System.ComponentModel.DataAnnotations;

namespace Medical.Domain.Enums;

public enum TypeAppointmentId
{
    [Display(Description = "Consulta")]
    Consult,
    [Display(Description = "Control")]
    Control
}
