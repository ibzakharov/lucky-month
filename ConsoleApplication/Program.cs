using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;
using ConsoleApplication;

public class Program
{
    // 1. Назовем месяц "удачным" если в нем 5 воскресений.
    // Вывести на печать все "удачные месяцы" по одному на строку в формате MM.yyyy (например, 01.2022), 
    // начиная с января 2010 года и по декабрь 2020 включительно,
    // 2. Назовем "коэффициентом удачности" календарного года число "удачных" месяцев в этом году.
    // отсортировать список полученный c помощью GetLuckyMonths
    // сначала по "коэффициенту удачности" соответствующего года по убыванию,
    // затем по числу дней в этом месяце по убыванию,
    // затем по номеру месяца в году по возрастанию,
    // затем по году по возрастанию
    // для сортировки использовать Linq
    // Числа дней в месяце DateTime.DaysInMonth
    // День недели - перечисление DayOfWeek
    public static void Main()
    {
        var luckyMonth = new LuckyMonthService();
        var luckyMonths = luckyMonth.GetLuckyMonths(2010, 2020);
        Console.WriteLine(luckyMonths.Count);

        var sortedLuckyMonths = luckyMonths
            .GroupBy(m => m.Year)
            // 1. коэффициент удачности по убыванию
            .OrderByDescending(g => g.Count())
            // 4. по году по возрастанию
            .ThenBy(g => g.Key)
            .SelectMany(g =>
                // 2. число дней в месяце по убыванию
                g.OrderByDescending(m => DateTime.DaysInMonth(m.Year, m.Month))
                // 3. номер месяца по возрастанию    
                    .ThenBy(m => m.Month)
            );

        // Выводим результат
        Console.WriteLine("Main DayInMonth Month Year");
        foreach (var dt in sortedLuckyMonths)
        {
            Console.WriteLine($"{dt:MM.yyyy} {DateTime.DaysInMonth(dt.Year, dt.Month)} {dt.Month} {dt.Year}");
        }
    }
}