using System;
using System.Collections.Generic;

namespace TorresDeHanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("RESOLUCIÓN DEL PROBLEMA DE LAS TORRES DE HANOI\n");

            Console.Write("Ingrese el número de discos: ");
            int n = int.Parse(Console.ReadLine());

            // Definición de las tres torres como pilas
            Stack<int> torreOrigen = new Stack<int>();
            Stack<int> torreAuxiliar = new Stack<int>();
            Stack<int> torreDestino = new Stack<int>();

            // Se colocan los discos en la torre origen
            for (int i = n; i >= 1; i--)
            {
                torreOrigen.Push(i);
            }

            Console.WriteLine("\nMovimientos:");
            ResolverHanoi(n, torreOrigen, torreDestino, torreAuxiliar,
                          "Origen", "Destino", "Auxiliar");

            Console.WriteLine("\nProceso finalizado.");
            Console.ReadKey();
        }

        /// <summary>
        /// Algoritmo recursivo que resuelve las Torres de Hanoi
        /// utilizando pilas (Stack).
        /// </summary>
        static void ResolverHanoi(
            int n,
            Stack<int> origen,
            Stack<int> destino,
            Stack<int> auxiliar,
            string nombreOrigen,
            string nombreDestino,
            string nombreAuxiliar)
        {
            if (n == 1)
            {
                int disco = origen.Pop();
                destino.Push(disco);
                Console.WriteLine($"Mover disco {disco} de {nombreOrigen} a {nombreDestino}");
                return;
            }

            // Paso 1: mover n-1 discos a la torre auxiliar
            ResolverHanoi(n - 1, origen, auxiliar, destino,
                          nombreOrigen, nombreAuxiliar, nombreDestino);

            // Paso 2: mover el disco más grande al destino
            int discoMayor = origen.Pop();
            destino.Push(discoMayor);
            Console.WriteLine($"Mover disco {discoMayor} de {nombreOrigen} a {nombreDestino}");

            // Paso 3: mover los n-1 discos al destino
            ResolverHanoi(n - 1, auxiliar, destino, origen,
                          nombreAuxiliar, nombreDestino, nombreOrigen);
        }
    }
}
