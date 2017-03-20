using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignPatterns.Behavioral_patterns.Template_method
{
    abstract class Education
    {
        public void Learn()
        {
            Enter();
            Study();
            PassExams();
            GetDocument();
        }
        public abstract void Enter();
        public abstract void Study();
        public virtual void PassExams()
        {
            Console.WriteLine("We take final exams");
        }
        public abstract void GetDocument();
    }

    class School : Education
    {
        public override void Enter()
        {
            Console.WriteLine("We go to the first class");
        }

        public override void Study()
        {
            Console.WriteLine("Attending lessons, doing homework");
        }

        public override void GetDocument()
        {
            Console.WriteLine("We get the certificate of secondary education");
        }
    }

    class University : Education
    {
        public override void Enter()
        {
            Console.WriteLine("We take entrance exams and enter the university");
        }

        public override void Study()
        {
            Console.WriteLine("We attend lectures");
            Console.WriteLine("We pass practice");
        }

        public override void PassExams()
        {
            Console.WriteLine("We pass the exam in the specialty");
        }

        public override void GetDocument()
        {
            Console.WriteLine("We receive a diploma of higher education");
        }
    }
}
