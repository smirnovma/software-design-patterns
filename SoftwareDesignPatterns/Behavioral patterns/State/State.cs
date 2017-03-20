using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignPatterns.Behavioral_patterns.State
{
    class Water
    {
        public IWaterState State { get; set; }

        public Water(IWaterState ws)
        {
            State = ws;
        }

        public void Heat()
        {
            State.Heat(this);
        }
        public void Frost()
        {
            State.Frost(this);
        }
    }

    interface IWaterState
    {
        void Heat(Water water);
        void Frost(Water water);
    }

    class SolidWaterState : IWaterState
    {
        public void Heat(Water water)
        {
            Console.WriteLine("Transforming ice into liquid");
            water.State = new LiquidWaterState();
        }

        public void Frost(Water water)
        {
            Console.WriteLine("We continue to freeze the ice");
        }
    }
    class LiquidWaterState : IWaterState
    {
        public void Heat(Water water)
        {
            Console.WriteLine("We transform the liquid into vapor");
            water.State = new GasWaterState();
        }

        public void Frost(Water water)
        {
            Console.WriteLine("Transforming liquid into ice");
            water.State = new SolidWaterState();
        }
    }
    class GasWaterState : IWaterState
    {
        public void Heat(Water water)
        {
            Console.WriteLine("Raise the temperature of water vapor");
        }

        public void Frost(Water water)
        {
            Console.WriteLine("Convert water vapor to liquid");
            water.State = new LiquidWaterState();
        }
    }
}
