/*Aplikacja do zarządzania budżetem domowym, założenia : 
- wpisywanie użytkownika 
- obliczanie wydatków na dany miesiąc */
/*using FinanceApp;
Console.WriteLine("Witaj w aplikacji do zarządznia budżetem domowym");
Console.WriteLine("================================================");
Console.WriteLine("Wpisz nowego użytkownika");
Console.Write("Imie : ");
var userName = Console.ReadLine();
Console.Write("Nazwisko : ");
var userSurname = Console.ReadLine();
var user = new User(userName, userSurname);
Console.WriteLine($"Nowy użytkownik {user.Name} {user.Surname}");*/
using FinanceApp;
using System.ComponentModel.DataAnnotations;

var user = new FinanceFile("Krystian", "Sąsiadek");
Console.WriteLine("Podaj swój dochód miesięczny");

while (true)
{
    var salary = Console.ReadLine();
    if (salary != null)
    {
        user.AddSalary(salary);
        if(float.TryParse(salary, out float salaryInFloat))
        {
            if(salaryInFloat> 0)
            break;
        }
    }
}
var salary1 = user.DevideSalary();

Console.WriteLine($"Piniądze na rachunki {salary1.bills}");
Console.WriteLine($"Piniądze na wydatki codzienne {salary1.casualDay}");
Console.WriteLine($"Oszczędności {salary1.savings}");
Console.WriteLine(" ");
Console.WriteLine("Dodaj kwotę rachunków. Wybierz miejsce, gdzie chcesz dodać wydatek. " +
    "B - rachunki " +
    "Z - wydatki codzienne" +
    "O - oszczędności ");
Console.WriteLine(" ");

while (true)
{
    var choice = Console.ReadLine();
    if (choice == "B")
    {
        Console.WriteLine("Wybór 'q' powoduje wyjście");
        Console.WriteLine("Dodaj kwote ");
        while (true)
        {
            var bill = Console.ReadLine();
            if (bill != "q")
            {
                user.AddBills(bill);
            }
            else if (bill == "q")
            {
                Console.WriteLine("Wybierz miejsce do wpisania kwoty lub wyjdź naciskając 'q'");
                break;
            }
        }
    }
    else if (choice == "Z")
    {
        Console.WriteLine("Wybór 'q' powoduje wyjście");
        Console.WriteLine("Dodaj kwote ");
        while (true)
        {
            var casualDay = Console.ReadLine();
            if (casualDay != "q")
            {
                user.AddCasualDay(casualDay);
            }
            else if (casualDay == "q")
            {
                Console.WriteLine("Wybierz miejsce do wpisania kwoty");
                break;
            }
        }
    }
    else if (choice == "O")
    {
        Console.WriteLine("Wybór 'q' powoduje wyjście");
        Console.WriteLine("dodaj kwote ");
        while (true)
        {
            var savings = Console.ReadLine();
            if (savings != "q")
            {
                user.AddSavings(savings);
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
        Console.WriteLine("Zamknąłeś dziennik");
        break;
    }
}
var salary2 = user.DevideSalary();

Console.WriteLine($"rachunki {salary2.sumBills}");
Console.WriteLine($"życie {salary2.sumCasualDay}");
Console.WriteLine($"oszczędności {salary2.sumSavings}");

