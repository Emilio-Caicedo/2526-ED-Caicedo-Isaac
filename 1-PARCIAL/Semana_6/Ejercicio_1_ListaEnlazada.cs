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

    // Método que cuenta los elementos recorriendo la lista
    public int ContarElementos()
    {
        int contador = 0;
        Nodo actual = cabeza;

        while (actual != null)
        {
            contador++;
            actual = actual.Siguiente;
        }

        return contador;
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
        Console.WriteLine("Ejercicio 1:");
        Console.WriteLine("Función que calcula el número de elementos de una lista enlazada recorriendo nodo por nodo.\n");

        ListaEnlazada lista = new ListaEnlazada();
        lista.Agregar(05);
        lista.Agregar(13);
        lista.Agregar(25);
        lista.Agregar(43);
        lista.Agregar(86);

        lista.Mostrar();

        int cantidad = lista.ContarElementos();
        Console.WriteLine("\nNúmero de elementos en la lista: " + cantidad);
    }
}
