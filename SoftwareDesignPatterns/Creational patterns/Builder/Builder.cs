using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignPatterns.Creational_patterns.Builder
{
    //Flour
    class Flour
    {
        // What kind of flour
        public string Sort { get; set; }
    }
    // Salt
    class Salt
    { }
    // nutritional supplements
    class Additives
    {
        public string Name { get; set; }
    }

    class Bread
    {
        // Wheat flour
        public Flour WheatFlour { get; set; }
        // Rye flour
        public Flour RyeFlour { get; set; }
        // Salt
        public Salt Salt { get; set; }
        // nutritional supplements
        public Additives Additives { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (WheatFlour != null)
                sb.Append("Wheat flour " + WheatFlour.Sort + "\n");
            if (RyeFlour != null)
                sb.Append("Rye flour " + RyeFlour.Sort + " \n");
            if (Salt != null)
                sb.Append("Salt \n");
            if (Additives != null)
                sb.Append("Additives: " + Additives.Name + " \n");
            return sb.ToString();
        }
    }

    // Abstract builder class
    abstract class BreadBuilder
    {
        public Bread Bread { get; private set; }
        public void CreateBread()
        {
            Bread = new Bread();
        }
        public abstract void SetWheatFlour();
        public abstract void SetRyeFlour();
        public abstract void SetSalt();
        public abstract void SetAdditives();
    }
    // baker
    class Baker
    {
        public Bread Bake(BreadBuilder breadBuilder)
        {
            breadBuilder.CreateBread();
            breadBuilder.SetWheatFlour();
            breadBuilder.SetRyeFlour();
            breadBuilder.SetSalt();
            breadBuilder.SetAdditives();
            return breadBuilder.Bread;
        }
    }
    // Builder for rye bread
    class RyeBreadBuilder : BreadBuilder
    {
        public override void SetWheatFlour()
        {
            // not used
        }

        public override void SetRyeFlour()
        {
            this.Bread.RyeFlour = new Flour { Sort = "1st grade" };
        }

        public override void SetSalt()
        {
            this.Bread.Salt = new Salt();
        }

        public override void SetAdditives()
        {
            // not used
        }
    }
    // Builder for wheat bread
    class WheatBreadBuilder : BreadBuilder
    {
        public override void SetWheatFlour()
        {
            this.Bread.WheatFlour = new Flour { Sort = "Top grade" };
        }

        public override void SetRyeFlour()
        {
            // not used
        }

        public override void SetSalt()
        {
            this.Bread.Salt = new Salt();
        }

        public override void SetAdditives()
        {
            this.Bread.Additives = new Additives { Name = "Bakery improver" };
        }
    }
}
