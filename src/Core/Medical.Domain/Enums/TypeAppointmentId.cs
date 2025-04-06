using System.ComponentModel.DataAnnotations;

namespace Medical.Domain.Enums;

public enum TypeAppointmentId
{
    [Display(Description = "CONSULTA")]
    Consult = 1,
    [Display(Description = "CONTROL")]
    Control = 2
}
