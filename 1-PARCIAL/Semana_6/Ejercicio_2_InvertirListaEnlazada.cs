using System;

class Nodo
{
    public int Dato;
    public Nodo Siguiente;

    public Nodo(int dato)
    {
        Dato = dato;
        Siguiente = null;
    }
}

class ListaEnlazada
{
    private Nodo cabeza;

    public void Agregar(int dato)
    {
        Nodo nuevo = new Nodo(dato);

        if (cabeza == null)
        {
            cabeza = nuevo;
        }
        else
        {
            Nodo actual = cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevo;
        }
    }

    // Método que invierte la lista enlazada
    public void Invertir()
    {
        Nodo anterior = null;
        Nodo actual = cabeza;
        Nodo siguiente = null;

        while (actual != null)
        {
            siguiente = actual.Siguiente;
            actual.Siguiente = anterior;
            anterior = actual;
            actual = siguiente;
        }

        cabeza = anterior;
    }

    public void Mostrar()
    {
        Nodo actual = cabeza;
        while (actual != null)
        {
            Console.Write(actual.Dato + " -> ");
            actual = actual.Siguiente;
        }
        Console.WriteLine("null");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Ejercicio 2:");
        Console.WriteLine("Programa que invierte una lista enlazada, haciendo que el primer elemento pase a ser el último.\n");

        ListaEnlazada lista = new ListaEnlazada();
        lista.Agregar(05);
        lista.Agregar(13);
        lista.Agregar(25);
        lista.Agregar(43);
        lista.Agregar(83);

        Console.WriteLine("Lista original:");
        lista.Mostrar();

        lista.Invertir();

        Console.WriteLine("\nLista invertida:");
        lista.Mostrar();
    }
}
