using System;
using System.Globalization;

namespace OrgManager.WebApp.Services;

public class TimeService : ITimeService
{
    private readonly TimeZoneInfo _tehranZone;
    private readonly PersianCalendar _persianCalendar;

    public TimeService()
    {
        _tehranZone = TimeZoneInfo.FindSystemTimeZoneById("Iran Standard Time");
        _persianCalendar = new PersianCalendar();
    }

    public string ToPersianDate(DateTime dateTime)
    {
        var tehranTime = TimeZoneInfo.ConvertTimeFromUtc(dateTime, _tehranZone);
        return $"{_persianCalendar.GetYear(tehranTime)}/{_persianCalendar.GetMonth(tehranTime)}/{_persianCalendar.GetDayOfMonth(tehranTime)}";
    }

    public string ToPersianTime(DateTime dateTime)
    {
        var tehranTime = TimeZoneInfo.ConvertTimeFromUtc(dateTime, _tehranZone);
        return tehranTime.ToString("HH:mm");
    }
}
