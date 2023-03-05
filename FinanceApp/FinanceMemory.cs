namespace FinanceApp
{
    public class FinanceMemory : FinanceBase
    {
        private List<float> salary = new List<float>();
        private List<float> listBills = new List<float>();
        private List<float> listCasualDay = new List<float>();
        private List<float> listSavings = new List<float>();

        public override event AlertAddedDelegate AlertAdded;

        public FinanceMemory(string name, string surname) : base(name, surname)
        {

        }
        public override void AddSalary(float salary)
        {
            if (salary > 0)
            {
                this.salary.Add(salary);
            }
            else
            {
                Console.WriteLine("wartość przychodu nie może być ujemna");
            }
        }
        public override void AddSalary(string salary)
        {
            float.TryParse(salary, out float salaryInfloat);
            this.AddSalary(salaryInfloat);
        }
        public override void AddSalary(int salary)
        {
            float salaryIntInFloat = (float)salary;
            this.AddSalary(salaryIntInFloat);
        }
        public override void AddBills(float bills)
        {
            this.listBills.Add(bills);
        }
        public override void AddBills(string bills)
        {
            float.TryParse(bills, out float billsInfloat);
            this.AddBills(billsInfloat);
        }
        public override void AddBills(int bills)
        {
            float billsIntInFloat = (float)bills;
            this.AddBills(billsIntInFloat);
        }

        public override void AddCasualDay(float casualDay)
        {
            this.listCasualDay.Add(casualDay);
        }
        public override void AddCasualDay(string casualDay)
        {
            float.TryParse(casualDay, out float casualDayInFloat);
            this.AddCasualDay(casualDayInFloat);
        }
        public override void AddCasualDay(int casualDay)
        {
            float casualDayIntInFloat = (float)casualDay;
            this.AddCasualDay(casualDayIntInFloat);
        }
        public override void AddSavings(float savings)
        {
            this.listSavings.Add(savings);
        }
        public override void AddSavings(string savings)
        {
            float.TryParse(savings, out float savingsInFloat);
            this.AddSavings(savingsInFloat);
        }
        public override void AddSavings(int savings)
        {
            float savingsIntInFloat = (float)savings;
            this.AddSavings(savingsIntInFloat);
        }
        public override MoneyForOneMonth DevideSalary()
        {
            var moneyForOneMonth = new MoneyForOneMonth();
            moneyForOneMonth.bills = 0;
            moneyForOneMonth.casualDay = 0;
            moneyForOneMonth.savings = 0;
            moneyForOneMonth.sumBills = 0;
            moneyForOneMonth.sumCasualDay = 0;
            moneyForOneMonth.sumSavings = 0;

            foreach (var money in salary)
            {
                moneyForOneMonth.bills = money * 0.5f;
                moneyForOneMonth.casualDay = money * 0.3f;
                moneyForOneMonth.savings = money * 0.2f;

            }
            foreach (var bill in listBills)
            {
                moneyForOneMonth.sumBills += bill;
                if (moneyForOneMonth.sumBills > moneyForOneMonth.bills)
                {
                    Console.WriteLine("$W tym miesiącu przekroczyłeś kwotę założoną na rachunki");
                }
            }

            foreach (var casualDay in listCasualDay)
            {
                moneyForOneMonth.sumCasualDay += casualDay;
                if (moneyForOneMonth.sumCasualDay > moneyForOneMonth.casualDay)
                {
                    Console.WriteLine("$W tym miesiącu przekroczyłeś kwotę założoną na życie codzienne");
                }
            }

            foreach (var savings in listSavings)
            {
                moneyForOneMonth.sumSavings += savings;
                if (moneyForOneMonth.sumSavings > moneyForOneMonth.savings)
                {
                    Console.WriteLine("O ty Żydzie");
                }
            }
            return moneyForOneMonth;
        }
    }
}
