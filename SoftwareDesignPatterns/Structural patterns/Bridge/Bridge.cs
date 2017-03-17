using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignPatterns.Structural_patterns.Bridge
{
    class Bridge
    {
        public interface ILanguage
        {
            void Build();
            void Execute();
        }

        public class CPPLanguage : ILanguage
        {
            public void Build()
            {
                Console.WriteLine("Using the C ++ compiler, we compile the program into binary code");
            }

            public void Execute()
            {
                Console.WriteLine("Run the executable file of the program");
            }
        }

        public class CSharpLanguage : ILanguage
        {
            public void Build()
            {
                Console.WriteLine("Using the Roslyn compiler, we compile the source code into an exe file");
            }

            public void Execute()
            {
                Console.WriteLine("JIT compiles the program into binary code");
                Console.WriteLine("The CLR executes the compiled binary code");
            }
        }

        public abstract class Programmer
        {
            protected ILanguage language;
            public ILanguage Language
            {
                set { language = value; }
            }
            public Programmer(ILanguage lang)
            {
                language = lang;
            }
            public virtual void DoWork()
            {
                language.Build();
                language.Execute();
            }
            public abstract void EarnMoney();
        }

        public class FreelanceProgrammer : Programmer
        {
            public FreelanceProgrammer(ILanguage lang) : base(lang)
            {
            }
            public override void EarnMoney()
            {
                Console.WriteLine("We receive payment for the executed order");
            }
        }
        class CorporateProgrammer : Programmer
        {
            public CorporateProgrammer(ILanguage lang)
                : base(lang)
            {
            }
            public override void EarnMoney()
            {
                Console.WriteLine("We get a salary at the end of the month");
            }
        }
    }
}
