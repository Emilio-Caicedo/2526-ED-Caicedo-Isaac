using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Ejercicio 2:");
        Console.WriteLine("Escribir un programa que almacene las asignaturas de un curso y muestre el mensaje 'Yo estudio <asignatura>'.\n");

        string[] subjects = { "Administración de Sistemas Operativos", "Estructura de Datos", "Fundamentos de Sistemas Digitales", "Instalaciones Eléctricas y de Cableado Estructurado", "Metodología de la Investigación" };

        foreach (string subject in subjects)
        {
            Console.WriteLine("Yo estudio " + subject);
        }
    }
}
