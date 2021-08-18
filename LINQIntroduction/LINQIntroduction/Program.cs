using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQIntroduction
{
    class Program
    {
        static List<Person> GetEmployees()
        {
            List<Person> employees = new List<Person>()
            {
                new Person(new DateTime(1990, 2, 2), "Bill", "Wick"),
                new Person(new DateTime(1995, 6, 3), "John", "Wick"),
                new Person(new DateTime(1996, 4, 3), "Bob", "Wick"),
                new Person(new DateTime(2001, 2, 2), "Bill", "Smith"),
                new Person(new DateTime(2000, 2, 2), "John", "Smith"),
                new Person(new DateTime(2005, 2, 2), "BoB", "Smith"),
                new Person(new DateTime(2003, 2, 2), "Ed", "Smith"),
            };

            return employees;
        }

        static void Main(string[] args)
        {
            List<Person> employees = GetEmployees();

            bool EmployeeIsYoung(Person employee)
            {
                return employee.GetDateOfBirth() > new DateTime(2000, 1, 1);
            }
            List<Person> youngEmployees = employees.Where(e => e.GetDateOfBirth() > new DateTime(2000, 1, 1)).ToList(); //Lambda Expression

            /* Refacturised code - LINQ usage
            List<Person> youngEmployees = new List<Person>();
            foreach (Person employee in employees)
            {
                if (employee.GetDateOfBirth() > new DateTime(2000, 1, 1))
                {
                    youngEmployees.Add(employee);
                }
            }
            */

            Console.WriteLine($"Young employees count: {youngEmployees.Count}");

            bool EmployeeIsBoB(Person employee)
            {
                return employee.FirstName == "Bob";
            }
            Person bob = youngEmployees.FirstOrDefault(e => e.FirstName == "Bob");

            /* Refacturised code - LINQ usage
            Person bob = null;
            foreach (Person youngEmployee in youngEmployees)
            {
                if (youngEmployee.FirstName == "Bob")
                {
                    bob = youngEmployee;
                    break;
                }
            }
            */

            if (bob != null)
            {
                bob.SayHi();
            }
            else
            {
                Console.WriteLine("Bob not found");
            }
        }
    }
}
