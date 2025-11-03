using System;

namespace OrgManager.WebApp.Services;

public interface ITimeService
{
    string ToPersianDate(DateTime dateTime);
    string ToPersianTime(DateTime dateTime);
}
