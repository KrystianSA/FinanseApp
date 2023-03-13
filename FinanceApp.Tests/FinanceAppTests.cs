using System.Reflection.Metadata;
using FinanceApp;
namespace FinanceApp.Tests
{
    public class FinanceAppTests
    {
        [Test]
        public void WhenTwoNumberInBillsAreAdded_ReturnCorrectResult()
        {
            var user = new FinanceMemory("Krystian", "S¹siadek");
            user.AddBills(10);
            user.AddBills(20);
            var sumbill = user.DevideSalary();

            Assert.AreEqual(30,sumbill.sumBills);
        }
        [Test]
        public void WhenTwoNumberInCasualDayAreAdded_ReturnCorrectResult()
        {
            var user = new FinanceMemory("Krystian", "S¹siadek");
            user.AddCasualDay(15);
            user.AddCasualDay(20);
            var sumCasualDay = user.DevideSalary();

            Assert.AreEqual(35, sumCasualDay.sumCasualDay);
        }
        [Test]
        public void WhenTwoNumberInSavingsAreAdded_ReturnCorrectResult()
        {
            var user = new FinanceMemory("Krystian", "S¹siadek");
            user.AddSavings(5);
            user.AddSavings(20);
            var sumSavings = user.DevideSalary();

            Assert.AreEqual(25, sumSavings.sumSavings);
        }
        [Test]
        public void WhenSalaryIsDevide_ReturnCorrectResult()
        {
            var user = new FinanceMemory("Krystian", "S¹siadek");
            user.AddSalary(3000);
            var result = user.DevideSalary();
            Assert.That(1500,Is.EqualTo(result.bills).Within(1));
            Assert.AreEqual(1500,result.bills,1);
            Assert.That(900, Is.EqualTo(result.casualDay).Within(1));
            Assert.AreEqual(900, result.casualDay, 1);
            Assert.That(600, Is.EqualTo(result.savings).Within(1));
            Assert.AreEqual(600, result.savings, 1);
        }
    }
}