using System;
using System.Collections.Generic;

namespace ConsoleApplication;

public class LuckyMonthService
{
    public List<DateTime> GetLuckyMonths(int yearStart, int yearEnd)
    {
        var luckyMonths = new List<DateTime>();

        for (var year = yearStart; year <= yearEnd; year++)
        {
            for (var month = 1; month <= 12; month++)
            {
                if (IsLuckyMonth(year, month))
                {
                    luckyMonths.Add(new DateTime(year, month, 1));
                }
            }
        }

        return luckyMonths;
    }

    private bool IsLuckyMonth(int year, int month)
    {
        var count = 0;
        var days = DateTime.DaysInMonth(year, month);
        for (var day = 1; day <= days; day++)
        {
            var dt = new DateTime(year, month, day);
            if (dt.DayOfWeek == DayOfWeek.Sunday)
            {
                count++;
            }
        }

        return count >= 5;
    }
}