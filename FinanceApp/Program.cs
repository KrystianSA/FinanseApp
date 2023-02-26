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
/*Console.WriteLine("Podaj swój dochód miesięczny");
var salary = Console.ReadLine();
user.AddSalary(salary);
Console.WriteLine($"zarobki miesięczne to : {salary} ");
*/
var salary1 = user.DevideSalary();
/*
Console.WriteLine($"rachunki {salary1.bills}");
Console.WriteLine($"życie {salary1.casualDay}");
Console.WriteLine($"oszczędności {salary1.savings}");
*/
Console.WriteLine("Dodaj kwotę rachunku, wyjdz literą q ");

while(true)
{
    var bill = Console.ReadLine();

    if(bill!="q")
    {
        user.AddBills(bill);
    }
    else
    {
        break;
    }
}
Console.WriteLine($"suma {salary1.sumBills}");