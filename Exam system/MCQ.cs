using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_system
{
    public class MCQ : Question
    {
        public override void DisplayQuestion()
        {
            Console.WriteLine($"{Header} : {Body}");
            foreach (var answer in AnswerList)
            {
                Console.WriteLine($"* {answer.AnswerText}");
            }
        }

        public MCQ(string header, string body, int mark)
       : base(header, body, mark) { }

    }
}
