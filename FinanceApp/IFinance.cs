
namespace FinanceApp
{
    public interface IFinance
    {
        string Name { get; }
        string Surname { get; }
        void AddSalary(float salary);
        void AddSalary(string salary);
        void AddSalary(int salary);
        void AddBills(float bills);
        void AddBills(string bills);
        void AddBills(int bills);
        void AddCasualDay(float casualDay);
        void AddCasualDay(string casualDay);
        void AddCasualDay(int casualDay);
        void AddSavings(float savings);
        void AddSavings(string savings);
        void AddSavings(int savings);
        MoneyForOneMonth DevideSalary();
    }
}
