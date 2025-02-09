// // Tarea 1  “Fábrica de Robots”
// internal class Ekercicio1
// {
//     private static Random random = new Random();
//     private static void Main(string[] args)
//     {
//         Robots[] robots = new Robots[10];

//         int numRobots = 0;
//         int opcion;

//         do
//         {
//             Console.WriteLine("Menú:");
//             Console.WriteLine("1. Generar un robot:");
//             Console.WriteLine("2. Restablecer robot:");
//             Console.WriteLine("3. Ver un robot guardado en una posición concreta:");
//             Console.WriteLine("4. Eliminar robot de una posición concreta:");
//             Console.WriteLine("5. Listar todos los robots:");
//             Console.WriteLine("6. Salir:");
//             Console.Write("Ingrese su opción: ");

//             opcion = Convert.ToInt32(Console.ReadLine());

//             switch (opcion)
//             {
//                 case 1:
//                     GenerarUnRobot(ref robots, ref numRobots);
//                 break;
//                 case 2:
//                     RestablecerRobot(ref robots, ref numRobots);
//                 break;
//                 case 3:
//                     ListarPosicionRobot(robots, numRobots);
//                 break;
//                 case 4:
//                     EliminarPosicionRobot(ref robots, ref numRobots);
//                 break;
//                 case 5:
//                     ListarRobots(robots, numRobots);
//                 break;
//                 case 6:
//                     Console.WriteLine("Saliendo del programa...");
//                 break;
//                 default:

//                 break;
//             }
//         } while (opcion != 6);
//     }

//     static void GenerarUnRobot(ref Robots[] robots, ref int numRobots)
//     {
//         if (numRobots >= robots.Length)
//         {
//             Console.WriteLine("No se pueden generar más robots. El array está lleno.");
//             return;
//         }

//         Robots nuevoRobot;
//         nuevoRobot.nombre = GenerarNombreUnico(robots, numRobots);
        
//         Console.WriteLine("Seleccione el modelo del robot (R2D2, C3PO, BBB): ");
//         nuevoRobot.modelo = Console.ReadLine();

//         robots[numRobots++] = nuevoRobot;
//         Console.WriteLine($"Robot generado con éxito: {nuevoRobot.nombre} - Modelo: {nuevoRobot.modelo}");
//     }

//     static void RestablecerRobot(ref Robots[] robots, ref int numRobots)
//     {
//         if (numRobots == 0)
//         {
//             Console.WriteLine("No hay robots guardados.");
//             return;
//         }

//         Console.Write("Ingrese el nombre del robot a restablecer: ");
//         string nombreBuscado = Console.ReadLine();

//         bool encontrado = false;
//         for (int i = 0; i < numRobots; i++)
//         {
//             if (robots[i].nombre.Equals(nombreBuscado, StringComparison.OrdinalIgnoreCase))
//             {
//                 robots[i] = new Robots();
//                 encontrado = true;
//                 Console.WriteLine("Robot restablecido con éxito.");
//                 break;
//             }
//         }
//         if (!encontrado)
//         {
//             Console.WriteLine("Robot no encontrado.");
//         }
//     }

//     static void ListarPosicionRobot(Robots[] robots, int numRobots)
//     {
//         if (numRobots == 0)
//         {
//             Console.WriteLine("No hay robots guardados.");
//             return;
//         }

//         Console.Write("Ingrese la posición del robot que desea ver (0 - 9): ");
//         int posicion;

//         if (!int.TryParse(Console.ReadLine(), out posicion) || posicion < 0 || posicion >= numRobots)
//         {
//             Console.WriteLine("Posición inválida. Asegúrese de ingresar un número dentro del rango válido.");
//             return;
//         }

//         if (string.IsNullOrEmpty(robots[posicion].nombre))
//         {
//             Console.WriteLine("No hay un robot en esta posición.");
//             return;
//         }

//         Console.WriteLine("-------------------------");
//         Console.WriteLine($"Nombre: {robots[posicion].nombre}");
//         Console.WriteLine($"Modelo: {robots[posicion].modelo}");
//         Console.WriteLine("-------------------------");
//     }

//     static void EliminarPosicionRobot(ref Robots[] robots, ref int numRobots)
//     {
//         if (numRobots == 0)
//         {
//             Console.WriteLine("No hay robots guardados.");
//             return;
//         }

//         Console.Write("Ingrese el nombre del robot a eliminar: ");
//         string nombreBuscado = Console.ReadLine();

//         bool encontrado = false;
//         for (int i = 0; i < numRobots; i++)
//         {
//             if (robots[i].nombre.Equals(nombreBuscado, StringComparison.OrdinalIgnoreCase))
//             {
//                 robots[i] = new Robots();
//                 encontrado = true;
//                 Console.WriteLine("Robot eliminado con éxito.");
//                 break;
//             }
//         }
//         if (!encontrado)
//         {
//             Console.WriteLine("Robot no encontrado.");
//         }
//     }

//     static void ListarRobots(Robots[] robots, int numRobots)
//     {
//         for (int i = 0; i < numRobots; i++)
//         {
//             Console.WriteLine("-------------------------");
//             Console.WriteLine($"Nombre: {robots[i].nombre}");
//             Console.WriteLine($"Modelo: {robots[i].modelo}");
//             Console.WriteLine("-------------------------");
//         }
//     }

//     static string GenerarNombreUnico(Robots[] robots, int numRobots)
//     {
//         string nuevoNombre;
//         bool repetido;

//         do
//         {
//             nuevoNombre = GenerarNombreAleatorio();
//             repetido = false;

//             for (int i = 0; i < numRobots; i++)
//             {
//                 if (robots[i].nombre == nuevoNombre)
//                 {
//                     repetido = true;
//                     break;
//                 }
//             }
//         } while (repetido);

//         return nuevoNombre;
//     }

//     static string GenerarNombreAleatorio()
//     {
//         char letra1 = (char)random.Next('A', 'Z' + 1);
//         char letra2 = (char)random.Next('A', 'Z' + 1);
//         int numero = random.Next(100, 1000);

//         return $"{letra1}{letra2}{numero}";
//     }
// }

// struct Robots
// {
//     public string nombre;
//     public string modelo;
// }

// Tarea 2 “Control de stock”

// internal class Ejercicio2
// {
//     private static void Main(string[] args)
//     {
//         Almacen[] productos = new Almacen[20];
//         int numProductos = 0;
//         int opcion;
        
//         do
//         {
//             Console.WriteLine("Menú: ");
//             Console.WriteLine("1. Agregar un nuevo producto al stock");
//             Console.WriteLine("2. Borrar producto");
//             Console.WriteLine("3. Editar algún dato del producto");
//             Console.WriteLine("4. Mostrar todos los productos");
//             Console.WriteLine("5. Mostrar los productos de una categoría en concreto");
//             Console.WriteLine("6. Salir");
//             Console.Write("Ingrese su opción: ");

//             opcion = Convert.ToInt32(Console.ReadLine());

//             switch (opcion)
//             {
//                 case 1:
//                     AgregarProducto(ref productos, ref numProductos);
//                 break;
//                 case 2:
//                     BorrarProducto(ref productos, ref numProductos);
//                 break;
//                 case 3:
//                     EditarProducto(ref productos, ref numProductos);
//                 break;
//                 case 4:
//                     MostrarProductos(productos, numProductos);
//                 break;
//                 case 5:
//                     MostrarProductosCategoria(productos, numProductos);
//                 break;
//                 case 6:
//                     Console.WriteLine("Saliendo del programa...");
//                 break;
//                 default:
//                 break;
//             }

//         } while (opcion != 6);
//     }

//     static void AgregarProducto(ref Almacen[] productos, ref int numProductos)
//     {
//         if (numProductos >= productos.Length)
//         {
//             Console.WriteLine("No se pueden agregar más productos. El array está lleno.");
//             return;
//         }

//         Almacen nuevoProducto;

//         Console.Write("Ingrese el nombre del producto: ");
//         nuevoProducto.nombre = Console.ReadLine();

//         Console.Write("Ingrese la categoría del producto: ");
//         nuevoProducto.categoria = Console.ReadLine();

//         Console.Write("Ingrese el precio del producto: ");
//         nuevoProducto.precio = Console.ReadLine();

//         Console.Write("Ingrese la cantidad del producto: ");
//         nuevoProducto.cantidad = Convert.ToInt32(Console.ReadLine());

//         productos[numProductos++] = nuevoProducto;
//         Console.WriteLine("Producto agregado");
//     }
    
//     static void BorrarProducto(ref Almacen[] productos, ref int numProductos)
//     {
//         if (numProductos == 0)
//         {
//             Console.WriteLine("No hay productos guardados.");
//             return;
//         }

//         Console.Write("Ingrese el nombre del producto a borrar: ");
//         string nombreBuscado = Console.ReadLine();

//         bool encontrado = false;
//         for (int i = 0; i < numProductos; i++)
//         {
//             if (productos[i].nombre.Equals(nombreBuscado, StringComparison.OrdinalIgnoreCase))
//             {
//                 productos[i] = new Almacen();
//                 encontrado = true;
//                 Console.WriteLine("Producto borrado con éxito.");
//                 break;
//             }
//         }
//         if (!encontrado)
//         {
//             Console.WriteLine("Producto no encontrado.");
//         }
//     }

//     static void EditarProducto(ref Almacen[] productos, ref int numProductos)
//     {
//         if (numProductos == 0)
//         {
//             Console.WriteLine("No hay productos guardados.");
//             return;
//         }

//         Console.Write("Ingrese el nombre del producto a editar: ");
//         string nombreBuscado = Console.ReadLine();

//         bool encontrado = false;
//         for (int i = 0; i < numProductos; i++)
//         {
//             if (productos[i].nombre.Equals(nombreBuscado, StringComparison.OrdinalIgnoreCase))
//             {
//                 Console.Write("Ingrese la categoría del producto: ");
//                 productos[i].categoria = Console.ReadLine();

//                 Console.Write("Ingrese el precio del producto: ");
//                 productos[i].precio = Console.ReadLine();

//                 Console.Write("Ingrese la cantidad del producto: ");
//                 productos[i].cantidad = Convert.ToInt32(Console.ReadLine());

//                 encontrado = true;
//                 Console.WriteLine("Producto editado con éxito.");
//                 break;
//             }
//         }
//         if (!encontrado)
//         {
//             Console.WriteLine("Producto no encontrado.");
//         }
//     }

//     static void MostrarProductos(Almacen[] productos, int numProductos)
//     {
//         for (int i = 0; i < numProductos; i++)
//         {
//             Console.WriteLine("-------------------------");
//             Console.WriteLine($"Nombre: {productos[i].nombre}");
//             Console.WriteLine($"Categoría: {productos[i].categoria}");
//             Console.WriteLine($"Precio: {productos[i].precio}");
//             Console.WriteLine($"Cantidad: {productos[i].cantidad}");
//             Console.WriteLine("-------------------------");
//         }
//     }

//     static void MostrarProductosCategoria(Almacen[] productos, int numProductos)
//     {
//         Console.Write("Ingrese la categoría del producto a buscar: ");
//         string categoriaBuscada = Console.ReadLine();

//         for (int i = 0; i < numProductos; i++)
//         {
//             if (productos[i].categoria.Equals(categoriaBuscada, StringComparison.OrdinalIgnoreCase))
//             {
//                 Console.WriteLine("-------------------------");
//                 Console.WriteLine($"Nombre: {productos[i].nombre}");
//                 Console.WriteLine($"Categoría: {productos[i].categoria}");
//                 Console.WriteLine($"Precio: {productos[i].precio}");
//                 Console.WriteLine($"Cantidad: {productos[i].cantidad}");
//                 Console.WriteLine("-------------------------");
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