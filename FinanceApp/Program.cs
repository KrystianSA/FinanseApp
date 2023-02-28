/* Aplikacja do zarządzania budżetem domowym, założenia : 
- wpisywanie użytkownika 
- obliczanie wydatków na dany miesiąc */

using FinanceApp;
Console.WriteLine("Witaj w aplikacji do zarządznia budżetem domowym");
Console.WriteLine("================================================");
/*Console.WriteLine("Wpisz nowego użytkownika");
Console.Write("Imie : ");
var userName = Console.ReadLine();
Console.Write("Nazwisko : ");
var userSurname = Console.ReadLine();
var user = new User(userName, userSurname);
Console.WriteLine($"Nowy użytkownik {user.Name} {user.Surname}");*/
var user = new FinanceMemory("Krystian", "Sąsiadek");
Console.WriteLine("Podaj swój dochód miesięczny");
var salary = Console.ReadLine();
user.AddSalary(salary);

Console.WriteLine("Dodaj kwotę rachunków. Wybierz miejsce, gdzie chcesz dodać wydatek. " +
    "B - rachunki " +
    "Z - wydatki codzienne" +
    "O - oszczędności ");

while (true)
{
    var bill = Console.ReadLine();
    if (bill == "B")
    {
        user.AddBills(bill);
    }
    else if (bill == "Z")
    {
        user.AddCasualDay(bill);
    }
    else if (bill == "Z")
    {
        user.AddSavings(bill);
    }
    else { break; }
}

var salary1 = user.DevideSalary();

float.TryParse(salary, out float salaryInFloat);
if(salary1.sumBills > salaryInFloat)
{
    Console.WriteLine("Wydano za dużo o {}");
}

Console.WriteLine($"zarobki miesięczne to : {salary} ");
Console.WriteLine($"suma rachunków {salary1.sumBills}");
Console.WriteLine($"suma codziennych wydatków {salary1.sumBills}");
Console.WriteLine($"suma oszczędności {salary1.sumBills}");
Console.WriteLine($"rachunki {salary1.bills}");
Console.WriteLine($"życie {salary1.casualDay}");
Console.WriteLine($"oszczędności {salary1.savings}");

/* wpisywanie bieżacych rachunków w pętli*/