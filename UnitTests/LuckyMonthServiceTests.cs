using ConsoleApplication;

namespace UnitTests;

[TestClass]
public class LuckyMonthServiceTests
{
    [TestMethod]
    public void GetLuckyMonths_ReturnsCorrectMonths_For2024To2024()
    {
        var yearStart = 2024;
        var yearEnd = 2024;
        
        var service = new LuckyMonthService();
        var result = service.GetLuckyMonths(yearStart, yearEnd);
        
        var expectedList = new List<DateTime>()
        {
            new(2024, 03, 01),
            new(2024, 06, 01),
            new(2024, 09, 01),
            new(2024, 12, 01),
        };
        
        CollectionAssert.AreEqual(expectedList, result);
    }
}