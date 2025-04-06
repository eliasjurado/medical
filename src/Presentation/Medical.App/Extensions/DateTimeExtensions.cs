namespace Medical.App.Utils
{
    public static class DateTimeExtensions
    {
        public static int GetAge(this DateTime birthDate)
        {
            return Convert.ToInt32((DateTime.Today - birthDate).TotalDays / 365.2425);
        }
    }
}
