using System;

namespace RownanieKwadratowe
{
    public class Program
    {
        public static (double?, double?) ObliczPierwiastki(double a, double b, double c)
        {
            if (a == 0)
            throw new ArgumentException("Współczynnik 'a' nie może być równy zero w równaniu kwadratowym.");
            double delta = b * b - 4 * a * c;
            
            if (delta < 0) return (null, null); // brak pierwiastków
            if (delta == 0) return (-b / (2 * a), null); // jeden pierwiastek
            
            double pierwiastek1 = (-b + Math.Sqrt(delta)) / (2 * a);
            double pierwiastek2 = (-b - Math.Sqrt(delta)) / (2 * a);
            
            return (pierwiastek1, pierwiastek2); // dwa pierwiastki
        }

        static void Main(string[] args)
        {
            var (pierwiastek1, pierwiastek2) = ObliczPierwiastki(1, -3, 2);
            Console.WriteLine($"Pierwiastki: {pierwiastek1}, {pierwiastek2}");
        }
    }
}
