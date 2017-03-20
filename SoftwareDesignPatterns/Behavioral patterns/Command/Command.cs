using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignPatterns.Behavioral_patterns.Command
{
    interface ICommand
    {
        void Execute();
        void Undo();
    }

    // Receiver
    class TV
    {
        public void On()
        {
            Console.WriteLine("TV on!");
        }

        public void Off()
        {
            Console.WriteLine("TV off ...");
        }
    }

    class TVOnCommand : ICommand
    {
        TV tv;
        public TVOnCommand(TV tvSet)
        {
            tv = tvSet;
        }
        public void Execute()
        {
            tv.On();
        }
        public void Undo()
        {
            tv.Off();
        }
    }

    // Invoker
    class TVRemote
    {
        ICommand command;

        public TVRemote() { }

        public void SetCommand(ICommand com)
        {
            command = com;
        }

        public void PressButton()
        {
            command.Execute();
        }
        public void PressUndo()
        {
            command.Undo();
        }
    }
}
