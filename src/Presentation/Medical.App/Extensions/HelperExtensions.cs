using Medical.Domain.Enums;

namespace Medical.App.Utils
{
    public static class HelperExtensions
    {
        public static int GetAge(this DateTime birthDate)
        {
            return Convert.ToInt32((DateTime.Today - birthDate).TotalDays / 365.2425);
        }

        public static string GetReceiptTypeCode(this TypeSaleId typeSaleId)
        {
            var abbrev = string.Empty;
            switch (typeSaleId)
            {
                case TypeSaleId.Note:
                    abbrev = "NV";
                    break;
                case TypeSaleId.Receipt:
                    abbrev = "BL";
                    break;
                case TypeSaleId.Invoice:
                    abbrev = "FA";
                    break;
                default:
                    abbrev = "NV";
                    break;
            }
            return abbrev;
        }
    }
}
