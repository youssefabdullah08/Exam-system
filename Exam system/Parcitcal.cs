using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_system
{
    public class Parcitcal : Exam
    {
        public override void StartExam()
        {
            foreach (var question in Questions)
            {
                question.DisplayQuestion();
            }
        }
        public void ShowRightAnswers()
        {
            foreach (var question in Questions)
            {
                Console.WriteLine($"Correct Answer: {question.CorrectAnswer.AnswerText}");
            }
        }
        public Parcitcal(DateTime timeOfExam, int numberOfQuestions)
            :base(timeOfExam, numberOfQuestions) {}
    }
}
