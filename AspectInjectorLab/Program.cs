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

        public async Task<int> AddAsync(int a, int b)
        {
            await Task.Delay(1);

            return a + b;
        }
    }

    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var result = await new TargetService().AddAsync(1, 2);

            Console.ReadKey();
        }
    }
}