using System;
using System.Threading.Tasks;

namespace AspectInjectorLab
{
    [Logging]
    public class TargetService
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var result = new TargetService().Add(1, 2);

            Console.ReadKey();
        }
    }
}