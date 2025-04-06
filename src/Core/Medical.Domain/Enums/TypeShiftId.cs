using System.ComponentModel.DataAnnotations;

namespace Medical.Domain.Enums;

public enum TypeShiftId
{
    [Display(Description = "MAÑANA")]
    Morning = 1,
    [Display(Description = "TARDE")]
    Afternoon = 2,
    [Display(Description = "NOCHE")]
    Night = 3
}
