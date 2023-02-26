
namespace FinanceApp
{
    public interface IFinance
    {
        string Name { get; }
        string Surname { get; }
        void AddSalary(float salary);
        void AddSalary(string salary);
        MoneyForOneMonth DevideSalary();
        void AddBills(float bills);
        void AddBills(string bills);
    }
}
