using System;
using System.Linq;

namespace DecimalConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ulong decimalNumber = 0;

            while (decimalNumber == default)
            {
                try
                {
                    Console.Write("Podaj liczbę dziesiętną: ");
                    decimalNumber = ulong.Parse(Console.ReadLine().Replace("-", "")); // Ignoruje znak minusa aby uniknąć błędu

                    if (decimalNumber > ulong.MaxValue / 2)
                    {
                        TooBigNumber();
                        decimalNumber = 0;
                        continue;
                    }
                }
                catch (OverflowException) // Zabezpieczenie przed podaniem liczby większej od maksymalnej wielkości ulong (overflow)
                {
                    TooBigNumber();
                    continue;
                }
                catch
                {
                    continue;
                }
            }

            Console.WriteLine(ConvertDecimalNumberToBinary(decimalNumber));
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Wciśnij dowolny klawisz, aby zamknąć");
            Console.ReadKey();
        }

        static string ConvertDecimalNumberToBinary(ulong number)
        {
            ulong dividedNumber = number * 2; // Jest mnożona razy dwa ponieważ na starcie pętli jest dzielona przez 2, przez co brakuje jej jednego bitu
            string binaryNumber = String.Empty;

            while (dividedNumber / 2 != 0)
            {
                dividedNumber /= 2;
                binaryNumber += dividedNumber % 2;
            }

            return new string(binaryNumber.Reverse().ToArray<char>());
        }

        static void TooBigNumber()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Maksymalna liczba do obliczenia to: {0}", ulong.MaxValue / 2);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
