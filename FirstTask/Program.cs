using System;

namespace FirstTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                if (args.Length == 1)
                {
                    Console.WriteLine(args[0].MaxCountOfUniqueSequentialCharacters());
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}
