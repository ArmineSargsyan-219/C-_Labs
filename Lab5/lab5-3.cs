using System;
using System.Collections.Generic;

public class Student
{
    public string Name { get; }
    public int Age { get; }

    public Student(string name, int age)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name));
        if (age < 18)
            throw new ArgumentOutOfRangeException(nameof(age));

        Name = name;
        Age = age;
    }
}

public class Course
{
    public string Title { get; }
    public int Credits { get; }

    public Course(string title, int credits)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentNullException(nameof(title));
        if (credits < 1 || credits > 15)
            throw new ArgumentOutOfRangeException(nameof(credits));

        Title = title;
        Credits = credits;
    }
}

public class Enrollment
{
    public Student EnrolledStudent { get; }
    public Course EnrolledCourse { get; }
    public DateTime EnrolledAt { get; }  

    public Enrollment(Student student, Course course)
    {
        EnrolledStudent = student ?? throw new ArgumentNullException(nameof(student));
        EnrolledCourse = course ?? throw new ArgumentNullException(nameof(course));
        EnrolledAt = DateTime.Now;
    }
}

class Program
{
    static void Main()
    {
        var student1 = new Student("Alice", 20);
        var student2 = new Student("Bob", 22);

        var course1 = new Course("Math", 3);
        var course2 = new Course("History", 4);

        var enrollments = new List<Enrollment>
        {
            new Enrollment(student1, course1),
            new Enrollment(student1, course2),
            new Enrollment(student2, course1)
        };

        foreach (var e in enrollments)
        {
            Console.WriteLine($"{e.EnrolledStudent.Name} ({e.EnrolledStudent.Age} yrs) enrolled in {e.EnrolledCourse.Title} ({e.EnrolledCourse.Credits} credits) at {e.EnrolledAt}");
        }
    }
}
