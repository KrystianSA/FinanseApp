/*Aplikacja do zarządzania budżetem domowym, założenia : 
- wpisywanie użytkownika 
- obliczanie wydatków na dany miesiąc */
using FinanceApp;
Console.WriteLine("Witaj w aplikacji do zarządzania budżetem domowym");
Console.WriteLine("================================================");
/*Console.WriteLine("Wpisz nowego użytkownika");
Console.Write("Imie : ");
var userName = Console.ReadLine();
Console.Write("Nazwisko : ");
var userSurname = Console.ReadLine();
var user = new User(userName, userSurname);
Console.WriteLine($"Nowy użytkownik {user.Name} {user.Surname}");*/

var user = new FinanceFile("Krystian", "Sąsiadek");
Console.WriteLine("Podaj swój dochód miesięczny. Program rozdzieli twoje wydatki na dany miesiąc.");

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
                user.AddBills(bill);
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
                user.AddCasualDay(casualDay);
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
                user.AddSavings(savings);
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
}
var salary2 = user.DevideSalary();

Console.WriteLine($"rachunki {salary2.sumBills}");
Console.WriteLine($"życie {salary2.sumCasualDay}");
Console.WriteLine($"oszczędności {salary2.sumSavings}");



