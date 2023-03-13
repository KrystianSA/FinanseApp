/*Aplikacja do zarządzania budżetem domowym, założenia : 
- wpisywanie użytkownika 
- obliczanie wydatków na dany miesiąc */
using FinanceApp;
using System.Linq.Expressions;

Console.WriteLine("Witaj w aplikacji do zarządzania budżetem domowym");
Console.WriteLine("================================================");
Console.WriteLine("Podaj swoje dane");
Console.Write("Imie : ");
var userName = Console.ReadLine();
Console.Write("Nazwisko : ");
var userSurname = Console.ReadLine();
var user = new FinanceFile(userName, userSurname);

Console.WriteLine("Podaj swój dochód miesięczny. Program rozdzieli twoje wydatki na dany miesiąc.");

user.MoneyAdded += UserMoneyAdded;

void UserMoneyAdded(object sender, EventArgs args)
{
    Console.WriteLine("Dochód miesięczny został dodany");
    Console.WriteLine(" ");
}

while (true)
{
    var salary = Console.ReadLine();
    if (salary != null)
    {
        try
        {
            user.AddSalary(salary);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
        if (float.TryParse(salary, out float salaryInFloat))
        {
            if (salaryInFloat > 0)
                break;
        }
    }
}

var salary1 = user.DevideSalary();

Console.WriteLine($"Dziennik finansowy należący do {user.Name} {user.Surname}");
Console.WriteLine(" ");
Console.WriteLine($"Kwota przeznaczona na rachunki {salary1.bills:N2}");
Console.WriteLine($"Kwota przeznaczona na wydatki codzienne {salary1.casualDay:N2}");
Console.WriteLine($"Kwota do zaoszczędzenia {salary1.savings:N2}");
Console.WriteLine(" ");
Console.WriteLine("Dodaj kwotę rachunków. Wybierz odpowiednią grupę.");
Console.WriteLine("B - rachunki ");
Console.WriteLine("Z - wydatki codzienne");
Console.WriteLine("O - oszczędności ");
Console.WriteLine(" ");
Console.WriteLine("Naciśnięcie 'q' powoduje wyjście.");
Console.WriteLine(" ");

while (true)
{
    var choice = Console.ReadLine();
    if (choice == "B" || choice == "b")
    {
        Console.WriteLine("Wybrana grupa to rachunki. Wybór 'q' powoduje wyjście");
        Console.Write("Dodaj kwote :");
        while (true)
        {
            var bill = Console.ReadLine();
            if (bill != "q")
            {
                try
                {
                    user.AddBills(bill);
                }
                catch(Exception exception) 
                {
                    Console.WriteLine(exception.Message);
                }
                Console.Write("Dodaj kwote :");
            }
            else if (bill == "q")
            {
                Console.WriteLine("Wybierz miejsce do wpisania kwoty lub wyjdź naciskając 'q'");
                break;
            }
        }
    }
    else if (choice == "Z" || choice == "z")
    {
        Console.WriteLine("Wybrana grupa to wydatki codzienne. Wybór 'q' powoduje wyjście");
        Console.Write("Dodaj kwote :");
        while (true)
        {
            var casualDay = Console.ReadLine();
            if (casualDay != "q")
            {
                try
                {
                    user.AddCasualDay(casualDay);
                }
                catch( Exception exception) 
                {
                    Console.WriteLine(exception.Message);
                }
                Console.Write("Dodaj kwote :");
            }
            else if (casualDay == "q")
            {
                Console.WriteLine("Wybierz miejsce do wpisania kwoty");
                break;
            }
        }
    }
    else if (choice == "O" || choice == "o")
    {
        Console.WriteLine("Wybrana grupa to kwota do zaoszczędzenia. Wybór 'q' powoduje wyjście");
        Console.Write("Dodaj kwote :");
        while (true)
        {
            var savings = Console.ReadLine();
            if (savings != "q")
            {
                try
                {
                    user.AddSavings(savings);
                }
                catch(Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
                Console.Write("Dodaj kwote :");
            }
            else if (savings == "q")
            {
                Console.WriteLine("Wybierz miejsce do wpisania kwoty");
                break;
            }
        }
    }
    else if (choice == "q")
    {
        Console.WriteLine("Zamknąłeś dziennik.");
        break;
    }
    else
    {
        Console.WriteLine("Wybierz grupę lub wyjdź");
    }
}
var salary2 = user.DevideSalary();

Console.WriteLine(" ");
Console.WriteLine($"Rachunki wyniosły {salary2.sumBills}");
if (salary2.sumBills > salary1.bills)
{
    Console.WriteLine($" ===> Przekroczono kwotę przeznaczoną na rachunki o {salary2.sumBills - salary1.bills}");
}

Console.WriteLine($"Kwota na wydatki codzienne wyniosła  {salary2.sumCasualDay}");
if (salary2.sumCasualDay > salary1.casualDay)
{
    Console.WriteLine($" ===> Przekroczono kwotę przeznaczoną na wydatki codzienne o {salary2.sumCasualDay-salary1.casualDay}");
}

Console.WriteLine($"Ilość zaoszczędzonych pieniędzy to  {salary2.sumSavings}");
if (salary2.sumSavings > salary1.savings)
{
    Console.WriteLine($"Odłożono więcej niż zakładano. Good JOB !");
}


