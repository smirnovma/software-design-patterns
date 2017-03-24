using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignPatterns.Behavioral_patterns.Chain_of_responsibility
{
    class ChainOfResponsibility
    {
        public class Receiver
        {
            // Bank transfers
            public bool BankTransfer { get; set; }
            // Money transfers - WesternUnion, Unistream
            public bool MoneyTransfer { get; set; }
            // PayPal transfer
            public bool PayPalTransfer { get; set; }
            public Receiver(bool bt, bool mt, bool ppt)
            {
                BankTransfer = bt;
                MoneyTransfer = mt;
                PayPalTransfer = ppt;
            }
        }
        public abstract class PaymentHandler
        {
            public PaymentHandler Successor { get; set; }
            public abstract void Handle(Receiver receiver);
        }

        public class BankPaymentHandler : PaymentHandler
        {
            public override void Handle(Receiver receiver)
            {
                if (receiver.BankTransfer == true)
                    Console.WriteLine("We provide bank transfer");
                else if (Successor != null)
                    Successor.Handle(receiver);
            }
        }

        public class PayPalPaymentHandler : PaymentHandler
        {
            public override void Handle(Receiver receiver)
            {
                if (receiver.PayPalTransfer == true)
                    Console.WriteLine("We provide transfer from PayPal");
                else if (Successor != null)
                    Successor.Handle(receiver);
            }
        }
        // Money transfers
        public class MoneyPaymentHandler : PaymentHandler
        {
            public override void Handle(Receiver receiver)
            {
                if (receiver.MoneyTransfer == true)
                    Console.WriteLine("We perform transfer through money transfer systems");
                else if (Successor != null)
                    Successor.Handle(receiver);
            }
        }
    }
}
