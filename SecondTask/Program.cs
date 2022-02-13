using System;

namespace SecondTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 2)
                {
                    var converter = new NumberConverter();

                    if (int.TryParse(args[0], out var number) && int.TryParse(args[1], out var @base))
                    {
                        Console.WriteLine(converter.Convert(number, @base));
                    }
                }
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}