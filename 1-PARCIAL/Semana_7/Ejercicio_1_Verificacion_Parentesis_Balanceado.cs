using System;
using System.Collections.Generic;

namespace ParentesisBalanceados
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("VERIFICACIÓN DE PARÉNTESIS BALANCEADOS\n");

            Console.Write("Ingrese una expresión matemática: ");
            string expresion = Console.ReadLine();

            if (EstaBalanceada(expresion))
            {
                Console.WriteLine("\n✔ Fórmula balanceada.");
            }
            else
            {
                Console.WriteLine("\n✘ Fórmula NO balanceada.");
            }

            Console.WriteLine("\nPresione una tecla para salir...");
            Console.ReadKey();
        }

        /// <summary>
        /// Verifica si los paréntesis, llaves y corchetes
        /// están correctamente balanceados usando una pila.
        /// </summary>
        static bool EstaBalanceada(string expresion)
        {
            Stack<char> pila = new Stack<char>();

            foreach (char c in expresion)
            {
                // Si es símbolo de apertura, se apila
                if (c == '(' || c == '{' || c == '[')
                {
                    pila.Push(c);
                }
                // Si es símbolo de cierre, se compara con el tope
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (pila.Count == 0)
                        return false;

                    char tope = pila.Pop();

                    if (!EsParCorrecto(tope, c))
                        return false;
                }
            }

            // Si la pila queda vacía, está balanceada
            return pila.Count == 0;
        }

        /// <summary>
        /// Verifica si los símbolos de apertura y cierre coinciden.
        /// </summary>
        static bool EsParCorrecto(char apertura, char cierre)
        {
            return (apertura == '(' && cierre == ')') ||
                   (apertura == '{' && cierre == '}') ||
                   (apertura == '[' && cierre == ']');
        }
    }
}
