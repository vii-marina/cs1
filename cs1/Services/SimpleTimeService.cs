using System.Globalization;

namespace cs1.Services
{
    public class SimpleTimeService : ITimeService
    {
        public string GetTimeForTomorrow()
        {
            var dt = DateTime.Now.AddDays(1);
            return dt.ToString("f", CultureInfo.InvariantCulture);
        }
    }
}