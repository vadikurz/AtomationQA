using System;
using System.Text;

namespace SecondTask
{
    public class NumberConverter
    {
        public const int UpperLimit = 20;
        public const int LowerLimit = 2;
        private const string Digits = "0123456789ABCDEFGHIJ";

        public string Convert(int number, int toBase)
        {
            if (toBase is < LowerLimit or > UpperLimit)
            {
                throw new ArgumentOutOfRangeException(nameof(toBase),$"The value must be between {LowerLimit} and {UpperLimit}");
            }

            int absoluteValue = Math.Abs(number);
            StringBuilder convertedNumber = new StringBuilder();

            while (absoluteValue > 0)
            {
                convertedNumber.Insert(0, Digits[absoluteValue % toBase].ToString());
                absoluteValue /= toBase;
            }

            if (number < 0)
            {
                convertedNumber.Insert(0, "-");
            }

            return convertedNumber.ToString();
        }
    }
}