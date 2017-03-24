using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignPatterns.Behavioral_patterns.Mediator
{
    public abstract class Mediator
    {
        public abstract void Send(string msg, Colleague colleague);
    }
    public abstract class Colleague
    {
        protected Mediator mediator;

        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public virtual void Send(string message)
        {
            mediator.Send(message, this);
        }
        public abstract void Notify(string message);
    }
    // Class of customer
    public class CustomerColleague : Colleague
    {
        public CustomerColleague(Mediator mediator)
            : base(mediator)
        { }

        public override void Notify(string message)
        {
            Console.WriteLine("Message to the customer: " + message);
        }
    }
    // Class of programmer
    public class ProgrammerColleague : Colleague
    {
        public ProgrammerColleague(Mediator mediator)
            : base(mediator)
        { }

        public override void Notify(string message)
        {
            Console.WriteLine("Message to the programmer: " + message);
        }
    }
    // Class of tester
    public class TesterColleague : Colleague
    {
        public TesterColleague(Mediator mediator)
            : base(mediator)
        { }

        public override void Notify(string message)
        {
            Console.WriteLine("Message to the tester: " + message);
        }
    }

    public class ManagerMediator : Mediator
    {
        public Colleague Customer { get; set; }
        public Colleague Programmer { get; set; }
        public Colleague Tester { get; set; }
        public override void Send(string msg, Colleague colleague)
        {
            // If the sender is the customer, then there is a new order
            // Send a message to the programmer - execute the order
            if (Customer == colleague)
                Programmer.Notify(msg);
            // If the sender is a programmer, then you can start testing
            // We send a message to the tester
            else if (Programmer == colleague)
                Tester.Notify(msg);
            // If the sender is a tester, then the product is ready
            // Send the message to the customer
            else if (Tester == colleague)
                Customer.Notify(msg);
        }
    }
}
