using System;

// Clase que representa un Círculo con encapsulación y métodos de cálculo
public class Circulo
{
    private double radio;

    public double Radio
    {
        get { return radio; }
        set 
        { 
            if (value <= 0)
                throw new ArgumentException("El radio debe ser un valor positivo.");
            radio = value;
        }
    }

    public Circulo(double radioInicial)
    {
        Radio = radioInicial;
    }

    // Calcula el área del círculo: π * radio²
    public double CalcularArea()
    {
        return Math.PI * Radio * Radio;
    }

    // Calcula la circunferencia (perímetro) del círculo: 2 * π * radio
    public double CalcularPerimetro()
    {
        return 2 * Math.PI * Radio;
    }
}


// Clase que representa un Cuadrado con encapsulación y métodos de cálculo
public class Cuadrado
{
    private double lado;

    public double Lado
    {
        get { return lado; }
        set 
        { 
            if (value <= 0)
                throw new ArgumentException("El lado debe ser un valor positivo.");
            lado = value;
        }
    }

    public Cuadrado(double ladoInicial)
    {
        Lado = ladoInicial;
    }

    // Calcula el área del cuadrado: lado * lado
    public double CalcularArea()
    {
        return Lado * Lado;
    }

    // Calcula el perímetro del cuadrado: 4 * lado
    public double CalcularPerimetro()
    {
        return 4 * Lado;
    }
}


// Programa principal que se ejecuta sin errores
class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Valores EXPLÍCITOS y POSITIVOS para evitar errores de validación
            double valorRadioCirculo = 3.5;
            double valorLadoCuadrado = 6;

            // Crear instancias con los valores definidos
            Circulo circuloEjemplo = new Circulo(valorRadioCirculo);
            Cuadrado cuadradoEjemplo = new Cuadrado(valorLadoCuadrado);

            // Mostrar resultados claros en consola
            Console.WriteLine("==================================");
            Console.WriteLine("       RESULTADOS DE LAS FIGURAS");
            Console.WriteLine("==================================");

            Console.WriteLine("\n[CÍRCULO]");
            Console.WriteLine($"Radio utilizado: {valorRadioCirculo} unidades");
            Console.WriteLine($"Área calculada: {circuloEjemplo.CalcularArea():F2} unidades²");
            Console.WriteLine($"Perímetro (circunferencia): {circuloEjemplo.CalcularPerimetro():F2} unidades");

            Console.WriteLine("\n[CUADRADO]");
            Console.WriteLine($"Lado utilizado: {valorLadoCuadrado} unidades");
            Console.WriteLine($"Área calculada: {cuadradoEjemplo.CalcularArea():F2} unidades²");
            Console.WriteLine($"Perímetro calculado: {cuadradoEjemplo.CalcularPerimetro():F2} unidades");

            Console.WriteLine("\n==================================");
            Console.WriteLine("Programa ejecutado CORRECTAMENTE!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        // Pausa para ver los resultados (funciona en Windows, Linux y macOS)
        Console.WriteLine("\nPresiona cualquier tecla para cerrar...");
        Console.ReadKey();
    }
}