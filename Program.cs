using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

class student
{
    public  int                  Id                { get; set; }
    public string                Name              { get; set; }
    public string                Department        { get; set; }
    public int                   Age               { get; set; }
    public List<int>            Grades            { get; set; }
    public List<string>          Courses           { get; set; }
    public double            Average => Grades.Average();
    public bool              passed => Average >= 50;

}

      // Flitering using Where
class program
{
    static void Main()
    {
       List<Student> students = new List<Student>
       {
          new Student
          {
               Id = 1,
               Name = "James",
               Department = " Science",
               Age = 20,
               Grades = new List<int>{70, 65, 80},
               Courses = new List<string>{ "Math", "physics"},
            },
            new Student
           {
                Id = 2,
                Name = "Amara",
                Department = " Art",
                Age = 21,
                Grades = new List<int>{40, 45, 50},
                Courses = new List<string>{ "literature", "History"},
            },
            new Student
            {
                Id = 3,
                Name = "Ngozi",
                Department = " Commercce",
                Age = 22,
                Grades = new List<int>{35, 40, 45},
                Courses = new List<string>{ "Accounting", "Economics"},
            },
            new Student
            {
                 Id = 4,
                 Name = "Mike",
                 Department = " Science",
                 Age = 19,
                 Grades = new List<int>{85, 90, 88},
                 Courses = new List<string>{ "Math", "physics"},
            }
        };
         //students who passed
        var passedStudents = students.Where(s => s.passed);
        Console.WriteLine("Students who passed:");
        foreach ( var student in passedStudents)
        {
            Console.WriteLine($"{student.Name}, Average: {student.Average: F2}");
        }
         // Science students whoses age is uder 22
         var ScienceStudents = students.Where(s => s.Department == "Science" && s.Age < 22);
         Console.WriteLine("\nScience Students Aged under 22: ");
         foreach ( var student in ScienceStudents)
        {
            Console.WriteLine($"{student.Name}, Age: {student.Age: }");
        }
        
        //Select
        var Summary = students.Select(s => new { s.Name, s.Average, s.status, pass >= 50});
        foreach (var student in Summary)
        {
            Console.WriteLine($"{student.Name}, {student.Average: F2}, {(student.pass ? "PASS" : "FAIL")}");
        }
        // Select many
        var allcourses = students.SelectMany(s => s.Courses);
         
         var uniquecourses =students
            .SelectMany(s => s.Courses)
            .Distinct();

            Console.WriteLine("All Unique Courses:");
            foreach (var Course in uniquecourses)
            {
                Console.WriteLine(course);
            }
            //count them
            int count = uniquecourses();
            Console.WriteLine($"\nTotal Unique Courses");

            //Ordering
            var byrankDecThenName = students
                .OrderByDescending(s => s.Average)
                .ThenBy(s => s.Name);
            
            Console.WriteLine("Student Ranking: \n");
            int rank = 1;
            foreach (var student in byrankDecThenName)
            {
               Console.WriteLine($"{rank}. {student.Name} - avg: {student.Average: F2}"); 
            }
            //Groupby
            var byDept = students
                .GroupBy(s => s.Department)
                .Select(g => new
                {
                     Department = g.Key,
                     Count      = g.Count(),
                     AverageGrade    = g.Average(s => s.Average),
                     PassRate    = g.Count(s => s.passed) * 100.0 / g.Count()
                });
            foreach (var dept in byDept)
            {
             Console.WriteLine($"{dept.Department}: {dept.Count} students, avg {dept.Average:F2}, {dept.PassRate:F2}");
            }
            //Aggregation
            int totalStudents = students.Count;
            double overallAverage = allGrades.Average();
            int highestGrade = allGrades.Max();
            int lowestGrade = allGrades.Min();
            int passCount = students.Count(s => s.Passed);
            int failCount = students.Count(s => !s.Passed);

            Console.Write("School-Wide Statistics:");
            Console.WriteLine($"Total Students: {totalStudents}, Overall Average Grade: {overallAverage:F2}");
            Console.WriteLine($"Highest Grade: {highestGrade}, Lowest Grade: {lowestGrade}");
            Console.WriteLine($"Pass Count: {passCount}, Fail Count: {failCount}");
            
            //partioning
            var top3 = students
                .OrderByDescending(s => s.Grade)
                .Take(3);

              Console.WriteLine("Top 3 Students:\n");
                foreach (var s in top3)
                  {
                      Console.WriteLine($"{s.Name} - {s.Average:F2}");
                  }
            // Bottom 3
            var bottom3 = students
                .OrderBy(s => s.Grade)
                .Take(3);
             foreach (var s in bottom3)
                 {
                     Console.WriteLine($"{s.Name} - {s.Average:F2}");
                 }
                 Console.WriteLine("Page 4: " + string.Join(", ", page4));

        string[] morningClass = { "James", "Amara", "Ngozi" };
        string[] eveningClass = { "Ngozi", "Mike", "James" }; 

            //Set operation   Students in both classes
            var both = morningClass.Intersect(eveningClass);
            Console.WriteLine("Students in Both Classes:");
             foreach (var student in both)
               {
                  Console.WriteLine(student);
               }
           
            // Students only in morning class
            var onlyMorning = morningClass.Except(eveningClass);
            Console.WriteLine("\nStudents Only in Morning Class:");
             foreach (var student in onlyMorning)
              {
                 Console.WriteLine(student);
              }
            
            // Students only in evening class
            var onlyEvening = eveningClass.Except(morningClass);
             Console.WriteLine("\nStudents Only in Evening Class:");
               foreach (var student in onlyEvening)
                {
                   Console.WriteLine(student);
                }

            // All unique students
            var allStudents = morningClass.Union(eveningClass);
            Console.WriteLine("\nAll Unique Students:");
             foreach (var student in allStudents)
              {
                 Console.WriteLine(student);
              }
        
        //Quantifiers
          List<Student> students = new List<Student>
        {
            new Student { Name = "James", Grades = new List<int>{70, 65, 80} },
            new Student { Name = "Amara", Grades = new List<int>{40, 45, 50} },
            new Student { Name = "Mike", Grades = new List<int>{85, 90, 100} },
            new Student { Name = "Ngozi", Grades = new List<int>{35, 40, 45} }
        };

        // Does any student have a perfect score (100)?
        bool hasPerfectScore = students.Any(s => s.Grades.Contains(100));

        // Do all students have at least one grade above 40?
        bool allAbove40 = students.All(s => s.Grades.Any(g => g > 40));   

        // Is student "Usman" in the list?
        bool hasUsman = students.Any(s => s.Name == "Usman");

        Console.WriteLine($"Any student with a score of 100? {hasPerfectScore}");
        Console.WriteLine($"Do all students have at least one grade above 40? {allAbove40}");
        Console.WriteLine($"Is Usman in the list? {hasUsman}");

        //Conversion
        List<Student> students = GetStudents();
          {
            new Student { Id = 1, Name = "James", Department = "Engineering", Grades = new List<int>{70,65,80} };
            new Student { Id = 2, Name = "Amara", Department = "Science", Grades = new List<int>{40,45,50} };
            new Student { Id = 3, Name = "Mike", Department = "Engineering", Grades = new List<int>{85, 90, 100} };
          }
          
        // Convert to Dictionary
        Dictionary<int, Student> studentDict = students.ToDictionary(s => s.Id);
        Console.WriteLine(studentDict[2].Name);
       
        //Build a lookup by Department
        ILookup<string, Student> byDept = students
            .ToLookup(s => s.Department);

        Console.WriteLine("\nEngineering Students:");

        foreach (var student in studentDict["Engineering"])
        {
            Console.WriteLine($"{student.Name} - Avg: {student.Average:F2}");
        }
          
    }
}

    
    

             

      
 