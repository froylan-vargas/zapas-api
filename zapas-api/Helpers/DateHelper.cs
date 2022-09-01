using System;
namespace Zapas.Helpers
{
	public static class DateHelper
	{
		public static string RaceTimeToString(int seconds)
		{
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            return time.ToString(@"hh\:mm\:ss");
        }

		public static int RaceTimeToSeconds(string duration)
		{
			TimeSpan ts;
            char sep = ':';

            int freq = duration.Where(x => (x == sep)).Count();
            if (freq<2)
				duration = "00:" + duration;
			TimeSpan.TryParse(duration, out ts);
			if (ts != TimeSpan.Zero)
			{
				return (int)ts.TotalSeconds;
			}
			else { return 0; }
		}
	}
}

