using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Ejercicio 8:");
        Console.WriteLine("Programa que determina si una palabra es un palíndromo.\n");

        Console.Write("Introduce una palabra: ");
        string word = Console.ReadLine();

        char[] letters = word.ToCharArray();
        Array.Reverse(letters);
        string reversedWord = new string(letters);

        if (word.Equals(reversedWord, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Es un palíndromo");
        }
        else
        {
            Console.WriteLine("No es un palíndromo");
        }
    }
}
