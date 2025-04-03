internal class Program
{
    private static Random random = new Random();
    private static void Main(string[] args)
    {
        Robots[] robots = new Robots[10];
        int numRobots = 0;
        
        do
        {
            Console.WriteLine("Menú");
            Console.WriteLine("1. Generar un robot");
            Console.WriteLine("2. Restablecer robot");
            Console.WriteLine("3. Ver un robot guardado en una posición concreta");
            Console.WriteLine("4. Eliminar robot de una posición concreta");
            Console.WriteLine("5. Listar todos los robots");
            Console.WriteLine("6. Salir");
            Console.WriteLine("ingrese su opción");

            int opcion = Converto.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    GenerarRobot(ref robots, ref numRobots);
                break;
                case 2:
                    RestablecerRobot(ref robots, ref numRobots);
                break;
                case 3:
                    PoscicionRobot(robots, numRobots);
                break;
                case 4:
                    EliminarPosicionRobot(ref robots, ref numRobots);
                break;
                case 5:
                    ListarRobots(robots, numRobots);
                break;
                case 6:
                    Console.WriteLine("Saliendo del programa...");
                break;
                default:
                    Console.WriteLine("Intentalo de nuevo.");
                break;
            }

        } while (opcion !=6);
        
    }
    static void GenerarRobot(ref Robots[] robots, int numRobots)
    {
        if (numRobots >= robots.Lenght)
        {
            Console.WriteLine("No se pueden generar más robots. El array está lleno");
            return;
        }

        Robots nuevoRobot;
        nuevoRobot.nombre = GenerarNombreUnico(robots, numRobots);

        Console.WriteLine("Seleccione el modelo del robot (R2D2, C3PO, BBB)");
        nuevoRobot.modelo = Console.ReadLine();

        robots[numRobots++] = nuevoRobot;
        Console.WriteLine(&"Robot generado con éxito: {nuevoRobot.nombre} = Modelo: {nuevoRobot.modelo}");
    }

    static void RestablecerRobot(ref Robots[] robots, ref int numRobots)
    {
        if (numRobots == 0)
        {
            Console.WriteLine("No hay robots guardados");
            return;
        }

        Console.WriteLine("Ingrese el nombre del robot que desee restablecer");
        string nombreBuscado = Console.ReadLine();

        bool encontrado = false;
        for (int i = 0; i < numRobots; i++)
        {
            if (robots[i].nombre.Equals(nombreBuscado, StringComparison.OrdinaIgnoreCase))
            {
                robots[i] = new Robots();
                encontrado = true;
                Console.WriteLine("Robot restablecido con éxito");
                break;
            }

            if(!encontrado)
            {
                Console.WriteLine("Robot no encontrado");
            }
        }
    }

    static void PoscicionRobot(Robots[] robots, int numRobots)
    {
        if (numRobots == 0)
        {
            Console.WriteLine("No hay robots guardados");
            return;
        }

        Console.WriteLine("Ingrese la psición del robot que desea ver (0 - 9)");
        int posicion;

        if (!int.TryParse(Console.ReadLine(), out posicion) || posicion < 0 || posicion >= numRobots)
        {
            Console.WriteLine("Posicion inválida. Asegurese de ingresar un número dentro del rango válido.");
            return;    
        }

        if (string.IsNullOrEmpty(robots[posicion].nombre))
        {
            Console.WriteLine("No hay un robot en esta posición");
            return;
        }

        Console.WriteLine("-------------------");
        Console.WriteLine($"Nombre: {robots[posicion].nombre}");
        Console.WriteLine($"Modelo: {robots[posicion].modelo}");
        Console.WriteLine("-------------------");
    }

    static void EliminarPosicionRobot(ref Robots[] robots, ref int numRobots)
    {
        if (numRobots == 0)
        {
            Console.WriteLine("No hay robots guardados");
            return;
        }

        Console.WriteLine("Ingrese el nombre del robot a eliminar");
        string nombreBuscado = Console.ReadLine();

        bool encontrado = false;
        for (int i = 0; i < numRobots; i++)
        {
            if (robots[i].nombre.Equals(nombreBuscado, StringComparison.OrdinalIgnoreCase))
            {
                robots[i] = new Robots();
                encontrado = true;
                Console.WriteLine("Robot eliminado con éxito");
                break;
            }
            if (!encontrado)
            {
                Console.WriteLine("Robot no encontrado");
            }
        }
    }

    static void ListarRobots(Robots[] robots, int numRobots)
    {
        for (int i = 0; i < numRobots; i++)
        {
            Console.WriteLine("-------------------");
            Console.WriteLine($"Nombre: {robots[i].nombre}");
            Console.WriteLine($"Modelo: {robots[i].modelo}");
            Console.WriteLine("-------------------");
        }
    }

    static void GenerarNombreUnico(Robots[] robots, int numRobots)
    {
        string nuevoNombre;
        bool repetido;

        do
        {
            nuevoNombre = generarNombreAleatorio();
            repetido = false;

            for (int i = 0; i < numRobots; i++)
            {
                if (robots[i].nombre == nuevoNombre)
                {
                    repetido = true;
                    break;
                }
            }
        } while (repetido);

        return nuevoNombre;
    }

    static string generarNombreAleatorio()
    {
        char letra1 = (char)random.Next('A', 'Z', + 1);
        char letra2 = (char)random.Next('A', 'Z', + 1);
        int numero = random.Next(100, 1000);

        return $"{letra1}{letra2}{numero}";
    }

    
}

struct Robots
{
    public string nombre;
    public string modelo; 
}

// Tarea 2 "Control de stock"

// internal class Ejercicio2
// {
//     static void Main(string[] args)
//     {
//         Almacen[] productos = new Almacen[20];
//         int numProductos = 0;
//         int opcion;

//         do
//         {
//             Console.WriteLine("Menú");
//             Console.WriteLine("1. Agregar producto");
//             Console.WriteLine("2. Borrar producto");
//             Console.WriteLine("3. Editar producto");
//             Console.WriteLine("4. Mostrar producto");
//             Console.WriteLine("5. Mostrar producto por categoria");
//             Console.WriteLine("6. Salir");
//             Console.WriteLine("ingrese su opción");

//             int opcion = Converto.ToInt32(Console.ReadLine());

//             switch (opcion)
//             {
//                 case 1:
//                     AgregarProducto(ref productos, ref numProductos);
//                 break;
//                 case 2:
//                     BorrarProducto(ref productos, ref numProductos);
//                 break;
//                 case 3:
//                     EditarProducto(productos, numProductos);
//                 break;
//                 case 4:
//                     ListarProducto(ref productos, ref numProductos);
//                 break;
//                 case 5:
//                     ListarProductoPorCategoria(productos, numProductos);
//                 break;
//                 case 6:
//                     Console.WriteLine("Saliendo del programa...");
//                 break;
//                 default:
//                     Console.WriteLine("Intentalo de nuevo.");
//                 break;
//             }

//         } while (opcion !=6);
//     }

//     static void AgregarProducto(ref Almacen[] productos, ref int numProductos)
//     {
//         Almacen nuevoProducto;

//         Console.WriteLine("Nombre producto");
//         nuevoProducto.nombre = Console.ReadLine();

//         Console.WriteLine("Categoria producto");
//         nuevoProducto.categoria = Console.ReadLine();

//         Console.WriteLine("Precio producto");
//         nuevoProducto.precio = Console.ReadLine();

//         Console.WriteLine("Cantidad producto");
//         nuevoProducto.cantidad = Convert.ToInt32(Console.ReadLine());

//         productos[numProductos++] = nuevoProducto;
//         Console.WriteLine("producto agregado");
//     }

//     static void BorrarProducto(ref Almacen[] productos, ref int numProductos)
//     {
//         Console.WriteLine("Nombre producto para borrar");
//         string nombreBuscado = Console.ReadLine();

//         bool encontrado = false;
//         for (int i = 0; i < numProductos; i++)
//         {
//             if (productos[i].nombre.Equals(nombreBuscado, StringComparison.OrdinalIgnoreCase))
//             {
//                 productos[i] = new Almacen();
//                 encontrado = true;
//                 Console.WriteLine("Producto borrado");
//                 break;                
//             }

//             if (!encontrado)
//             {
//                 Console.WriteLine("Producto no encontrado");
//             }
//         }
//     }

//     static void EditarProducto(ref Almacen[] productos, ref int numProductos)
//     {
//         Console.WriteLine("Nombre producto a editar");
//         string nombreBuscado = Console.ReadLine();

//         bool encontrado = false;
//         for (int i = 0; i < numProductos; i++)
//         {
//             if (productos[i].nombre.Equals(nombreBuscado, StringComparison.OrdinalIgnoreCase))
//             {
//                 Console.WriteLine("categoria del producto");
//                 productos[i].categoria = Console.ReadLine();

//                 Console.WriteLine("precio del producto");
//                 productos[i].precio = Console.ReadLine();

//                 Console.WriteLine("cantidad del producto");
//                 productos[i].cantidad = Console.ReadLine();

//                 encontrado = true;
//                 Console.WriteLine("Producto editado exitoso");
//                 break;                
//             }

//             if (!encontrado)
//             {
//                 Console.WriteLine("Producto no encontrado");
//             }
//         }
//     }

//     static void MostarProducto(Almacen[] productos, int numProductos)
//     {
//         for (int i = 0; i < numProductos; i++)
//         {
//             Console.WriteLine("------------------------------------------------");
//             Console.WriteLine($"Nombre del producto {productos[i].nombre}");
//             Console.WriteLine($"Categoria del producto {productos[i].categoria}");
//             Console.WriteLine($"Precio del producto {productos[i].precio}");
//             Console.WriteLine($"Cantidad del producto {productos[i].cantidad}");
//             Console.WriteLine("------------------------------------------------");
//         }
//     }

//     static void MostarProductoPorCategoria(Almacen[] productos, int numProductos)
//     {
//         Console.WriteLine("Ingresa la categoria del producto a buscar: ");
//         string categoriaBuscada = Console.ReadLine();

//         for (int i = 0; i < numProductos; i++)
//         {
//             if (productos[i].categoria.Equals(categoriaBuscada, StringComparison.OrdinaIgnoreCase))
//             {
//                 Console.WriteLine("------------------------------------------------");
//                 Console.WriteLine($"Nombre del producto {productos[i].nombre}");
//                 Console.WriteLine($"Categoria del producto {productos[i].categoria}");
//                 Console.WriteLine($"Precio del producto {productos[i].precio}");
//                 Console.WriteLine($"Cantidad del producto {productos[i].cantidad}");
//                 Console.WriteLine("------------------------------------------------");
//             }
//         }
//     }
// }

// struct Almacen
// {
//     public string nombre;
//     public string categoria;
//     public string precio;
//     public int cantidad;
// }

internal class Program
{
    static void Main(string[] args)
    {
        
    }
}