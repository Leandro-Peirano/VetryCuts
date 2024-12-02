namespace VetriCuts.Models
{
    public class MonthInfo
    {
        public string MonthName { get; set; }
        public int DaysInMonth { get; set; }
    }

    public static class Applibrary
    {

        public static List<MonthInfo> GetMonthsWithDays()
        {
            var months = new List<MonthInfo>();

            for (int month = 1; month <= 12; month++)
            {
                var daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, month);
                var monthName = new DateTime(DateTime.Now.Year, month, 1).ToString("MMMM");

                months.Add(new MonthInfo { MonthName = monthName, DaysInMonth = daysInMonth });
            }

            return months;
        }
    }
}
