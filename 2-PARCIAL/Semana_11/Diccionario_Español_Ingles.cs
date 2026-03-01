using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        // Diccionario Español -> Inglés
        Dictionary<string, string> diccionario = new Dictionary<string, string>()
        {
            {"tiempo", "time"},
            {"persona", "person"},
            {"año", "year"},
            {"camino", "way"},
            {"forma", "way"},
            {"día", "day"},
            {"cosa", "thing"},
            {"hombre", "man"},
            {"mundo", "world"},
            {"vida", "life"},
            {"mano", "hand"},
            {"parte", "part"},
            {"niño", "child"},
            {"niña", "child"},
            {"ojo", "eye"},
            {"mujer", "woman"},
            {"lugar", "place"},
            {"trabajo", "work"},
            {"semana", "week"},
            {"caso", "case"},
            {"punto", "point"},
            {"tema", "point"},
            {"gobierno", "government"},
            {"empresa", "company"},
            {"compañía", "company"}
        };

        int opcion;

        do
        {
            Console.WriteLine("==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("\nSeleccione una opción: ");

            opcion = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (opcion)
            {
                case 1:
                    TraducirFrase(diccionario);
                    break;

                case 2:
                    AgregarPalabra(diccionario);
                    break;

                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            Console.WriteLine();

        } while (opcion != 0);
    }

    static void TraducirFrase(Dictionary<string, string> diccionario)
    {
        Console.Write("Ingrese una frase en español: ");
        string frase = Console.ReadLine().ToLower();

        // Separar palabras conservando signos de puntuación
        string[] palabras = Regex.Split(frase, @"(\W+)");

        for (int i = 0; i < palabras.Length; i++)
        {
            string palabraLimpia = palabras[i].ToLower();

            if (diccionario.ContainsKey(palabraLimpia))
            {
                palabras[i] = diccionario[palabraLimpia];
            }
        }

        string fraseTraducida = string.Join("", palabras);

        Console.WriteLine("\nTraducción parcial:");
        Console.WriteLine(fraseTraducida);
    }

    static void AgregarPalabra(Dictionary<string, string> diccionario)
    {
        Console.Write("Ingrese la palabra en español: ");
        string espanol = Console.ReadLine().ToLower();

        Console.Write("Ingrese la traducción en inglés: ");
        string ingles = Console.ReadLine().ToLower();

        if (!diccionario.ContainsKey(espanol))
        {
            diccionario.Add(espanol, ingles);
            Console.WriteLine("Palabra agregada correctamente.");
        }
        else
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
    }
}