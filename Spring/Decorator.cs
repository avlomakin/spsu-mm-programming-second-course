using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            IIceCream iceCream = new VanillaIceCream();
            iceCream.Make();
            Console.WriteLine();

            iceCream = new CandyIceCream(iceCream);
            iceCream.Make();
            Console.WriteLine();

            iceCream = new ChocoIceCream(iceCream);
            iceCream.Make();
            Console.ReadLine();

        }
    }

    public interface IIceCream
    {
        void Make();
    }

    public class VanillaIceCream : IIceCream
    {
        public void Make()
        {
            Console.WriteLine("Vanilla ice cream");
        }
    }

    public abstract class IceCreamDecorator : IIceCream
    {
        protected IIceCream IceCream;

        protected IceCreamDecorator(IIceCream iceCream)
        {
            IceCream = iceCream;
        }

        public abstract void Make();
    }

    public class ChocoIceCream : IceCreamDecorator
    {
        public ChocoIceCream(IIceCream iceCream) : base(iceCream)
        {
        }

        public override void Make()
        {
            IceCream.Make();
            ChocoTopping();
        }

        private void ChocoTopping()
        {
            Console.WriteLine("With chocolate");
        }
    }

    public class CandyIceCream : IceCreamDecorator
    {
        public CandyIceCream(IIceCream iceCream) : base(iceCream)
        {
        }

        public override void Make()
        {
            IceCream.Make();
            CandyTopping();
        }

        private void CandyTopping()
        {
            Console.WriteLine("With candies");
        }
    }
}
