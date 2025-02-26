// Codifica un programa para la fabricación de Naves Estelares.  
class Naves
{
    private static void Main(string[] args)
    {
        FabricaNaves fabrica = new FabricaNaves();
        int opcion = 0;
        bool salir = false;

        do
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1. crear nave");
            Console.WriteLine("2. crear un bloque de 10 naves");
            Console.WriteLine("3. cambiar su nombre (por índice) ");
            Console.WriteLine("4. Ver una lista de las naves fabricadas");
            Console.WriteLine("5. Eliminar todas las Naves");
            Console.WriteLine("6. Eliminar una única Nave (por índice)");
            Console.WriteLine("7. Listar todas las naves");
            Console.WriteLine("8. Pasar todos los elementos de la lista a una pila");
            Console.WriteLine("9. Mostrar elementos de la pila o pila vacía");
            Console.WriteLine("10. Salir");

            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    fabrica.CrearNave();
                break;
                case 2:
                    fabrica.CrearBloqueNaves();
                break;
                case 3:
                    fabrica.CambiarNombre(0, "NAVE-50");
                break;
                case 4:
                    fabrica.ListarNaves();
                break;
                case 5:
                    fabrica.EliminarTodasNaves();
                break;
                case 6:
                    fabrica.EliminarNave(2); 
                break;
                case 7:
                    fabrica.MostrarPila();
                break;
                case 8:
                    fabrica.TransferirAPila();
                break;
                case 9:
                    fabrica.MostrarPila();
                break;
                case 10:
                    salir = true;
                break;
                default:
                    Console.WriteLine("NooNo, No.");
                break;
            }
        } while (!salir);
    }
}
class FabricaNaves
{
    static string[] NombresBase = { "HALCONMILENARIO", "CAZAESTELAR", "SUPERDESTRUCTOR", "YWING", "XWING" };
    List<string?> naves = new List<string?>();
    Stack<string> pila = new Stack<string>();
    Queue<int> indicesLibres = new Queue<int>();
    Random random = new Random();

    private string GenerarNombre()
    {
        string nombre;
        do
        {
            nombre = $"{NombresBase[random.Next(NombresBase.Length)]}{random.Next(10, 100)}";
        } while (naves.Contains(nombre));
        return nombre;
    }

    public void CrearNave()
    {
        string nombre = GenerarNombre();
        if (indicesLibres.Count > 0)
        {
            int index = indicesLibres.Dequeue();
            naves[index] = nombre;
        }
        else
        {
            naves.Add(nombre);
        }
        Console.WriteLine($"Nave creada: {nombre}");
    }

    public void CrearBloqueNaves()
    {
        for (int i = 0; i < 10; i++)
        {
            CrearNave();
        }
    }

    public void CambiarNombre(int indice, string nuevoNombre)
    {
        if (indice >= 0 && indice < naves.Count && naves[indice] != null)
        {
            if (!naves.Contains(nuevoNombre))
            {
                naves[indice] = nuevoNombre;
                Console.WriteLine($"Nombre cambiado en índice {indice} a {nuevoNombre}");
            }
            else
            {
                Console.WriteLine("Error: Nombre ya existent");
            }
        }
        else
        {
            Console.WriteLine("Error: Índice inválido");
        }
    }

    public void ListarNaves()
    {
        for (int i = 0; i < naves.Count; i++)
        {
            if (naves[i] != null)
            {
                Console.WriteLine($"[{i}] {naves[i]}");
            }
        }
    }

    public void EliminarTodasNaves()
    {
        naves.Clear();
        pila.Clear();
        indicesLibres.Clear();
        Console.WriteLine("Todas las naves han sido eliminadas");
    }

    public void EliminarNave(int indice)
    {
        if (indice >= 0 && indice < naves.Count && naves[indice] != null)
        {
            Console.WriteLine($"Nave eliminada: {naves[indice]}");
            naves[indice] = null;
            indicesLibres.Enqueue(indice);
        }
        else
        {
            Console.WriteLine("error: intenta de nuevo");
        }
    }

    public void TransferirAPila()
    {
        foreach (var nave in naves)
        {
            if (nave != null)
            {
                pila.Push(nave);
            }
        }
        naves.Clear();
        Console.WriteLine("Todas las naves han sido transferidas a la pila");
    }

    public void MostrarPila()
    {
        if (pila.Count > 0)
        {
            Console.WriteLine("Elementos en la pila:");
            foreach (var nave in pila)
            {
                Console.WriteLine(nave);
            }
        }
        else
        {
            Console.WriteLine("La pila esta vacia");
        }
    }
}