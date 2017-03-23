using SoftwareDesignPatterns.Behavioral_patterns.Command;
using SoftwareDesignPatterns.Behavioral_patterns.Iterator;
using SoftwareDesignPatterns.Behavioral_patterns.Observer;
using SoftwareDesignPatterns.Behavioral_patterns.State;
using SoftwareDesignPatterns.Behavioral_patterns.Strategy;
using SoftwareDesignPatterns.Behavioral_patterns.Template_method;
using SoftwareDesignPatterns.Creational_patterns.Abstract_factory;
using SoftwareDesignPatterns.Creational_patterns.Builder;
using SoftwareDesignPatterns.Creational_patterns.Factory_method;
using SoftwareDesignPatterns.Creational_patterns.Prototype;
using SoftwareDesignPatterns.Creational_patterns.Singleton;
using SoftwareDesignPatterns.Structural_patterns.Adapter;
using SoftwareDesignPatterns.Structural_patterns.Composite;
using SoftwareDesignPatterns.Structural_patterns.Decorator;
using SoftwareDesignPatterns.Structural_patterns.Facade;
using SoftwareDesignPatterns.Structural_patterns.Flyweight;
using SoftwareDesignPatterns.Structural_patterns.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static SoftwareDesignPatterns.Structural_patterns.Bridge.Bridge;

namespace SoftwareDesignPatterns
{
    class Program
    {
        static void Main()
        {
            int variant;
            do
            {
                Console.Write(@"
***Creational patterns***
1.Abstract factory
2.Builder
3.Factory method
4.Prototype
5.Singleton

***Structural patterns***
6.Adapter
7.Bridge
8.Composite
9.Decorator
10.Facade
11.Flyweight
12.Proxy

***Behavioral patterns***
13.Chain of responsibility
14.Command
15.Interpreter
16.Iterator
17.Mediator
18.Memento
19.Observer
20.State
21.Strategy
22.Template method
23.Visitor

0.Exit

Select a pattern: ");
                variant = int.Parse(Console.ReadLine());
                switch (variant)
                {
                    case 1:
                        #region Abstract factory
                        /*
                         Provide an interface for creating families of related or dependent objects without specifying their concrete classes.
                         */
                        AbstractFactory abstractFactory = new AbstractFactory();
                        IGUIFactory specificFactory = abstractFactory.GetFactory(Settings.Win);
                        IButton button = specificFactory.CreateButton();
                        Console.WriteLine(button.Paint());
                        Console.ReadLine();
                        #endregion
                        break;
                    case 2:
                        #region Builder
                        /*
                        Separate the construction of a complex object from its representation, allowing the same construction process to create various representations.
                        */
                        // Create a baker's object
                        Baker baker = new Baker();
                        // Create a burger for rye bread
                        BreadBuilder builder = new RyeBreadBuilder();
                        // Bake
                        Bread ryeBread = baker.Bake(builder);
                        Console.WriteLine(ryeBread.ToString());
                        // Create a breadbreader
                        builder = new WheatBreadBuilder();
                        Bread wheatBread = baker.Bake(builder);
                        Console.WriteLine(wheatBread.ToString());

                        Console.ReadLine();
                        #endregion
                        break;
                    case 3:
                        #region Factory method
                        /*
                         Define an interface for creating a single object, but let subclasses decide which class to instantiate. 
                         Factory Method lets a class defer instantiation to subclasses (dependency injection).
                         */
                        Factory factory = new Factory();
                        IPerson person = factory.GetPerson(PersonType.Rural);
                        Console.WriteLine(person.GetName());
                        Console.ReadLine();
                        #endregion
                        break;
                    case 4:
                        #region Prototype
                        /*
                        Specify the kinds of objects to create using a prototypical instance, and create new objects from the 'skeleton' of an existing object, thus boosting performance and keeping memory footprints to a minimum.
                        */
                        IFigure figure = new Rectangle(30, 40);
                        IFigure clonedFigure = figure.Clone();
                        figure.GetInfo();
                        clonedFigure.GetInfo();

                        figure = new Circle(30);
                        clonedFigure = figure.Clone();
                        figure.GetInfo();
                        clonedFigure.GetInfo();

                        Console.ReadLine();
                        #endregion
                        break;
                    case 5:
                        #region Singleton
                        /*
                         Ensure a class has only one instance, and provide a global point of access to it.
                         */
                        Singleton obj1 = Singleton.getInstance();
                        Singleton obj2 = Singleton.getInstance();
                        Console.WriteLine("Singleton objects are identical: " + (obj1 == obj2 ? true : false));
                        Console.ReadLine();

                        SingletonThreadSafe obj3 = null;
                        var task = Task.Run(
                            () =>
                            {
                                obj3 = SingletonThreadSafe.getInstance();
                            });
                        task.Wait();
                        SingletonThreadSafe obj4 = SingletonThreadSafe.getInstance();
                        Console.WriteLine("SingletonThreadSafe objects are identical: " + (obj3 == obj4 ? true : false));
                        Console.ReadLine();
                        #endregion
                        break;
                    case 6:
                        #region Adapter
                        /*
                         Convert the interface of a class into another interface clients expect. 
                         An adapter lets classes work together that could not otherwise because of incompatible interfaces. 
                         The enterprise integration pattern equivalent is the translator.
                         */
                        // traveler
                        Structural_patterns.Adapter.Driver driver = new Structural_patterns.Adapter.Driver();
                        // Car
                        Auto auto = new Auto();
                        // Go on a trip
                        driver.Travel(auto);
                        // Met sands, you need to use a camel
                        Camel camel = new Camel();
                        // Use the adapter
                        ITransport camelTransport = new CamelToTransportAdapter(camel);
                        // Continue the way through the desert sand
                        driver.Travel(camelTransport);
                        Console.ReadLine();
                        #endregion
                        break;
                    case 7:
                        #region Bridge
                        /*
                        Decouple an abstraction from its implementation allowing the two to vary independently.
                        */
                        // Create a new programmer, it works with C++
                        Structural_patterns.Bridge.Bridge.Programmer freelancer = new FreelanceProgrammer(new CPPLanguage());
                        freelancer.DoWork();
                        freelancer.EarnMoney();
                        // Came a new order, but now I need C#
                        freelancer.Language = new CSharpLanguage();
                        freelancer.DoWork();
                        freelancer.EarnMoney();
                        Console.ReadLine();
                        #endregion
                        break;
                    case 8:
                        #region Composite
                        /*
                        Compose objects into tree structures to represent part-whole hierarchies. 
                        Composite lets clients treat individual objects and compositions of objects uniformly.
                        */
                        Component fileSystem = new Directory("File system");
                        // Define a new disk
                        Component diskC = new Directory("Drive C");
                        // New files
                        Component pngFile = new File("12345.png");
                        Component docxFile = new File("Document.docx");
                        // Add files to disk C
                        diskC.Add(pngFile);
                        diskC.Add(docxFile);
                        // Add disk C to the file system
                        fileSystem.Add(diskC);
                        // Output all data
                        fileSystem.Print();
                        Console.WriteLine();
                        // Remove from disk C file
                        diskC.Remove(pngFile);
                        // Create a new folder
                        Component docsFolder = new Directory("My Documents");
                        // Add files to it
                        Component txtFile = new File("readme.txt");
                        Component csFile = new File("Program.cs");
                        docsFolder.Add(txtFile);
                        docsFolder.Add(csFile);
                        diskC.Add(docsFolder);
                        fileSystem.Print();
                        Console.ReadLine();
                        #endregion
                        break;
                    case 9:
                        #region Decorator
                        /*
                        Attach additional responsibilities to an object dynamically keeping the same interface. 
                        Decorators provide a flexible alternative to subclassing for extending functionality.
                        */
                        Pizza pizza1 = new ItalianPizza();
                        pizza1 = new TomatoPizza(pizza1); // Italian pizza with tomatoes
                        Console.WriteLine("Name: {0}", pizza1.Name);
                        Console.WriteLine("Price: {0}", pizza1.GetCost());

                        Pizza pizza2 = new ItalianPizza();
                        pizza2 = new CheesePizza(pizza2);// Italian pizza with cheese
                        Console.WriteLine("Name: {0}", pizza2.Name);
                        Console.WriteLine("Price: {0}", pizza2.GetCost());

                        Pizza pizza3 = new BulgerianPizza();
                        pizza3 = new TomatoPizza(pizza3);
                        pizza3 = new CheesePizza(pizza3);// Bulgarian pizza with tomatoes and cheese
                        Console.WriteLine("Name: {0}", pizza3.Name);
                        Console.WriteLine("Price: {0}", pizza3.GetCost());
                        Console.ReadLine();
                        #endregion
                        break;
                    case 10:
                        #region Facade
                        /*
                        Provide a unified interface to a set of interfaces in a subsystem. 
                        Facade defines a higher-level interface that makes the subsystem easier to use.
                        */
                        TextEditor textEditor = new TextEditor();
                        Compiller compiller = new Compiller();
                        CLR clr = new CLR();

                        VisualStudioFacade ide = new VisualStudioFacade(textEditor, compiller, clr);

                        Structural_patterns.Facade.Programmer programmer = new Structural_patterns.Facade.Programmer();
                        programmer.CreateApplication(ide);

                        Console.ReadLine();
                        #endregion
                        break;
                    case 11:
                        #region Flyweight
                        /*
                        Use sharing to support large numbers of similar objects efficiently.
                        */
                        double longitude = 37.61;
                        double latitude = 55.74;

                        HouseFactory houseFactory = new HouseFactory();
                        for (int i = 0; i < 5; i++)
                        {
                            House panelHouse = houseFactory.GetHouse("Panel");
                            if (panelHouse != null)
                                panelHouse.Build(longitude, latitude);
                            longitude += 0.1;
                            latitude += 0.1;
                        }

                        for (int i = 0; i < 5; i++)
                        {
                            House brickHouse = houseFactory.GetHouse("Brick");
                            if (brickHouse != null)
                                brickHouse.Build(longitude, latitude);
                            longitude += 0.1;
                            latitude += 0.1;
                        }

                        Console.ReadLine();
                        #endregion
                        break;
                    case 12:
                        #region Proxy
                        /*
                        Provide a surrogate or placeholder for another object to control access to it.
                        */
                        ICar car = new ProxyCar(new Structural_patterns.Proxy.Driver(16));
                        car.DriveCar();

                        car = new ProxyCar(new Structural_patterns.Proxy.Driver(25));
                        car.DriveCar();
                        #endregion
                        break;
                    case 13:

                        break;
                    case 14:
                        #region Command
                        /*
                        Encapsulate a request as an object, thereby allowing for the parameterization of clients with different requests, and the queuing or logging of requests. 
                        It also allows for the support of undoable operations.
                        */
                        TVRemote tvRemote = new TVRemote();
                        TV tv = new TV();
                        tvRemote.SetCommand(new TVOnCommand(tv));
                        tvRemote.PressButton();
                        tvRemote.PressUndo();

                        Console.ReadLine();
                        #endregion
                        break;
                    case 15:

                        break;
                    case 16:
                        #region Iterator
                        /*
                        Provide a way to access the elements of an aggregate object sequentially without exposing its underlying representation.
                        */
                        Library library = new Library();
                        Reader reader = new Reader();
                        reader.SeeBooks(library);
                        Console.ReadLine();
                        #endregion
                        break;
                    case 17:

                        break;
                    case 18:

                        break;
                    case 19:
                        #region Observer
                        /*
                        Define a one-to-many dependency between objects where a state change in one object results in all its dependents being notified and updated automatically.
                        */
                        Stock stock = new Stock();
                        Bank bank = new Bank("Bank of America", stock);
                        Broker broker = new Broker("Jack Smith", stock);
                        // Imitation of trades
                        stock.Market();
                        // The broker stops watching the bidding
                        broker.StopTrade();
                        // Imitation of trades
                        stock.Market();

                        Console.ReadLine();
                        #endregion
                        break;
                    case 20:
                        #region State
                        /*
                        Allow an object to alter its behavior when its internal state changes. The object will appear to change its class.
                        */
                        Water water = new Water(new LiquidWaterState());
                        water.Heat();
                        water.Frost();
                        water.Frost();

                        Console.ReadLine();
                        #endregion
                        break;
                    case 21:
                        #region Strategy
                        /*
                         Define a family of algorithms, encapsulate each one, and make them interchangeable. 
                         Strategy lets the algorithm vary independently from clients that use it.
                         */

                        CalculateClient client = new CalculateClient(new Minus());
                        Console.WriteLine("Minus: " + client.Calculate(7, 1));
                        //Change the strategy
                        client.Strategy = new Plus();
                        Console.WriteLine("Plus: " + client.Calculate(7, 1));
                        Console.ReadLine();
                        #endregion
                        break;
                    case 22:
                        #region Template method
                        /*
                        Define the skeleton of an algorithm in an operation, deferring some steps to subclasses. 
                        Template method lets subclasses redefine certain steps of an algorithm without changing the algorithm's structure.
                        */
                        School school = new School();
                        University university = new University();

                        school.Learn();
                        university.Learn();

                        Console.ReadLine();
                        #endregion
                        break;
                    case 23:

                        break;
                    default:
                        Console.WriteLine("Incorrect value selected");
                        break;

                }
            } while (variant != 0);
        }
    }
}
