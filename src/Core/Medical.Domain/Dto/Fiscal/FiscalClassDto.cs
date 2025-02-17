namespace Medical.Domain.Dto.Fiscal;

public class FiscalClassDto
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string FamilyCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public bool Editing { get; set; } = false;
    public bool IsNew { get; set; } = false;
}
