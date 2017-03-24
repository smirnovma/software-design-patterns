using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignPatterns.Behavioral_patterns.Visitor
{
    interface IExpressionVisitor
    {
        void Visit(Literal literal);
        void Visit(Addition addition);
    }

    interface IExpression
    {
        void Accept(IExpressionVisitor visitor);
    }

    class Literal : IExpression
    {
        internal double Value { get; set; }

        public Literal(double value)
        {
            this.Value = value;
        }
        public void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    class Addition : IExpression
    {
        internal IExpression Left { get; set; }
        internal IExpression Right { get; set; }

        public Addition(IExpression left, IExpression right)
        {
            this.Left = left;
            this.Right = right;
        }

        public void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    class ExpressionPrinter : IExpressionVisitor
    {
        StringBuilder sb;

        public ExpressionPrinter(StringBuilder sb)
        {
            this.sb = sb;
        }

        public void Visit(Literal literal)
        {
            sb.Append(literal.Value);
        }

        public void Visit(Addition addition)
        {
            sb.Append("(");
            addition.Left.Accept(this);
            sb.Append("+");
            addition.Right.Accept(this);
            sb.Append(")");
        }
    }
}
