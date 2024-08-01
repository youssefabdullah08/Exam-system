using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_system
{
    public class TrueOrFalse : Question
    {
        public TrueOrFalse(string header, string body, int mark)
            : base(header, body, mark) { }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"{Header} : {Body} (1 for True/ 2 for False) ");
        }
    }
}
