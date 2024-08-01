// See https://aka.ms/new-console-template for more information
using Exam_system;
Console.WriteLine("enter sub name");
Subject math = new Subject(1, "math");

math.CreateExam();
Console.Clear();
math.ExamOfSubject.StartExam();
Console.Clear();
math.ExamOfSubject.TakeExam();
Console.Clear();
math.ExamOfSubject.ShowResults();