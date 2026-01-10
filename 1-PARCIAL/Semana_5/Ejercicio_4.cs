using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Ejercicio 4:");
        Console.WriteLine("Programa que pide los números ganadores de la lotería y los muestra ordenados de menor a mayor.\n");

        List<int> awarded = new List<int>();

        for (int i = 1; i <= 6; i++)
        {
            Console.Write("Introduce el número ganador " + i + ": ");
            int number = int.Parse(Console.ReadLine());
            awarded.Add(number);
        }

        awarded.Sort();

        Console.WriteLine("\nLos números ganadores son:");
        foreach (int n in awarded)
        {
            Console.Write(n + " ");
        }
    }
}
