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

        public static TypeSaleId GetReceiptTypeSaleId(this string receiptCode)
        {
            if (string.IsNullOrWhiteSpace(receiptCode))
            {
                return TypeSaleId.Note;
            }
            TypeSaleId typeSale;
            switch (receiptCode.Substring(0, 2))
            {
                case "NV":
                    typeSale = TypeSaleId.Note;
                    break;
                case "BL":
                    typeSale = TypeSaleId.Receipt;
                    break;
                case "FA":
                    typeSale = TypeSaleId.Invoice;
                    break;
                default:
                    typeSale = TypeSaleId.Note;
                    break;
            }
            return typeSale;
        }

        public static string GetReceiptTypeSaleCode(this string receiptCode)
        {
            if (string.IsNullOrWhiteSpace(receiptCode))
            {
                return string.Empty;
            }
            return receiptCode.Substring(0, 2);
        }

        public static string GetReceiptSerie(this string receiptCode)
        {
            if (string.IsNullOrWhiteSpace(receiptCode))
            {
                return string.Empty;
            }
            return receiptCode.Substring(2, 3);
        }

        public static string GetReceiptCorrelative(this string receiptCode)
        {
            if (string.IsNullOrWhiteSpace(receiptCode))
            {
                return string.Empty;
            }
            return receiptCode.Substring(6, 6);
        }
    }
}
