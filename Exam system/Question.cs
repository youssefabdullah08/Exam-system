using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_system
{

    public abstract class  Question : ICloneable,IComparable<Question>
    {

        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public List<Answer> AnswerList { get; set; }
        public Answer CorrectAnswer { get; set; }

        public Question(string header, string body, int mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = new List<Answer>();
        }

        public abstract void DisplayQuestion();
        public object Clone()
        {
            return this.MemberwiseClone();  
        }

        public int CompareTo(Question? other)
        {
            return this.Mark.CompareTo(other?.Mark);
        }

        public override string ToString()
        {
            return $"{Header}: {Body} (Mark: {Mark})";
        }
    }
}
