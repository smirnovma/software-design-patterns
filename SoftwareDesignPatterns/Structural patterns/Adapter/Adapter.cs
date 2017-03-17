using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignPatterns.Structural_patterns.Adapter
{
    interface ITransport
    {
        void Drive();
    }
    // class of a car
    class Auto : ITransport
    {
        public void Drive()
        {
            Console.WriteLine("The car is on the road");
        }
    }
    class Driver
    {
        public void Travel(ITransport transport)
        {
            transport.Drive();
        }
    }
    // interface of animal
    interface IAnimal
    {
        void Move();
    }
    // class of a camel
    class Camel : IAnimal
    {
        public void Move()
        {
            Console.WriteLine("A camel walks through the desert sand");
        }
    }
    // Adapter from Camel to ITransport
    class CamelToTransportAdapter : ITransport
    {
        Camel camel;
        public CamelToTransportAdapter(Camel c)
        {
            camel = c;
        }

        public void Drive()
        {
            camel.Move();
        }
    }
}
