using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_system
{
    public class Final : Exam
    {
        public Final(DateTime timeOfExam, int numberOfQuestions)
            : base(timeOfExam, numberOfQuestions) { }

        public override void StartExam()
        {
            foreach (var question in Questions)
            {
                question.DisplayQuestion();

            }
        }

        public void ShowGrade()
        {
            int x = 0;
            foreach (var question in Questions)
            {
                x += question.Mark;
            }
            Console.WriteLine($"Total Grade *{x}*");
        }
    }
}
