using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_system
{
    public abstract class Exam
    {
        public DateTime TimeOfExam { get; set; }
        public int NumberOfQuestions { get; set; }
        public List<Question> Questions { get; set; }

        public abstract void StartExam();
        public Exam(DateTime timeOfExam, int numberOfQuestions)
        {
            TimeOfExam = timeOfExam;
            NumberOfQuestions = numberOfQuestions;
            Questions = new List<Question>();
        }


        public void TakeExam()
        {
            for (int i = 0; i < Questions.Count; i++)
            {
                Question? question = Questions[i];
                question.DisplayQuestion();
                Console.WriteLine("Enter your answer:");
                string userAnswer = Console.ReadLine();

                if (question is TrueOrFalse)
                {
                    int answerIndex = (userAnswer == "1") ? 0 : 1;
                    question.CorrectAnswer = question.AnswerList[answerIndex];
                }
                else if (question is MCQ)
                {
                    int answerIndex = int.Parse(userAnswer) - 1;
                    question.CorrectAnswer = question.AnswerList[answerIndex];
                }
            }
        }


        public void ShowResults()
        {
            int totalMarks = 0;
            int obtainedMarks = 0;

            for (int i = 0; i < Questions.Count; i++)
            {
                Question? question = Questions[i];
                totalMarks += question.Mark;
                Console.WriteLine($"{question.Header} - Correct Answer: {question.CorrectAnswer.AnswerText}");
                string userAnswer = question.CorrectAnswer.AnswerText  ;

                if (question is TrueOrFalse)
                {
                    
                    int answerIndex = (userAnswer.ToLower() == "true") ? 0 : 1;
                    if (question.AnswerList[answerIndex].AnswerText == question.CorrectAnswer.AnswerText)
                    {
                        obtainedMarks += question.Mark;
                    }
                }
                else if (question is MCQ)
                {
                    int answerIndex = int.Parse(userAnswer) - 1;
                    if (question.AnswerList[answerIndex].AnswerText == question.CorrectAnswer.AnswerText)
                    {
                        obtainedMarks += question.Mark;
                    }
                }
            }

            Console.WriteLine($"Your Score: {obtainedMarks} / {totalMarks}");
        }
    }
}
