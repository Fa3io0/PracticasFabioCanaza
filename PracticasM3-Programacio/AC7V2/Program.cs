// Diseña una estructura llamada "Paciente" que incluya los campos: nombre, edad, diagnóstico 
// y fecha de ingreso. 
// Codifica un array de tamaño 6 para almacenar la información de los pacientes registrados en 
// un hospital. 
// Implementa un menú que permita al usuario: 
// ● Registrar un nuevo paciente. 
// ● Mostrar la lista completa de pacientes y sus datos. 
// ● Buscar un paciente por su nombre y mostrar su información. 
// internal class Ejercicio1
// {
//     private static void Main(string[] args)
//     {
//         Paciente[] pacientes = new Paciente[6];
//         int numPacientes = 0;
//         int opcion;

//         do
//         {
//             Console.WriteLine("Menú:");
//             Console.WriteLine("1. Registrar un nuevo paciente");
//             Console.WriteLine("2. Mostrar la lista completa de pacientes");
//             Console.WriteLine("3. Buscar un paciente por su nombre y mostrar su información");
//             Console.WriteLine("4. Salir");
//             Console.Write("Ingrese su opción: ");
//             opcion = Convert.ToInt32(Console.ReadLine());
//             switch (opcion)
//             {
//                 case 1:
//                     RegistrarPaciente(ref pacientes, ref numPacientes);
//                     break;
//                 case 2:
//                     MostrarPacientes(pacientes, numPacientes);
//                     break;
//                 case 3:
//                     Console.Write("Ingrese el nombre del paciente a buscar: ");
//                     string nombreBuscado = Console.ReadLine();
//                     BuscarPaciente(pacientes, numPacientes, nombreBuscado);
//                     break;
//                 case 4:
//                     Console.WriteLine("Saliendo del programa...");
//                     break;
//                 default:
//                     Console.WriteLine("Opción no válida. Intente de nuevo.");
//                     break;
//             }
//         } while (opcion != 4);
//     }

//     struct Paciente {
//         public string nombre;
//         public int edad;
//         public string diagnostico;
//         public string fechaDeIngreso;
//     }

//     static void RegistrarPaciente(ref Paciente[] pacientes, ref int numPacientes)
//     {
//         if (numPacientes >= 6)
//         {
//             Console.WriteLine("No se pueden registrar más pacientes. El array está lleno.");
//             return;
//         }
//         Paciente nuevoPaciente;
//         Console.Write("Ingrese el nombre del paciente: ");
//         nuevoPaciente.nombre = Console.ReadLine();
//         Console.Write("Ingrese la edad del paciente: ");
//         nuevoPaciente.edad = Convert.ToInt32(Console.ReadLine());
//         Console.Write("Ingrese el diagnóstico del paciente: ");
//         nuevoPaciente.diagnostico = Console.ReadLine();
//         Console.Write("Ingrese la fecha de ingreso del paciente: ");
//         nuevoPaciente.fechaDeIngreso = Console.ReadLine();
//         pacientes[numPacientes++] = nuevoPaciente;
//         Console.WriteLine("Paciente registrado con éxito.");
//     }
//     static void MostrarPacientes(Paciente[] pacientes, int numPacientes)
//     {
//         for (int i = 0; i < numPacientes; i++)
//         {
//             Console.WriteLine($"Nombre: {pacientes[i].nombre}");
//             Console.WriteLine($"Edad: {pacientes[i].edad}");
//             Console.WriteLine($"Diagnóstico: {pacientes[i].diagnostico}");
//             Console.WriteLine($"Fecha de ingreso: {pacientes[i].fechaDeIngreso}");
//             Console.WriteLine("-------------------------");
//         }
//     }
//     static void BuscarPaciente(Paciente[] pacientes, int numPacientes, string nombreBuscado)
//     {
//         bool encontrado = false;
//         for (int i = 0; i < numPacientes; i++)
//         {
//             if (pacientes[i].nombre.Equals(nombreBuscado, StringComparison.OrdinalIgnoreCase))
//             {
//                 Console.WriteLine("-------------------------");
//                 Console.WriteLine($"Nombre: {pacientes[i].nombre}");
//                 Console.WriteLine($"Edad: {pacientes[i].edad}");
//                 Console.WriteLine($"Diagnóstico: {pacientes[i].diagnostico}");
//                 Console.WriteLine($"Fecha de ingreso: {pacientes[i].fechaDeIngreso}");
//                 encontrado = true;
//                 Console.WriteLine("-------------------------");
//                 break;
//             }
//         }
//         if (!encontrado)
//         {
//             Console.WriteLine("Paciente no encontrado.");
//         }
//     }
// }

// Codifica una estructura llamada "Película" que contenga los campos: título, director, género 
// (acción, comedia, drama, etc.) y duración (en minutos). 
// Declara un array bidimensional de tamaño [3,4] para clasificar películas en tres géneros 
// distintos. 
// Implementa un menú con las siguientes opciones: 
// ● Agregar una nueva película en la categoría correspondiente. 
// ● Mostrar todas las películas de un género seleccionado. 
// ● Calcular el promedio de duración de las películas almacenadas en cada género. 
// internal class Ejercicio2
// {
//     private static void Main(string[] args)
//     {
//         Pelicula[,] peliculas = new Pelicula[3, 4];
//         int[] numPeliculas = new int[3];
//         int opcion = 0;

//         do
//         {
//             Console.WriteLine("Menú:");
//             Console.WriteLine("1. Agregar una nueva película");
//             Console.WriteLine("2. Mostrar todas las películas de un género");
//             Console.WriteLine("3. Calcular el promedio de duración de las películas almacenadas en cada género");
//             Console.WriteLine("4. Salir");
//             Console.Write("Ingrese su opción: ");
//             opcion = Convert.ToInt32(Console.ReadLine());
//             switch (opcion)
//             {
//                 case 1:
//                     AgregarPelicula( ref peliculas, ref numPeliculas);
//                     break;
//                 case 2:
//                     MostrarPeliculas(peliculas, numPeliculas);
//                     break;
//                 case 3:
//                     CalcularPromedioDuracion(peliculas, numPeliculas);
//                     break;
//                 case 4:
//                     Console.WriteLine("Saliendo del programa...");
//                     break;
//                 default:
//                     Console.WriteLine("Opcion invalida");
//                     break;
//             }
//         }   while (opcion != 4);
//     }

//     struct Pelicula 
//     {
//         public string titulo;
//         public int duracion;
//         public string director;
//         public string genero;
//     }

//     static void AgregarPelicula(ref Pelicula[,] peliculas, ref int[] numPeliculas)
//     {
//         Console.WriteLine("Seleccione el género de la película:");
//         Console.WriteLine("1. Acción");
//         Console.WriteLine("2. Comedia");
//         Console.WriteLine("3. Drama");
//         int genero = Convert.ToInt32(Console.ReadLine()) - 1;
//         if (genero < 0 || genero > 2 || numPeliculas[genero] >= 4)
//         {
//             Console.WriteLine("No se pueden agregar más películas en este género.");
//             return;
//         }
//         Pelicula nuevaPelicula;
//         Console.Write("Ingrese el título de la película: ");
//         nuevaPelicula.titulo = Console.ReadLine();
//         Console.Write("Ingrese el director: ");
//         nuevaPelicula.director = Console.ReadLine();
//         nuevaPelicula.genero = genero == 0 ? "Acción" : genero == 1 ? "Comedia" : "Drama";
//         Console.Write("Ingrese la duración de la película (en minutos): ");
//         nuevaPelicula.duracion = Convert.ToInt32(Console.ReadLine());
//         peliculas[genero, numPeliculas[genero]++] = nuevaPelicula;
//         Console.WriteLine("Película agregada");
//     }
//     static void MostrarPeliculas(Pelicula[,] peliculas, int[] numPeliculas)
//     {
//         Console.WriteLine("Seleccione el género de las películas:");
//         Console.WriteLine("1. Acción");
//         Console.WriteLine("2. Comedia");
//         Console.WriteLine("3. Drama");
//         int genero = Convert.ToInt32(Console.ReadLine()) - 1;
//         if (genero < 0 || genero > 2)
//         {
//             Console.WriteLine("Género no válido.");
//             return;
//         }
//         Console.WriteLine($"Películas de género {(genero == 0 ? "Acción" : genero == 1 ? "Comedia" : "Drama")}:");
//         for (int i = 0; i < numPeliculas[genero]; i++)
//         {
//             Console.WriteLine($"Título: {peliculas[genero, i].titulo}");
//             Console.WriteLine($"Director: {peliculas[genero, i].director}");
//             Console.WriteLine($"Duración: {peliculas[genero, i].duracion} minutos");
//             Console.WriteLine("-------------------------");
//         }
//     }
//     static void CalcularPromedioDuracion(Pelicula[,] peliculas, int[] numPeliculas)
//     {
//         string[] generos = { "Acción", "Comedia", "Drama" };
//         for (int genero = 0; genero < 3; genero++)
//         {
//             if (numPeliculas[genero] == 0)
//             {
//                 Console.WriteLine($"No hay películas en la categoría {generos[genero]}.");
//                 continue;
//             }
//             int sumaDuraciones = 0;
//             for (int i = 0; i < numPeliculas[genero]; i++)
//             {
//                 sumaDuraciones += peliculas[genero, i].duracion;
//             }
//             double promedio = sumaDuraciones / (double)numPeliculas[genero];
//             Console.WriteLine($"Promedio de duración de las películas de género {generos[genero]}: {promedio:F2} minutos.");
//         }
//     }
// }

// Diseña una estructura llamada "EventoDeportivo" con los campos: nombre del evento, fecha, 
// lugar y número de participantes. 
// Declara un array de tamaño 5 para almacenar información sobre 5 eventos deportivos 
// diferentes. 
// Diseña un menú que permita: 
// ● Agregar un nuevo evento deportivo. 
// ● Mostrar la lista de eventos organizados con sus detalles. 
// ● Buscar un evento por su nombre.

// internal class Ejercicio3
// {
//     private static void Main(string[] args)
//     {
//         EventoDeportivo[] eventos= new EventoDeportivo[5];
//         int numEventos = 0;
//         int opcion;

//         do
//         {
//             Console.WriteLine("Menú: ");
//             Console.WriteLine("1. Agregar un nuevo evento deportivo");
//             Console.WriteLine("2. MOstrar la lista de eventos oraganizados con sus detalles");
//             Console.WriteLine("3. Buscar un evento por su nombre");
//             Console.WriteLine("4. Salir");
//             Console.Write("Ingrese su opción: ");
//             opcion = Convert.ToInt32(Console.ReadLine());
//             switch (opcion)
//             {
//                 case 1:
//                     AgregarEvento(ref eventos, ref numEventos);
//                     break;
//                 case 2:
//                     MostrarEventos(eventos, numEventos);
//                     break;
//                 case 3:
//                     Console.Write("Ingrese el nombre del evento a buscar: ");
//                     string nombreBuscado = Console.ReadLine();
//                     BuscarEvento(eventos, numEventos, nombreBuscado);
//                     break;
//                 case 4:
//                     Console.WriteLine("Saliendo del programa...");
//                     break;
//                 default:
//                     Console.WriteLine("Opción invalida");
//                     break;
//             }
//         }   while (opcion != 4);
//     }

//     struct EventoDeportivo
//     {
//         public string nombreEvento;
//         public string fecha;
//         public string lugar;
//         public int numeroParticipantes;
//     }

//     static void AgregarEvento(ref EventoDeportivo[] eventos, ref int numEventos)
//     {
//         if (numEventos >= 5)
//         {
//             Console.WriteLine("No se pueden agregar más eventos. El calendario de eventos está lleno.");
//             return;
//         }

//         EventoDeportivo nuevoEvento;

//         Console.Write("Ingrese el nombre del evento: ");
//         nuevoEvento.nombreEvento = Console.ReadLine();

//         Console.Write("Ingrese la fecha del evento: ");
//         nuevoEvento.fecha = Console.ReadLine();

//         Console.Write("Ingrese el lugar del evento: ");
//         nuevoEvento.lugar = Console.ReadLine();

//         Console.Write("Ingrese el número de participantes: ");
//         nuevoEvento.numeroParticipantes = Convert.ToInt32(Console.ReadLine());

//         eventos[numEventos++] = nuevoEvento;
//         Console.WriteLine("Evento agregado");
//     }

//     static void MostrarEventos(EventoDeportivo[] eventos, int numEventos)
//     {
//         for (int i = 0; i < numEventos; i++)
//         {
//             Console.WriteLine("-------------------------");
//             Console.WriteLine($"Nombre del evento: {eventos[i].nombreEvento}");
//             Console.WriteLine($"Fecha: {eventos[i].fecha}");
//             Console.WriteLine($"Lugar: {eventos[i].lugar}");
//             Console.WriteLine($"Número de participantes: {eventos[i].numeroParticipantes}");
//             Console.WriteLine("-------------------------");
//         }
//     }

//     static void BuscarEvento(EventoDeportivo[] eventos, int numEventos, string nombreBuscado)
//     {
//         bool encontrado = false;
//         for (int i = 0; i < numEventos; i++)
//         {
//             if (eventos[i].nombreEvento.Equals(nombreBuscado, StringComparison.OrdinalIgnoreCase))
//             {
//                 Console.WriteLine($"Nombre del Evento: {eventos[i].nombreEvento}");
//                 Console.WriteLine($"Fecha: {eventos[i].fecha}");
//                 Console.WriteLine($"Lugar: {eventos[i].lugar}");
//                 Console.WriteLine($"Número de Participantes: {eventos[i].numeroParticipantes}");
//                 encontrado = true;
//                 break;
//             }
//         }
//         if (!encontrado)
//         {
//             Console.WriteLine("Evento no encontrado.");
//         }
//     }
// }

// Crea una estructura llamada "ReservaLibro" con los campos: título del libro, nombre del 
// usuario, fecha de reserva y fecha de devolución. 
// Declara un array de tamaño 7 para registrar las reservas realizadas por los usuarios. 
// Diseña un menú que permita: 
// ● Realizar una nueva reserva (si hay espacio disponible). 
// ● Mostrar todas las reservas realizadas. 
// ● Buscar las reservas de un usuario específico. 
// ● Mostrar cuántos libros están pendientes de devolución. 
// internal class Ejercicio4
// {
//     private static void Main(string[] args)
//     { 
//         ReservaLibro[] libros= new ReservaLibro[7];
//         int numReservas = 0;
//         int opcion;

//         do
//         {
//             Console.WriteLine("Menú: ");
//             Console.WriteLine("1. Agregar una nueva reserva");
//             Console.WriteLine("2. Mostrar todos las reservas realizadas");
//             Console.WriteLine("3. Buscar las reservas de un usuario");
//             Console.WriteLine("4. Mostrar cuántos libros están pendientes de devolución");
//             Console.WriteLine("5. Salir");
//             Console.Write("Ingrese su opción: ");
//             opcion = Convert.ToInt32(Console.ReadLine());
//             switch (opcion)
//             {
//                 case 1:
//                     ReservarLibro(ref libros, ref numReservas);
//                     break;
//                 case 2:
//                     MostrarReservas(libros, numReservas);
//                     break;
//                 case 3:
//                     Console.Write("Ingrese el nombre del usuario a buscar: ");
//                     string nombreBuscado = Console.ReadLine();
//                     BuscarReservas(libros, numReservas, nombreBuscado);
//                     break;
//                 case 4:
//                     MostrarPendientesDevolucion(libros, numReservas);
//                     break;
//                 case 5:
//                     Console.WriteLine("Saliendo del programa...");
//                     break;
//                 default:
//                     Console.WriteLine("Opción invalida");
//                     break;
//             }
//         }   while (opcion != 5);
//     }

//     struct ReservaLibro
//     {
//         public string tituloLibro;
//         public string nombreUsuario;
//         public string fechaReserva;
//         public string fechaDevolucion;
//     }

//     static void ReservarLibro(ref ReservaLibro[] libros, ref int numReservas)
//     {
//         if (numReservas >= 7)
//         {
//             Console.WriteLine("No se pueden agregar más reservas. No hay espacio disponible.");
//             return;
//         }

//         ReservaLibro nuevoLibro;

//         Console.Write("Ingrese el titulo del libro: ");
//         nuevoLibro.tituloLibro = Console.ReadLine();

//         Console.Write("Ingrese la fecha de reserva: ");
//         nuevoLibro.fechaReserva = Console.ReadLine();

//         Console.Write("Ingrese el nombre de usuario: ");
//         nuevoLibro.nombreUsuario = Console.ReadLine();

//         Console.Write("Ingrese la fecha de devolución: ");
//         nuevoLibro.fechaDevolucion = Console.ReadLine();

//         libros[numReservas++] = nuevoLibro;
//         Console.WriteLine("Reserva agregada");
//     }

//     static void MostrarReservas(ReservaLibro[] libros, int numReservas)
//     {
//         for (int i = 0; i < numReservas; i++)
//         {
//             Console.WriteLine("-------------------------");
//             Console.WriteLine($"Nombre del libro: {libros[i].tituloLibro}");
//             Console.WriteLine($"Fecha de Reserva: {libros[i].fechaReserva}");
//             Console.WriteLine($"Nombre de usuario: {libros[i].nombreUsuario}");
//             Console.WriteLine($"Fecha de devolucion: {libros[i].fechaDevolucion}");
//             Console.WriteLine("-------------------------");
//         }
//     }
    
//     static void BuscarReservas(ReservaLibro[] libros, int numReservas, string nombreBuscado)
//     {
//         bool encontrado = false;
//         for (int i = 0; i < numReservas; i++)
//         {
//             if (libros[i].nombreUsuario.Equals(nombreBuscado, StringComparison.OrdinalIgnoreCase))
//             {
//                 Console.WriteLine("-------------------------");
//                 Console.WriteLine($"Titulo del libro: {libros[i].tituloLibro}");
//                 Console.WriteLine($"Fecha de Reserva: {libros[i].fechaReserva}");
//                 Console.WriteLine($"Nombre de usuario: {libros[i].nombreUsuario}");
//                 Console.WriteLine($"Fecha de devolucion: {libros[i].fechaDevolucion}");
//                 encontrado = true;
//                 Console.WriteLine("-------------------------");
//                 break;
//             }
//         }
//         if (!encontrado)
//         {
//             Console.WriteLine("Reserva no encontrada.");
//         }
//     }

//     static void MostrarPendientesDevolucion(ReservaLibro[] libros, int numReservas)
//     {
//         int pendientes = 0;
//         for (int i = 0; i < numReservas; i++)
//         {
//             if (string.IsNullOrEmpty(libros[i].fechaDevolucion))
//             {
//                 pendientes++;
//             }
//         }
//         Console.WriteLine($"Cantidad de libros pendientes de devolución: {pendientes}");
//     }
// }