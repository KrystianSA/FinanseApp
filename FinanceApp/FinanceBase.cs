namespace FinanceApp
{
    public abstract class FinanceBase : IFinance
    {
        public FinanceBase(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public abstract void AddBills(float bills);
        public abstract void AddBills(string bills);
        public abstract void AddSalary(float salary);
        public abstract void AddSalary(string salary);
        public abstract MoneyForOneMonth DevideSalary();
    }
}
