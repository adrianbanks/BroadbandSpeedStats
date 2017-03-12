using System;

namespace BroadbandStats.NetgearRouter.Traffic
{
    public sealed class TrafficStats
    {
        public Bandwidth Today { get; }
        public Bandwidth Yesterday { get; }
        public Bandwidth ThisWeek { get; }
        public Bandwidth ThisMonth { get; }
        public Bandwidth LastMonth { get; }

        public TrafficStats(Bandwidth today, Bandwidth yesterday, Bandwidth thisWeek, Bandwidth thisMonth, Bandwidth lastMonth)
        {
            if (today == null)
            {
                throw new ArgumentNullException(nameof(today));
            }

            if (yesterday == null)
            {
                throw new ArgumentNullException(nameof(yesterday));
            }

            if (thisWeek == null)
            {
                throw new ArgumentNullException(nameof(thisWeek));
            }

            if (thisMonth == null)
            {
                throw new ArgumentNullException(nameof(thisMonth));
            }

            if (lastMonth == null)
            {
                throw new ArgumentNullException(nameof(lastMonth));
            }

            Today = today;
            Yesterday = yesterday;
            ThisWeek = thisWeek;
            ThisMonth = thisMonth;
            LastMonth = lastMonth;
        }
    }
}
