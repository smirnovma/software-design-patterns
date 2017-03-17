using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignPatterns.Structural_patterns.Facade
{
    // text editor
    public class TextEditor
    {
        public void CreateCode()
        {
            Console.WriteLine("Writing code");
        }
        public void Save()
        {
            Console.WriteLine("Saving code");
        }
    }
    class Compiller
    {
        public void Compile()
        {
            Console.WriteLine("Compiling the application");
        }
    }
    class CLR
    {
        public void Execute()
        {
            Console.WriteLine("Running the application");
        }
        public void Finish()
        {
            Console.WriteLine("Shutdown the application");
        }
    }

    class VisualStudioFacade
    {
        TextEditor textEditor;
        Compiller compiller;
        CLR clr;
        public VisualStudioFacade(TextEditor te, Compiller compil, CLR clr)
        {
            this.textEditor = te;
            this.compiller = compil;
            this.clr = clr;
        }
        public void Start()
        {
            textEditor.CreateCode();
            textEditor.Save();
            compiller.Compile();
            clr.Execute();
        }
        public void Stop()
        {
            clr.Finish();
        }
    }

    class Programmer
    {
        public void CreateApplication(VisualStudioFacade facade)
        {
            facade.Start();
            facade.Stop();
        }
    }
}
