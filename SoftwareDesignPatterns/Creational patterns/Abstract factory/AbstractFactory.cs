using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignPatterns.Creational_patterns.Abstract_factory
{
    public interface IButton
    {
        string Paint();
    }

    public interface IGUIFactory
    {
        IButton CreateButton();
    }

    class WinFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new WinButton();
        }
    }

    class OSXFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new OSXButton();
        }
    }

    class WinButton : IButton
    {
        public string Paint()
        {
            return "WinButton has painted";
        }
    }

    class OSXButton : IButton
    {
        public string Paint()
        {
            return "OSXButton has painted";
        }
    }

    public enum Settings
    {
        Win,
        OSX
    }

    public class AbstractFactory
    {
        public IGUIFactory GetFactory(Settings settings)
        {
            IGUIFactory factory;
            switch (settings)
            {
                case Settings.Win:
                    factory = new WinFactory();
                    break;
                case Settings.OSX:
                    factory = new OSXFactory();
                    break;
                default:
                    throw new NotImplementedException();
            }
            return factory;
        }
    }
}
