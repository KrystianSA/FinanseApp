
using System.Runtime.InteropServices;

namespace FinanceApp
{
    public class FinanceFile : FinanceBase
    {
        private const string fileName = "summary.txt";
        private List<float> salary = new List<float>();
        private List<float> listBills = new List<float>();
        private List<float> listCasualDay = new List<float>();
        private List<float> listSavings = new List<float>();

        public override event AlertAddedDelegate AlertAdded;

        public FinanceFile(string name, string surname) : base(name, surname)
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
                Console.WriteLine("Wpisana kwota musi być dodatnia");
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
                Console.WriteLine("Podana wartość musi być liczba");
            }
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

            if (File.Exists(fileName))
            {
                File.WriteAllText(fileName, String.Empty);
                using (var reader = File.OpenText(fileName))
                {
                    reader.ReadLine();
                }
            }
            using (var writer = File.AppendText(fileName))
            {
                foreach (var money in salary)
                {
                    moneyForOneMonth.bills = money * 0.5f;
                    moneyForOneMonth.casualDay = money * 0.3f;
                    moneyForOneMonth.savings = money * 0.2f;
                    writer.WriteLine($"Kwota jaką możesz wydać na ruchunki {moneyForOneMonth.bills:N2}");
                    writer.WriteLine($"Kwota jaką możesz wydać na wydatki codzienne {moneyForOneMonth.casualDay:N2}");
                    writer.WriteLine($"Kwota jaką możesz zaoszczędzić {moneyForOneMonth.savings:N2}");
                    writer.WriteLine(" ");
                }
            }
            using (var writer = File.AppendText(fileName))
            {
                foreach (var bill in listBills)
                {
                    moneyForOneMonth.sumBills += bill;
                    if(moneyForOneMonth.sumBills > bill)
                    {
                        writer.WriteLine($"Rachunnki w tym miesiącu wyniosły: {moneyForOneMonth.sumBills}");
                        break;
                    }
                    else if (moneyForOneMonth.sumBills > moneyForOneMonth.bills)
                    {
                        writer.Write($"Rachunnki w tym miesiącu wyniosły: {moneyForOneMonth.sumBills}");
                        writer.WriteLine(" ===> W tym miesiącu przekroczyłeś kwotę założoną na rachunki");
                    }
                }
            }
            using (var writer = File.AppendText(fileName))
            {
                foreach (var casualDay in listCasualDay)
                {
                    moneyForOneMonth.sumCasualDay+= casualDay;
                    if (moneyForOneMonth.sumCasualDay > casualDay)
                    {
                        writer.WriteLine($"Wydatki codzienne w tym miesiącu wyniosły : {moneyForOneMonth.sumCasualDay}");
                        break;
                    }
                    else if (moneyForOneMonth.sumCasualDay > moneyForOneMonth.casualDay)
                    {
                        writer.Write($"Wydatki codzienne w tym miesiącu wyniosły : {moneyForOneMonth.sumCasualDay}");
                        writer.WriteLine(" ===> W tym miesiącu przekroczyłeś kwotę założoną na wydatki codzienne");
                    }
                }
            }

            using (var writer = File.AppendText(fileName))
            {
                foreach (var savings in listSavings)
                {
                    moneyForOneMonth.sumSavings+= savings;
                    if (moneyForOneMonth.sumSavings > savings)
                    {
                        writer.WriteLine($"Suma zaoszczędzonych pieniędzy {moneyForOneMonth.sumSavings}");
                    }                  
                    else if (moneyForOneMonth.sumSavings > moneyForOneMonth.savings)
                    {
                        writer.Write($"Suma zaoszczędzonych pieniędzy {moneyForOneMonth.sumSavings}");
                        writer.WriteLine(" ===> O ty Żydzie");
                    }
                }
            }
            return moneyForOneMonth;
        }
    }
}
