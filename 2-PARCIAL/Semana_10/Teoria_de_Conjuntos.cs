// Program.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace VacunacionCovidSetTheory
{
    class Program
    {
        static void Main(string[] args)
        {
            // Parámetros
            const int totalCiudadanos = 500;
            const int cantidadPfizer = 75;
            const int cantidadAstraZeneca = 75;
            const int overlapCount = 20; // cantidad de ciudadanos que estarán en ambos conjuntos (intersección)

            var rnd = new Random(); // puedes pasar una semilla fija para reproducibilidad, ej: new Random(12345);

            // 1) Generar lista de ciudadanos "Ciudadano 1" .. "Ciudadano 500"
            var ciudadanos = Enumerable.Range(1, totalCiudadanos)
                                      .Select(i => $"Ciudadano {i}")
                                      .ToList();

            // 2) Seleccionar aleatoriamente 75 para Pfizer
            var pfizer = PickRandomSubset(ciudadanos, cantidadPfizer, rnd);

            // 3) Para AstraZeneca vamos a garantizar 'overlapCount' personas que estén también en Pfizer
            //    y luego completar el resto con personas que NO estén en Pfizer.
            if (overlapCount > cantidadPfizer || overlapCount > cantidadAstraZeneca)
            {
                throw new ArgumentException("El overlapCount no puede ser mayor que la cantidad de vacunados de cada tipo.");
            }

            // Elegir 'overlapCount' de los ya seleccionados en Pfizer
            var overlap = PickRandomSubset(pfizer.ToList(), overlapCount, rnd);

            // Ahora elegir (cantidadAstraZeneca - overlapCount) personas que NO estén en pfizer
            var disponiblesParaAZ = ciudadanos.Except(pfizer).ToList();
            var adicionalesAZ = PickRandomSubset(disponiblesParaAZ, cantidadAstraZeneca - overlapCount, rnd);

            // Construir el conjunto de AstraZeneca (con overlap incluido)
            var astraZeneca = new HashSet<string>(overlap);
            astraZeneca.UnionWith(adicionalesAZ);

            // ---- Operaciones de teoría de conjuntos ----
            // Unión (todos los vacunados con al menos una de las dos vacunas)
            var vacunadosUnion = new HashSet<string>(pfizer);
            vacunadosUnion.UnionWith(astraZeneca);

            // Ciudadanos no vacunados = universo \ unión
            var noVacunados = ciudadanos.Except(vacunadosUnion).ToList();

            // Intersección (han recibido "ambas dosis" según la interpretación como pertenecer a ambos conjuntos)
            var ambos = new HashSet<string>(pfizer);
            ambos.IntersectWith(astraZeneca);

            // Solo Pfizer = Pfizer \ AstraZeneca
            var soloPfizer = new HashSet<string>(pfizer);
            soloPfizer.ExceptWith(astraZeneca);

            // Solo AstraZeneca = AstraZeneca \ Pfizer
            var soloAstra = new HashSet<string>(astraZeneca);
            soloAstra.ExceptWith(pfizer);

            // ---- Salida por consola ----
            Console.WriteLine("===== RESUMEN =====");
            Console.WriteLine($"Total ciudadanos: {totalCiudadanos}");
            Console.WriteLine($"Vacunados con Pfizer (conjunto A): {pfizer.Count}");
            Console.WriteLine($"Vacunados con AstraZeneca (conjunto B): {astraZeneca.Count}");
            Console.WriteLine($"Vacunados (A ∪ B): {vacunadosUnion.Count}");
            Console.WriteLine($"No vacunados (Universo \\ (A ∪ B)): {noVacunados.Count}");
            Console.WriteLine($"Han recibido ambas dosis (A ∩ B): {ambos.Count}");
            Console.WriteLine($"Solo Pfizer (A \\ B): {soloPfizer.Count}");
            Console.WriteLine($"Solo AstraZeneca (B \\ A): {soloAstra.Count}");
            Console.WriteLine();

            // Imprimir listados (cada uno en sección separada)
            PrintList("1) Ciudadanos que NO se han vacunado", noVacunados);
            PrintList("2) Ciudadanos que han recibido AMBAS dosis (intersección A ∩ B)", ambos);
            PrintList("3) Ciudadanos que SOLO han recibido la vacuna de PFIZER (A \\ B)", soloPfizer);
            PrintList("4) Ciudadanos que SOLO han recibido la vacuna de ASTRAZENECA (B \\ A)", soloAstra);

            // Fin
            Console.WriteLine("\nProceso finalizado. Presiona ENTER para salir.");
            Console.ReadLine();
        }

        // Método auxiliar: selecciona aleatoriamente 'count' elementos únicos de la lista 'source'
        static HashSet<string> PickRandomSubset(List<string> source, int count, Random rnd)
        {
            if (count < 0 || count > source.Count)
                throw new ArgumentOutOfRangeException(nameof(count), "El número a seleccionar debe estar entre 0 y el tamaño de la fuente.");

            var result = new HashSet<string>();
            var available = new List<string>(source);

            // algoritmo Fisher-Yates simplificado para seleccionar sin reemplazo
            for (int i = 0; i < count; i++)
            {
                int j = rnd.Next(i, available.Count);
                // intercambiar available[i] y available[j]
                var temp = available[i];
                available[i] = available[j];
                available[j] = temp;

                result.Add(available[i]); // ahora el elemento i es una selección
            }

            return result;
        }

        // Método para imprimir listas con título y elementos (acepta IEnumerable<string>)
        static void PrintList(string title, IEnumerable<string> items)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine(title);
            Console.WriteLine($"Cantidad: {items.Count()}");
            Console.WriteLine();

            // Imprime cada elemento en una línea
            foreach (var item in items.OrderBy(x => x))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }
    }
}