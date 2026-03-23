using System;

class Nodo
{
    public int Valor;
    public Nodo Izquierdo;
    public Nodo Derecho;

    public Nodo(int valor)
    {
        Valor = valor;
        Izquierdo = null;
        Derecho = null;
    }
}

class ArbolBinarioBusqueda
{
    public Nodo Raiz;

    // INSERTAR
    public void Insertar(int valor)
    {
        Raiz = InsertarRecursivo(Raiz, valor);
    }

    private Nodo InsertarRecursivo(Nodo raiz, int valor)
    {
        if (raiz == null)
            return new Nodo(valor);

        if (valor < raiz.Valor)
            raiz.Izquierdo = InsertarRecursivo(raiz.Izquierdo, valor);
        else if (valor > raiz.Valor)
            raiz.Derecho = InsertarRecursivo(raiz.Derecho, valor);

        return raiz;
    }

    // BUSCAR
    public bool Buscar(int valor)
    {
        return BuscarRecursivo(Raiz, valor);
    }

    private bool BuscarRecursivo(Nodo raiz, int valor)
    {
        if (raiz == null) return false;
        if (raiz.Valor == valor) return true;

        if (valor < raiz.Valor)
            return BuscarRecursivo(raiz.Izquierdo, valor);
        else
            return BuscarRecursivo(raiz.Derecho, valor);
    }

    // ELIMINAR
    public void Eliminar(int valor)
    {
        Raiz = EliminarRecursivo(Raiz, valor);
    }

    private Nodo EliminarRecursivo(Nodo raiz, int valor)
    {
        if (raiz == null) return raiz;

        if (valor < raiz.Valor)
            raiz.Izquierdo = EliminarRecursivo(raiz.Izquierdo, valor);
        else if (valor > raiz.Valor)
            raiz.Derecho = EliminarRecursivo(raiz.Derecho, valor);
        else
        {
            // Caso 1: sin hijos
            if (raiz.Izquierdo == null && raiz.Derecho == null)
                return null;

            // Caso 2: un hijo
            if (raiz.Izquierdo == null)
                return raiz.Derecho;
            else if (raiz.Derecho == null)
                return raiz.Izquierdo;

            // Caso 3: dos hijos
            Nodo sucesor = ObtenerMinNodo(raiz.Derecho);
            raiz.Valor = sucesor.Valor;
            raiz.Derecho = EliminarRecursivo(raiz.Derecho, sucesor.Valor);
        }

        return raiz;
    }

    // RECORRIDOS
    public void Inorden()
    {
        InordenRec(Raiz);
        Console.WriteLine();
    }

    private void InordenRec(Nodo raiz)
    {
        if (raiz != null)
        {
            InordenRec(raiz.Izquierdo);
            Console.Write(raiz.Valor + " ");
            InordenRec(raiz.Derecho);
        }
    }

    public void Preorden()
    {
        PreordenRec(Raiz);
        Console.WriteLine();
    }

    private void PreordenRec(Nodo raiz)
    {
        if (raiz != null)
        {
            Console.Write(raiz.Valor + " ");
            PreordenRec(raiz.Izquierdo);
            PreordenRec(raiz.Derecho);
        }
    }

    public void Postorden()
    {
        PostordenRec(Raiz);
        Console.WriteLine();
    }

    private void PostordenRec(Nodo raiz)
    {
        if (raiz != null)
        {
            PostordenRec(raiz.Izquierdo);
            PostordenRec(raiz.Derecho);
            Console.Write(raiz.Valor + " ");
        }
    }

    // MÍNIMO
    public int Minimo()
    {
        Nodo nodo = ObtenerMinNodo(Raiz);
        return nodo != null ? nodo.Valor : -1;
    }

    private Nodo ObtenerMinNodo(Nodo raiz)
    {
        if (raiz == null) return null;
        while (raiz.Izquierdo != null)
            raiz = raiz.Izquierdo;
        return raiz;
    }

    // MÁXIMO
    public int Maximo()
    {
        Nodo nodo = Raiz;
        if (nodo == null) return -1;

        while (nodo.Derecho != null)
            nodo = nodo.Derecho;

        return nodo.Valor;
    }

    // ALTURA
    public int Altura()
    {
        return AlturaRec(Raiz);
    }

    private int AlturaRec(Nodo raiz)
    {
        if (raiz == null) return -1;

        int izquierda = AlturaRec(raiz.Izquierdo);
        int derecha = AlturaRec(raiz.Derecho);

        return Math.Max(izquierda, derecha) + 1;
    }

    // LIMPIAR
    public void Limpiar()
    {
        Raiz = null;
    }
}

class Program
{
    static void Main()
    {
        ArbolBinarioBusqueda arbol = new ArbolBinarioBusqueda();
        int opcion;

        do
        {
            Console.WriteLine("\n===== ÁRBOL BINARIO DE BÚSQUEDA (BST) =====");
            Console.WriteLine("1. Insertar valor");
            Console.WriteLine("2. Buscar valor");
            Console.WriteLine("3. Eliminar valor");
            Console.WriteLine("4. Mostrar recorrido Inorden");
            Console.WriteLine("5. Mostrar recorrido Preorden");
            Console.WriteLine("6. Mostrar recorrido Postorden");
            Console.WriteLine("7. Mostrar valor mínimo");
            Console.WriteLine("8. Mostrar valor máximo");
            Console.WriteLine("9. Mostrar altura del árbol");
            Console.WriteLine("10. Limpiar árbol");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el valor a insertar: ");
                    int valorInsertar = Convert.ToInt32(Console.ReadLine());
                    arbol.Insertar(valorInsertar);
                    Console.WriteLine("Valor insertado correctamente.");
                    break;

                case 2:
                    Console.Write("Ingrese el valor a buscar: ");
                    int valorBuscar = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(arbol.Buscar(valorBuscar) ? "Valor encontrado." : "Valor no encontrado.");
                    break;

                case 3:
                    Console.Write("Ingrese el valor a eliminar: ");
                    int valorEliminar = Convert.ToInt32(Console.ReadLine());
                    arbol.Eliminar(valorEliminar);
                    Console.WriteLine("Valor eliminado si existía.");
                    break;

                case 4:
                    Console.WriteLine("Recorrido Inorden:");
                    arbol.Inorden();
                    break;

                case 5:
                    Console.WriteLine("Recorrido Preorden:");
                    arbol.Preorden();
                    break;

                case 6:
                    Console.WriteLine("Recorrido Postorden:");
                    arbol.Postorden();
                    break;

                case 7:
                    Console.WriteLine("Valor mínimo: " + arbol.Minimo());
                    break;

                case 8:
                    Console.WriteLine("Valor máximo: " + arbol.Maximo());
                    break;

                case 9:
                    Console.WriteLine("Altura del árbol: " + arbol.Altura());
                    break;

                case 10:
                    arbol.Limpiar();
                    Console.WriteLine("Árbol eliminado completamente.");
                    break;
            }

        } while (opcion != 0);
    }
}
