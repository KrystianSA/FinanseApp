using System.Diagnostics.Metrics;
using FinanceApp;
namespace FinanceApp
{
    public class FinanceMemory : FinanceBase
    {
        private List<float> salary = new List<float>();
        private List<float> listBills = new List<float>();
        private List<float> listCasualDay = new List<float>();
        private List<float> listSavings = new List<float>();

        public delegate void MoneyAddedDelegate(object sender, EventArgs args);
        public event MoneyAddedDelegate MoneyAdded;

        public FinanceMemory(string name, string surname) : base(name, surname)
        {

        }
        public override void AddSalary(float salary)
        {
            if (salary > 0)
            {
                this.salary.Add(salary);
                if (MoneyAdded != null)
                {
                    MoneyAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("Wpisana kwota musi być dodatnia");
            }
        }
        public override void AddSalary(string salary)
        {
            if (float.TryParse(salary, out float salaryInfloat1))
            {
                this.AddSalary(salaryInfloat1);
            }
            else
            {
                throw new Exception("Podana wartość musi być liczba");
            }
        }
        public override void AddSalary(int salary)
        {
            float salaryIntInFloat = (float)salary;
            this.AddSalary(salaryIntInFloat);
        }
        public override void AddBills(float bills)
        {
            if (bills > 0)
            {
                this.listBills.Add(bills);
            }
            else
            {
                throw new Exception("Wpisana kwota musi być dodatnia");
            }
        }
        public override void AddBills(string bills)
        {
            if (float.TryParse(bills, out float billsInfloat))
            {
                this.AddBills(billsInfloat);
            }
            else
            {
                throw new Exception("Podana wartość musi być liczba");
            }
        }
        public override void AddBills(int bills)
        {
            float billsIntInFloat = (float)bills;
            this.AddBills(billsIntInFloat);
        }

        public override void AddCasualDay(float casualDay)
        {
            if (casualDay > 0)
            {
                this.listCasualDay.Add(casualDay);
            }
            else
            {
                throw new Exception("Wpisana kwota musi być dodatnia");
            }
        }
        public override void AddCasualDay(string casualDay)
        {
            if (float.TryParse(casualDay, out float casualDayInFloat))
            {
                this.AddCasualDay(casualDayInFloat);
            }
            else
            {
                throw new Exception("Podana wartość musi być liczba");
            }
        }
        public override void AddCasualDay(int casualDay)
        {
            float casualDayIntInFloat = (float)casualDay;
            this.AddCasualDay(casualDayIntInFloat);
        }
        public override void AddSavings(float savings)
        {
            if (savings > 0)
            {
                this.listSavings.Add(savings);
            }
            else
            {
                throw new Exception("Wpisana kwota musi być dodatnia");
            }
        }
        public override void AddSavings(string savings)
        {
            if (float.TryParse(savings, out float savingsInFloat))
            {
                this.AddSavings(savingsInFloat);
            }
            else
            {
                throw new Exception("Podana wartość musi być liczba");
            }
        }
        public override void AddSavings(int savings)
        {
            float savingsIntInFloat = (float)savings;
            this.AddSavings(savingsIntInFloat);
        }
        public override MoneyForOneMonth DevideSalary()
        {
            var moneyForOneMonth = new MoneyForOneMonth();

            foreach (var money in salary)
            {
                moneyForOneMonth.DevideSalary(money);
                break;
            }
            foreach (var bill in listBills)
            {
                moneyForOneMonth.AddBills(bill);
            }
            foreach (var casualDay in listCasualDay)
            {
                moneyForOneMonth.AddCasualDay(casualDay);
                break;
            }

            foreach (var savings in listSavings)
            {
                moneyForOneMonth.AddSavings(savings);
                break;
            }
            return moneyForOneMonth;
        }
    }
}
