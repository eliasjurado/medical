namespace Medical.Domain.Dto.Fiscal;

public class FiscalTaxDto
{
    public int Id { get; set; }
    public int NumYear { get; set; }
    public decimal TaxAmount { get; set; }
    public bool IsActive { get; set; } = true;
    public bool Editing { get; set; } = false;
    public bool IsNew { get; set; } = false;
}
