using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Ejercicio 10:");
        Console.WriteLine("Programa que muestra el precio mínimo y máximo de una lista de precios.\n");

        int[] prices = { 70, 95, 66, 42, 100, 85, 28 };

        int min = prices[0];
        int max = prices[0];

        foreach (int price in prices)
        {
            if (price < min)
                min = price;

            if (price > max)
                max = price;
        }

        Console.WriteLine("El precio mínimo es: " + min);
        Console.WriteLine("El precio máximo es: " + max);
    }
}
