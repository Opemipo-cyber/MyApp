using System;
using System.Collections;
using System.Collections.Generic;

class Employee
{
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }

    public Employee(string name, string department, double salary)
    {
        Name = name;
        Department = department;
        Salary = salary;
    }

    public void GiveRaise(double percentage)
    {
        Salary += Salary * (percentage / 100);
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Department: {Department}");
        Console.WriteLine($"Salary: {Salary}");
        Console.WriteLine();
    }
}

class Book
{
    public string Title;
    public string Author;
    public double Price;
    public int Pages;

    public Book(string title, string author, double price, int pages)
    {
        Title = title;
        Author = author;
        Price = price;
        Pages = pages;
    }

    public bool IsBestSeller(int sales)
    {
        return sales > 10000;
    }
}

class SimpleCalculator
{
    public double Memory;

    public double Add(double a, double b) => a + b;
    public double Subtract(double a, double b) => a - b;
    public double Multiply(double a, double b) => a * b;
    public double Divide(double a, double b) => a / b;

    public void SaveToMemory(double value)
    {
        Memory = value;
    }

    public double RecallMemory()
    {
        return Memory;
    }
}

class Program
{
    static void Main()
    {
        // EXERCISE 1
        Console.WriteLine("EXERCISE 1");
        Console.Write("Enter full name: ");
        string fullName = Console.ReadLine()!;

        string[] names = fullName.Split(' ');

        foreach (string name in names)
        {
            Console.Write(name[0] + ".");
        }

        Console.WriteLine("\n");

        // EXERCISE 2
        Console.WriteLine("EXERCISE 2");
        Console.Write("Enter password: ");
        string password = Console.ReadLine() !;

        bool isLongEnough = password.Length >= 8;
        bool contains123 = password.Contains("123");

        if (isLongEnough && !contains123)
        {
            Console.WriteLine("Strong password");
        }
        else
        {
            Console.WriteLine("Weak password");

            if (contains123)
            {
                Console.WriteLine("Warning: Password contains '123'");
            }
        }

        Console.WriteLine();

        // EXERCISE 3
        Console.WriteLine("EXERCISE 3");
        Console.Write("Enter a string: ");
        string text = Console.ReadLine();

        string reversed = "";

        for (int i = text.Length - 1; i >= 0; i--)
        {
            reversed += text[i];
        }

        Console.WriteLine("Reversed string: " + reversed);
        Console.WriteLine();

        // EXERCISE 4
        Console.WriteLine("EXERCISE 4");

        Employee emp1 = new Employee("John", "IT", 50000);
        Employee emp2 = new Employee("Mary", "HR", 45000);
        Employee emp3 = new Employee("David", "Finance", 60000);

        emp1.GiveRaise(10);
        emp2.GiveRaise(5);
        emp3.GiveRaise(15);

        emp1.DisplayInfo();
        emp2.DisplayInfo();
        emp3.DisplayInfo();

        // EXERCISE 5
        Console.WriteLine("EXERCISE 5");

        Book book1 = new Book("Book A", "Author A", 20.5, 300);
        Book book2 = new Book("Book B", "Author B", 15.0, 250);
        Book book3 = new Book("Book C", "Author C", 30.0, 500);

        Console.WriteLine(book1.Title + ": " + book1.IsBestSeller(12000));
        Console.WriteLine(book2.Title + ": " + book2.IsBestSeller(8000));
        Console.WriteLine(book3.Title + ": " + book3.IsBestSeller(20000));

        Console.WriteLine();

        // EXERCISE 6
        Console.WriteLine("EXERCISE 6");

        SimpleCalculator calc = new SimpleCalculator();

        Console.WriteLine("1. Add");
        Console.WriteLine("2. Subtract");
        Console.WriteLine("3. Multiply");
        Console.WriteLine("4. Divide");

        Console.Write("Choose operation: ");
        int choice = int.Parse(Console.ReadLine());

        Console.Write("Enter first number: ");
        double num1 = double.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        double num2 = double.Parse(Console.ReadLine());

        double result = 0;

        switch (choice)
        {
            case 1:
                result = calc.Add(num1, num2);
                break;

            case 2:
                result = calc.Subtract(num1, num2);
                break;

            case 3:
                result = calc.Multiply(num1, num2);
                break;

            case 4:
                result = calc.Divide(num1, num2);
                break;

            default:
                Console.WriteLine("Invalid choice");
                break;
        }

        calc.SaveToMemory(result);

        Console.WriteLine("Result: " + result);
        Console.WriteLine("Memory: " + calc.RecallMemory());

        Console.WriteLine();

        // EXERCISE 7
        Console.WriteLine("EXERCISE 7");

        Stack<string> pages = new Stack<string>();

        pages.Push("google.com");
        pages.Push("youtube.com");
        pages.Push("github.com");

        Console.WriteLine("Current Page: " + pages.Peek());

        pages.Pop();

        if (pages.Count > 0)
        {
            Console.WriteLine("Back To: " + pages.Peek());
        }
        else
        {
            Console.WriteLine("No pages left.");
        }

        Console.WriteLine();

        // EXERCISE 8
        Console.WriteLine("EXERCISE 8");

        Queue<string> patients = new Queue<string>();

        patients.Enqueue("John");
        patients.Enqueue("Mary");
        patients.Enqueue("David");

        Console.WriteLine("Next Patient: " + patients.Peek());

        patients.Dequeue();

        Console.WriteLine("After Attending One Patient:");
        Console.WriteLine("Next Patient: " + patients.Peek());

        Console.WriteLine();

        // EXERCISE 9
        Console.WriteLine("EXERCISE 9");

        SortedList students = new SortedList();

        students.Add("Alice", 85);
        students.Add("John", 90);
        students.Add("Mary", 78);

        Console.WriteLine("John's Score: " + students["John"]);

        foreach (DictionaryEntry student in students)
        {
            Console.WriteLine(student.Key + ": " + student.Value);
        }

        Console.WriteLine();

        // EXERCISE 10
        Console.WriteLine("EXERCISE 10");

        Hashtable phonebook = new Hashtable();

        phonebook.Add("John", "08012345678");
        phonebook.Add("Mary", "08123456789");

        phonebook["John"] = "09098765432";

        Console.WriteLine("John's Number: " + phonebook["John"]);

        phonebook.Remove("Mary");

        foreach (DictionaryEntry contact in phonebook)
        {
            Console.WriteLine(contact.Key + ": " + contact.Value);
        }
    }
}