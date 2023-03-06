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
            if (this.sumBills > bill)
            {
                Console.WriteLine("W tym miesiącu przekroczyłeś kwotę założoną na rachunki");
                Console.Write($"Rachunki wyniosły: {this.sumBills}");
                Console.WriteLine($" ===> Przekroczyłeś kwotę założoną na rachunki o {this.sumBills-this.bills}");
                if (this.sumBills > this.bills)
                {
                    Console.WriteLine("W tym miesiącu przekroczyłeś kwotę założoną na rachunki");
                    Console.Write($"Rachunki wyniosły: {this.sumBills}");
                    Console.WriteLine($" ===> Przekroczyłeś kwotę założoną na rachunki o {this.sumBills - this.bills}");
                }
            }
        }
        public void AddCasualDay(float casualDay) 
        {
            this.sumCasualDay += casualDay;
            if (this.sumCasualDay > casualDay)
            {
                Console.WriteLine("W tym miesiącu przekroczyłeś kwotę założoną na życie codzienne");
                Console.Write($"Koszty wydatków codziennych wyniosły: {this.sumCasualDay}");
                if (this.sumCasualDay > this.casualDay)
                {
                    Console.WriteLine($" ===> Przekroczyłeś kwotę założoną na wydatki codzienne o {this.sumCasualDay - this.casualDay}");
                    Console.WriteLine("W tym miesiącu przekroczyłeś kwotę założoną na życie codzienne");
                    Console.Write($"Koszty wydatków codziennych wyniosły: {this.sumCasualDay}");
                }
            }
        }/*
        public void AddSavings(float savings) 
        {
            this.sumSavings += savings;
            if (this.sumSavings > savings)
            {
                Console.WriteLine("O ty Żydzie");
                Console.WriteLine($"Zaosczędziłeś tyle siana ! OOOOO tyle : {this.sumSavings}");
            }
        }*/
    }
}
