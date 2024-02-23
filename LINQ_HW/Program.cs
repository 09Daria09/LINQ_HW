using System;
using System.Collections.Generic;
using System.Linq;


namespace LINQ_HW
{

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }
   public  class Program
    {
        static void Main(string[] args)
        {
            List<Person> person = new List<Person>()
{
new Person(){ Name = "Andrey", Age = 24, City = "Kyiv"},
new Person(){ Name = "Liza", Age = 18, City = "Odesa" },
new Person(){ Name = "Oleg", Age = 15, City = "London" },
new Person(){ Name = "Sergey", Age = 55, City = "Kyiv" },
new Person(){ Name = "Sergey", Age = 32, City = "Lviv" }
};

            while (true)
            {
            Console.WriteLine("Выберите задание для проверки:");
            Console.WriteLine("1) Выбрать людей, старших 25 лет.");
            Console.WriteLine("2) Выбрать людей, проживающих не в Лондоне.");
            Console.WriteLine("3) Выбрать имена людей, проживающих в Киеве.");
            Console.WriteLine("4) Выбрать людей, старших 35 лет, с именем Sergey.");
            Console.WriteLine("5) Выбрать людей, проживающих в Одессе.");
            Console.WriteLine("10) Выход");

                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите число от 1 до 5.");
                }

                Console.Clear();
                switch (choice)
                {
                    case 1:
                        FilterPersonsByAge25AndOlder(person);
                        break;
                    case 2:
                        FilterPersonsNotInLondon(person);
                        break;
                    case 3:
                        FilterNamesInKyiv(person);
                        break;
                    case 4:
                        FilterPersonsOver35NamedSergey(person);
                        break;
                    case 5:
                        FilterPersonsInOdessa(person);
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, выберите номер задания от 1 до 5.");
                        break;
                }
            }
        }

        static void FilterPersonsByAge25AndOlder(List<Person> people)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Фильтрация людей старше 25 лет через методы расширения LINQ:");

            var Older = people.Where(person => person.Age > 25);

            foreach (var i in Older)
            {
                Console.WriteLine(i.Name + " :" + i.Age);
            }
            Console.ResetColor();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Фильтрация людей старше 25 лет через синтаксис запросов LINQ:");

            var selectedUsers = from user in people
                                where user.Age > 25
                                select user;
            foreach (var user in selectedUsers)
            {
                Console.WriteLine(user.Name + " :" + user.Age);
            }
            Console.ResetColor();
        }

        static void FilterPersonsNotInLondon(List<Person> people)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Фильтрация людей, не проживающих в Лондоне через методы расширения LINQ:");
            var user = people.Where(person => person.City != "London");
            foreach (var person in user)
            {
                Console.WriteLine(person.Name + " :" + person.City);
            }

            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Фильтрация людей, не проживающих в Лондоне через синтаксис запросов LINQ:");
            var selectedUsers = from user2 in people
                                where user2.City != "London"
                                select user2;
            foreach (var user2 in selectedUsers)
            {
                Console.WriteLine(user2.Name + " :" + user2.City);
            }

            Console.ResetColor();
        }

        static void FilterNamesInKyiv(List<Person> people)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Фильтрация имен людей, проживающих в Киеве через методы расширения LINQ:");

            var usrName = people.Where(person => person.City == "Kyiv").Select(people => people.Name);
            foreach (var user2 in usrName)
            {
                Console.WriteLine(user2);
            }

            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Фильтрация имен людей, проживающих в Киеве через синтаксис запросов LINQ:");
            var Users = from user2 in people
                    where user2.City == "Kyiv"
                        select user2.Name;
            foreach (var user2 in Users)
            {
                Console.WriteLine(user2);
            }
            Console.ResetColor();

        }

        static void FilterPersonsOver35NamedSergey(List<Person> people)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Фильтрация людей старше 35 лет с именем Sergey через методы расширения LINQ:");
            var user = people.Where(person => person.Age > 35).Where(user => user.Name == "Sergey");
            foreach (var person in user)
            {
                Console.WriteLine(person.Name + " :" + person.Age);
            }
            Console.ResetColor();
            Console.WriteLine();


            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Фильтрация людей старше 35 лет с именем Sergey через синтаксис запросов LINQ:");
            var Users = from user2 in people
                        where user2.Age > 35 && user2.Name == "Sergey"
                        select user2;

            foreach (var user2 in Users)
            {
                Console.WriteLine(user2.Name + " :" + user2.Age);
            }
            Console.ResetColor();
        }

        static void FilterPersonsInOdessa(List<Person> people)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Фильтрация людей, проживающих в Одессе через методы расширения LINQ:");
            var user = people.Where(person => person.City == "Odesa");
            foreach (var person in user)
            {
                Console.WriteLine(person.Name + " :" + person.Age + " - " + person.City);
            }
            Console.ResetColor();
            Console.WriteLine();


            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Фильтрация людей, проживающих в Одессе через синтаксис запросов LINQ:");
            var Users = from user2 in people
                        where user2.City == "Odesa"
                        select user2;

            foreach (var user2 in Users)
            {
                Console.WriteLine(user2.Name + " :" + user2.Age + " - " + user2.City);
            }
            Console.ResetColor();
        }
        

            /*
             Список используемых методов расширения LINQ

                Select: определяет проекцию выбранных значений
                Where: определяет фильтр выборки
                OrderBy: упорядочивает элементы по возрастанию
                OrderByDescending: упорядочивает элементы по убыванию
                ThenBy: задает дополнительные критерии для упорядочивания элементов возрастанию
                ThenByDescending: задает дополнительные критерии для упорядочивания элементов по убыванию
                Join: соединяет две коллекции по определенному признаку
                GroupBy: группирует элементы по ключу
                ToLookup: группирует элементы по ключу, при этом все элементы добавляются в словарь
                GroupJoin: выполняет одновременно соединение коллекций и группировку элементов по ключу
                Reverse: располагает элементы в обратном порядке
                All: определяет, все ли элементы коллекции удовлятворяют определенному условию
                Any: определяет, удовлетворяет хотя бы один элемент коллекции определенному условию
                Contains: определяет, содержит ли коллекция определенный элемент
                Distinct: удаляет дублирующиеся элементы из коллекции
                Except: возвращает разность двух коллекцию, то есть те элементы, которые содератся только в одной коллекции
                Union: объединяет две однородные коллекции
                Intersect: возвращает пересечение двух коллекций, то есть те элементы, которые встречаются в обоих коллекциях
                Count: подсчитывает количество элементов коллекции, которые удовлетворяют определенному условию
                Sum: подсчитывает сумму числовых значений в коллекции
                Average: подсчитывает cреднее значение числовых значений в коллекции
                Min: находит минимальное значение
                Max: находит максимальное значение
                Take: выбирает определенное количество элементов
                Skip: пропускает определенное количество элементов
                TakeWhile: возвращает цепочку элементов последовательности, до тех пор, пока условие истинно
                SkipWhile: пропускает элементы в последовательности, пока они удовлетворяют заданному условию, и затем возвращает оставшиеся элементы
                Concat: объединяет две коллекции
                Zip: объединяет две коллекции в соответствии с определенным условием
                First: выбирает первый элемент коллекции
                FirstOrDefault: выбирает первый элемент коллекции или возвращает значение по умолчанию
                Single: выбирает единственный элемент коллекции, если коллекция содердит больше или меньше одного элемента, то генерируется исключение
                SingleOrDefault: выбирает первый элемент коллекции или возвращает значение по умолчанию
                ElementAt: выбирает элемент последовательности по определенному индексу
                ElementAtOrDefault: выбирает элемент коллекции по определенному индексу или возвращает значение по умолчанию, если индекс вне допустимого диапазона
                Last: выбирает последний элемент коллекции
                LastOrDefault: выбирает последний элемент коллекции или возвращает значение по умолчанию
            */
        }
    }

