﻿namespace ScottPlot.TickGenerators.TimeUnits;

public class Decisecond : ITimeUnit
{
    public IReadOnlyList<int> Divisors => StandardDivisors.Decimal;

    public TimeSpan MinSize => TimeSpan.FromMilliseconds(100);

    public DateTime Snap(DateTime dt)
    {
        int snapMilliseconds = 1000;
        int remainder = dt.Millisecond % snapMilliseconds;
        return dt + TimeSpan.FromMilliseconds(-remainder);
    }

    public string GetDateTimeFormatString()
    {
        string hourSpecifier = CultureInfo.CurrentCulture.Uses24HourClock() ? "HH" : "hh";
        return $"{CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern}\n{hourSpecifier}:mm:ss.f"; // TODO: This assumes colons as the separators, but consider (some) French-language locales use 12h30 rather than 12:30
    }

    public DateTime Next(DateTime dateTime, int increment = 1)
    {
        return dateTime.AddMilliseconds(increment * 100);
    }
}
