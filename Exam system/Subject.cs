using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_system
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam ExamOfSubject { get; set; }

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }


         public void CreateExam()
        {
            Console.WriteLine("Enter the number of questions:");
            int numberOfQuestions = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the type of exam (1 for FinalExam, 2 for PracticalExam):");
            int examType = int.Parse(Console.ReadLine());

            if (examType == 1)
            {
                ExamOfSubject = new Final(DateTime.Now, numberOfQuestions);
            }
            else if (examType == 2)
            {
                ExamOfSubject = new Parcitcal(DateTime.Now, numberOfQuestions);
            }
            else
            {
                Console.WriteLine("Invalid exam type.");
                return;
            }

            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.WriteLine($"Enter details for question {i + 1}:");

                if (ExamOfSubject is Final)
                {
                    Console.WriteLine("Enter question type (1 for TrueOrFalse, 2 for MCQ):");
                    int questionType = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter question header:");
                    string header = Console.ReadLine();

                    Console.WriteLine("Enter question body:");
                    string body = Console.ReadLine();

                    Console.WriteLine("Enter question mark:");
                    int mark = int.Parse(Console.ReadLine());

                    Question question;
                    if (questionType == 1)
                    {
                        question = new TrueOrFalse(header, body, mark);
                        question.AnswerList.Add(new Answer(1, "True"));
                        question.AnswerList.Add(new Answer(2, "False"));
                        Console.WriteLine("Enter correct answer (1 for True, 2 for False):");
                        int correctAnswer = int.Parse(Console.ReadLine());
                        question.CorrectAnswer = question.AnswerList[correctAnswer - 1];
                    }
                    else if (questionType == 2)
                    {
                        question = new MCQ(header, body, mark);
                        Console.WriteLine("Enter number of answers:");
                        int numberOfAnswers = int.Parse(Console.ReadLine());

                        for (int j = 0; j < numberOfAnswers; j++)
                        {
                            Console.WriteLine($"Enter text for answer {j + 1}:");
                            string answerText = Console.ReadLine();
                            question.AnswerList.Add(new Answer(j + 1, answerText));
                        }

                        Console.WriteLine("Enter the correct answer number:");
                        int correctAnswer = int.Parse(Console.ReadLine());
                        question.CorrectAnswer = question.AnswerList[correctAnswer - 1];
                    }
                    else
                    {
                        Console.WriteLine("Invalid question type.");
                        i--;
                        continue;
                    }

                    ExamOfSubject.Questions.Add(question);
                }
                else if (ExamOfSubject is Parcitcal)
                {
                    Console.WriteLine("Enter question header:");
                    string header = Console.ReadLine();

                    Console.WriteLine("Enter question body:");
                    string body = Console.ReadLine();

                    Console.WriteLine("Enter question mark:");
                    int mark = int.Parse(Console.ReadLine());

                    Question question = new MCQ(header, body, mark);
                    Console.WriteLine("Enter number of answers:");
                    int numberOfAnswers = int.Parse(Console.ReadLine());

                    for (int j = 0; j < numberOfAnswers; j++)
                    {
                        Console.WriteLine($"Enter text for answer {j + 1}:");
                        string answerText = Console.ReadLine();
                        question.AnswerList.Add(new Answer(j + 1, answerText));
                    }

                    Console.WriteLine("Enter the correct answer number:");
                    int correctAnswer = int.Parse(Console.ReadLine());
                    question.CorrectAnswer = question.AnswerList[correctAnswer - 1];

                    ExamOfSubject.Questions.Add(question);
                }
            }
        }

        public override string ToString()
        {
            return $"{SubjectName} (id: {SubjectId})";
        }
    }
}
