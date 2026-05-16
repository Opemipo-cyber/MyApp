using System;
using System.IO.Pipelines;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

class Assignment
{
    //  Task 1: Overload describe Methods
    static void Describe(string name)
    {
        Console.WriteLine($"Name: {name}");
    }
    static void Describe(string name, int age)
    {
        Console.WriteLine($"Name: {name}, Age: {age}");
    }
    static void Describe(string name, int age, string city)
    {
        Console.WriteLine($"Name: {name}, Age: {age}, City: {city}");
    }
    //Task 2: Fix score using ref
    static void Fixscore(ref int score)
    {
        if (score < 0)
        {
            score = 0;
        }
        else if (score is > 100)
        {
            score = 100;
        }
    }
    // Task 3: FindHighest with params
    static int FindHighest(params int[] numbers)
    {
        int highest = numbers[0];
        foreach (int n in numbers) if (n > highest) highest = n;
        return highest;
    }

    //Task 4: Overloaded Volume
    static double Volume(double side) =>- side * side * side;
    static double Volume(double l, double w, double h) => l * w * h;
    static double Volume( double radius, double height,bool isCylinder) => Math.PI * radius * radius * height;

    //Task 5: Login with optional/named params
    static void Login(string username, string password = "1234", bool isAdmin = false)
    {
        string message = $"Welcome, {username}!";
        if (isAdmin)
        {
            message += " [ADMIN ACCESS]";
        }
        Console.WriteLine(message);
    }
    // Task 6: Get Statistics using out
    static void GetStatistics(
        int[] numbers,
        out int sum,
        out double average,
        out int min,
        out int max )
    {
        sum = 0;
        min = numbers[0];
        max = numbers[0];

        foreach (int num in numbers)
        {
            sum += num;
            if (num < min)
            {
                min = num;
            }
            if (num > max)
            {
                max = num;
            }
        }
        average = (double)sum / numbers.Length;
    }
    // Task 7: Calculate with ref + params
    static void Calculate(ref double result, string operation, params double[] numbers)
    {
        if(operation == "add")
        {
            result = 0;
            foreach (double num in numbers)
            {
                result += num;
            }
        }
        else if (operation == "multiply")
        {
            result =1;
            foreach (double num in numbers)
            {
                result *= num;
            }
        }
    }
    // Task 8: Calculate Area
    static double CalculateArea(double length, double width)
    {
       return length * width;
    }
    // Task 9:GetGrade
    static string GetGrade(int score)
    {
        if (score >= 70) return "A";
        if (score >= 60) return "B";
        if (score >= 50) return "C";
        if (score >= 40) return "D";
        return "F";  
    }
    // Task 10: Is Palindrome
    static bool IsPalindrome( string word)
    {
        string reversed = "";
        for (int i = word.Length -1; i >= 0; i--)
        {
            reversed += word[i];
        }
        return word.ToLower() == reversed.ToLower();
    }
    // Main Method
    static void Main(string[] args)
    {
        // Task 1: Overload describe Methods
        Console.WriteLine("Describe");
        Describe("femi");
        Describe("femi", 30);
        Describe("femi", 30, "Lagos");

        Console.WriteLine();

        //Task 2: Fix score using ref
        Console.WriteLine("Fixscore");

        int score1 = -5;
        int score2 = 110;
        int score3 = 75;

        Fixscore(ref score1);
        Fixscore(ref score2);
        Fixscore(ref score3);

        Console.WriteLine();

        // Task 3: FindHighest with params
        Console.WriteLine("FindHighest with params");
        int hightest = FindHighest(4, 10, 2, 50, 7);

        Console.WriteLine($"Hightest: {hightest}");
        Console.WriteLine();

        //Task 4: Overloaded Volume
        Console.WriteLine("Overloaded Volume");

        Console.WriteLine($"Cube Volume: {Volume(4)}");
        Console.WriteLine($"Box Volume: {Volume(2, 3, 4)}");
        Console.WriteLine($"Cylinder Volume: {Volume(3, 5, true)}");
        Console.WriteLine();

        //Task 5: Login with optional/named params
        Console.WriteLine("Login with optional/named params");
        Login("Debo");
        Login(username: "dolapo", isAdmin: true);
        Login(password: "5467", username: "opemipo");
        Console.WriteLine();
        
        // Task 6: Get Statistics using out
        Console.WriteLine("Get Statistics using out");
        int[] nums = { 10, 20, 30, 40, 50 };

        GetStatistics(nums, out int sum, out double avg, out int min, out int max);

        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Average: {avg}");
        Console.WriteLine($"Min: {min}");
        Console.WriteLine($"Max: {max}");
        Console.WriteLine();

        // Task 7: Calculate with ref + params
        Console.WriteLine("Calculate with ref + params");
        double result = 0;

        Calculate(ref result, "add", 2, 3, 4);
        Console.WriteLine($"Addition Result: {result}");

        Calculate(ref result, "multiply", 2, 3, 4);
        Console.WriteLine($"Multiplication Result: {result}");

        Calculate(ref result, "add", 10, 20);
        Console.WriteLine($"Addition Result 2: {result}");
        Console.WriteLine();

        // Task 8: Calculate Area
        Console.WriteLine("Calculate Area");

        Console.WriteLine(CalculateArea(5, 2));
        Console.WriteLine(CalculateArea(10, 4));
        Console.WriteLine(CalculateArea(7, 3));

        Console.WriteLine();

        // Task 9:GetGrade
        Console.WriteLine("GetGrade");

        Console.WriteLine(GetGrade(85));
        Console.WriteLine(GetGrade(65));
        Console.WriteLine(GetGrade(30));
        Console.WriteLine();

        //  Is Palindrome
        Console.WriteLine("Is Palindrome");

        Console.WriteLine(IsPalindrome("madam"));
        Console.WriteLine(IsPalindrome("racecar"));
        Console.WriteLine(IsPalindrome("hello"));
    }
}
