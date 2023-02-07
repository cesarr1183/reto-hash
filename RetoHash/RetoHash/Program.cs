using System;

namespace RetoHash
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reto Hash");
            Console.WriteLine($"String: abehinoprs --> {Hash("abehinoprs")}");
            Console.WriteLine($"Value: 289234665658930 --> {Unhash(289234665658930)}");
            Console.ReadKey();
        }

        static long Hash(string x)
        {
            if (string.IsNullOrWhiteSpace(x))
                throw new ArgumentNullException(nameof(x));

            if (x.Length != 10)
                throw new ArgumentException("The string must be 10 characters long");

            long seed = 47;
            string diccionario = "abehinoprstuvd";
            for (int i = 0; i < x.Length; i++)
            {
                seed = (seed * 19 + diccionario.IndexOf(x[i]));
            }

            return seed;
        }

        static string Unhash(long seed)
        {
            if (seed <= 0)
                throw new ArgumentException("Seed must be greater than 0.");

            string diccionario = "abehinoprstuvd";
            char[] result = new char[10];
            for (int i = 9; i >= 0; i--)
            {
                var index = (int)(seed % 19);
                //Console.WriteLine($"{seed} mod 19 -> {seed % 19}");
                seed = (seed / 19);
                if (seed < 47)
                    break;

                if (index > diccionario.Length)
                    break;

                result[i] = diccionario[index];
            }

            return new string(result);
        }
    }
}
