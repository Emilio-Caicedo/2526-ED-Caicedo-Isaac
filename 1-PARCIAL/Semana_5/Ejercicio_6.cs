using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Ejercicio 6:");
        Console.WriteLine("Programa que pide la nota de cada asignatura y muestra cuáles debe repetir el estudiante.\n");

        string[] subjects = { "Administración de Sistemas Operativos", "Estructura de Datos", "Fundamentos de Sistemas Digitales", "Instalaciones Eléctricas y de Cableado Estructurado", "Metodología de la Investigación" };
        List<string> toRepeat = new List<string>();

        foreach (string subject in subjects)
        {
            Console.Write("¿Qué nota has sacado en " + subject + "? ");
            double score = double.Parse(Console.ReadLine());

            if (score < 5)
            {
                toRepeat.Add(subject);
            }
        }

        Console.WriteLine("\nAsignaturas que debes repetir:");
        if (toRepeat.Count == 0)
        {
            Console.WriteLine("Ninguna. ¡Felicidades!");
        }
        else
        {
            foreach (string subject in toRepeat)
            {
                Console.WriteLine(subject);
            }
        }
    }
}
