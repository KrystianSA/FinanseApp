namespace FinanceApp
{
    public class MoneyForOneMonth
    {
        public float bills { get; set; }
        public float casualDay { get; set; }
        public float savings { get; set; }
        public float sumBills { get; set; }
        public float sumCasualDay { get; set; }
        public float sumSavings { get; set; }

        public MoneyForOneMonth()
        {
            this.bills = 0;
            this.casualDay = 0;
            this.savings = 0;
            this.sumBills = 0;
            this.sumCasualDay = 0;
            this.sumSavings = 0;
        }

        public void DevideSalary(float salary)
        {
            this.bills = salary * 0.5f;
            this.casualDay = salary * 0.3f;
            this.savings = salary * 0.2f;
        }
        public void AddBills(float bill)
        {
            this.sumBills += bill;
        }

        public void AddCasualDay(float casualDay)
        {
            this.sumCasualDay += casualDay;
        }
        public void AddSavings(float savings)
        {
            this.sumSavings += savings;
        }
    }
}
