namespace FinanceApp
{
    public class FinanceMemory : FinanceBase
    {
        private List<float> salary = new List<float>();
        private List<float> listBills = new List<float>();
        public FinanceMemory(string name, string surname) : base(name, surname)
        {

        }
        public string Name { get; set; }
        public string Surname { get; set; }

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
            AddSalary(salaryInfloat);
        }

        public override void AddBills(float bills)
        {
            this.listBills.Add(bills);
        }
        public override void AddBills(string bills)
        {
            float.TryParse(bills, out float billsInfloat);
            AddBills(billsInfloat);
        }

        public override MoneyForOneMonth DevideSalary()
        {
            var moneyForOneMonth = new MoneyForOneMonth();
            moneyForOneMonth.bills = 0;
            moneyForOneMonth.casualDay = 0;
            moneyForOneMonth.savings = 0;
            moneyForOneMonth.sumBills = 0;

            /*foreach (var money in salary)
            {
                moneyForOneMonth.bills = money * 0.5f;
                moneyForOneMonth.casualDay = money * 0.3f;
                moneyForOneMonth.savings = money * 0.2f;
            }*/

            foreach (var bill in listBills)
            {
                moneyForOneMonth.sumBills += bill;
            }
            return moneyForOneMonth;
        }
    }
}
