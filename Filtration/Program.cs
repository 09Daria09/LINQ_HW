
using System.Collections.Generic;

class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public int DepId { get; set; }
}
class Department
{
    public int Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
}
class Program
{
    static void Main()
    {
        List<Department> departments = new List<Department>()
 {
new Department(){ Id = 1, Country = "Ukraine", City = "Lviv" },
new Department(){ Id = 2, Country = "Ukraine", City = "Kyiv" },
new Department(){ Id = 3, Country = "France", City = "Paris" },
new Department(){ Id = 4, Country = "Ukraine", City = "Odesa" }
 };
        List<Employee> employees = new List<Employee>()
{
new Employee()
{ Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2 },
new Employee()
{ Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1 },
new Employee()
{ Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3 },
new Employee()
{ Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 },
new Employee()
{ Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4 },
new Employee()
{ Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2 },
new Employee()
{ Id = 7, FirstName = "Nikita", LastName = " Krotov ", Age = 27, DepId = 4 },
new Employee()
{ Id = 7, FirstName = "Dima", LastName = " Lipov ", Age = 27, DepId = 2 }
};


        while (true)
        {
            Console.WriteLine("\nВыберите номер задания для проверки:");
            Console.WriteLine("1) Выбрать имена и фамилии сотрудников, работающих в Украине, но не в Одессе.");
            Console.WriteLine("2) Вывести список стран без повторений.");
            Console.WriteLine("3) Выбрать 3-x первых сотрудников, возраст которых превышает 25 лет.");
            Console.WriteLine("4) Выбрать имена, фамилии и возраст студентов из Киева, возраст которых превышает 23 года.");
            Console.WriteLine("5) Выйти из программы.");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите число от 1 до 5.");
            }

            if (choice == 5)
            {
                Console.WriteLine("Выход из программы...");
                break;
            }

            switch (choice)
            {
                case 1:
                    SelectEmployeesNotInOdesa(employees, departments);
                    break;
                case 2:
                    PrintUniqueCountries(employees, departments);
                    break;
                case 3:
                    SelectFirstThreeOver25(employees, departments);
                    break;
                case 4:
                    SelectKyivResidentsOver23(employees, departments);
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, выберите номер задания от 1 до 4.");
                    break;
            }

        }
    }

    private static void SelectKyivResidentsOver23(List<Employee> employees, List<Department> departments)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Список жителей Киева старше 23 лет через синтаксис запросов LINQ:");
        var user = from e in employees
                    join d in departments on e.DepId equals d.Id
                    where d.City == "Kyiv" && e.Age > 23
                    select new { e.FirstName, e.LastName, e.Age };

        foreach (var person in user)
        {
            Console.WriteLine($"{person.FirstName} {person.LastName}, возраст: {person.Age}");
        }
        Console.ResetColor();

        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Список жителей Киева старше 23 лет через методы расширения LINQ:");
        var u = employees.Join(departments, e => e.DepId, d => d.Id, (e, d) => new { e.FirstName, e.LastName, e.Age, d.City })
                                     .Where(x => x.City == "Kyiv" && x.Age > 23)
                                     .Select(x => new { x.FirstName, x.LastName, x.Age });

        foreach (var person in u)
        {
            Console.WriteLine($"{person.FirstName} {person.LastName}, возраст: {person.Age}");
        }
        Console.ResetColor();
    }


    private static void SelectFirstThreeOver25(List<Employee> people, List<Department> departments)
    {
        var querySyntax = (from e in people
                           where e.Age > 25
                           orderby e.Age
                           select e).Take(3);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Первые три сотрудника старше 25 лет через синтаксис запросов LINQ:");
        foreach (var employee in querySyntax)
        {
            Console.WriteLine($"{employee.FirstName} {employee.LastName}, Возраст: {employee.Age}");
        }
        Console.ResetColor();

        Console.WriteLine();

        var methodSyntax = people.Where(e => e.Age > 25)
                                    .OrderBy(e => e.Age)
                                    .Take(3);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Первые три сотрудника старше 25 лет через методы расширения LINQ:");
        foreach (var employee in methodSyntax)
        {
            Console.WriteLine($"{employee.FirstName} {employee.LastName}, Возраст: {employee.Age}");
        }
        Console.ResetColor();

    }

    private static void PrintUniqueCountries(List<Employee> people, List<Department> departments)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Список стран без повторений через синтаксис запросов LINQ:");

        var query = (from c in departments
                     select c.Country).Distinct();
        foreach (var country in query)
        {
            Console.WriteLine(country);
        }

        Console.ResetColor();

        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Список стран без повторений через методы расширения LINQ:");

        var uniqueCountries = departments.Select(c => c.Country).Distinct();
        foreach (var country in uniqueCountries)
        {
            Console.WriteLine(country);
        }
        Console.ResetColor();
    }

    private static void SelectEmployeesNotInOdesa(List<Employee> employees, List<Department> departments)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Имена и фамилии сотрудников, работающих в Украине, но не в Одессе через синтаксис запросов LINQ:");
        var query = from employee in employees
                    join department in departments on employee.DepId equals department.Id
                    where department.Country == "Ukraine" && department.City != "Odesa"
                    group employee by new { employee.FirstName, employee.LastName, department.Country, department.City } into grouped
                    select grouped;

        foreach (var group in query)
        {
            Console.WriteLine($"{group.Key.LastName} {group.Key.FirstName} {group.Key.Country} {group.Key.City}");
        }
        Console.ResetColor();

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Имена и фамилии сотрудников, работающих в Украине, но не в Одессе через методы расширения LINQ:");

        var result = employees
       .Join(departments,
             employee => employee.DepId,
             department => department.Id,
             (employee, department) => new { Employee = employee, Department = department })
       .Where(x => x.Department.Country == "Ukraine" && x.Department.City != "Odesa")
       .GroupBy(x => new { x.Employee.FirstName, x.Employee.LastName, x.Department.Country, x.Department.City })
       .Select(group => group.Key);

        foreach (var item in result)
        {
            Console.WriteLine($"{item.LastName} {item.FirstName} {item.Country} {item.City}");
        }
        Console.ResetColor();
    }

}
