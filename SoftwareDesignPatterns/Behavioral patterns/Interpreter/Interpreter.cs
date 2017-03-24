using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignPatterns.Behavioral_patterns.Interpreter
{
    // "Context"
    class Context
    {
    }

    // "AbstractExpression"
    abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }

    // "TerminalExpression"
    class TerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("Called Terminal.Interpret()");
        }
    }

    // "NonterminalExpression"
    class NonterminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("Called Nonterminal.Interpret()");
        }
    }
}
