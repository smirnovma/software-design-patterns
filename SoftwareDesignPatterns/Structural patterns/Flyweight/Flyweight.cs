using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignPatterns.Structural_patterns.Flyweight
{
    abstract class House
    {
        protected int stages; // number of floors

        public abstract void Build(double longitude, double latitude);
    }

    class PanelHouse : House
    {
        public PanelHouse()
        {
            stages = 16;
        }

        public override void Build(double longitude, double latitude)
        {
            Console.WriteLine("A panel house of 16 floors has been built; Coordinates: {0} latitude and {1} longitude",
                latitude, longitude);
        }
    }
    class BrickHouse : House
    {
        public BrickHouse()
        {
            stages = 5;
        }

        public override void Build(double longitude, double latitude)
        {
            Console.WriteLine("Built brick house of 5 floors; Coordinates: {0} latitude and {1} longitude",
                latitude, longitude);
        }
    }

    class HouseFactory
    {
        Dictionary<string, House> houses = new Dictionary<string, House>();
        public HouseFactory()
        {
            houses.Add("Panel", new PanelHouse());
            houses.Add("Brick", new BrickHouse());
        }

        public House GetHouse(string key)
        {
            if (houses.ContainsKey(key))
                return houses[key];
            else
                return null;
        }
    }
}
