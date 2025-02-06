using System.ComponentModel.DataAnnotations;

namespace Medical.Domain.Enums;

public enum TypeShiftId
{
    [Display(Description = "Mañana")]
    Morning,
    [Display(Description = "Tarde")]
    Afternoon,
    [Display(Description = "Noche")]
    Night
}
