// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Linq;

// internal class Program
// {
//     private static void Main(string[] args)
//     {
//         Mensajes mens = new Mensajes();

//         File.WriteAllLines("mensajes.txt", new List<string>
//         {
//             "obiwan;para anakin;Anakin my alligence is with the republic with the democracy",
//             "vader;para obiwan;im not your failure obi-wan",
//             "anakin;para obiwan;if youre not with me then youre my enemy",
//         });

//         mens.AnadirMensajeLocal("c3po", "para r2d2", "A veces simplemente no entiendo el comportamiento humano");
//         mens.AnadirMensajeLocal("obiwan", "para anikan", "Only a sith deals in absoluts, I wil do what a must");
//         mens.ListarUsuarios();
//         mens.LeerMensajePorUsuario("c3po");
//         mens.LeerTodosLosMensajesLocales();
//         mens.PasarMensajesAlArchivo();
//         mens.LeerMensajesDesdeArchivo();
//     }
// }
// class Mensajes
// {
//     private List<string> mensajesLocales = new List<string>();
//     private string archivoMensajes = "mensajes.txt";

//     public void AnadirMensajeLocal(string usuario, string asunto, string mensaje)
//     {
//         mensajesLocales.Add($"{usuario};{asunto};{mensaje}");
//         Console.WriteLine("Mensaje agregado al local");
//     }

//     public void ListarUsuarios()
//     { 
//         List<string> usuarios = new List<string>();

//         foreach (var user in mensajesLocales)
//         {
//             string[] datos = user.Split(";");
//             string usuario = datos[0];
//             if (!usuarios.Contains(usuario))
//             {
//                 usuarios.Add(usuario);
//             }
//         }

//         foreach (var usuario in usuarios)
//         {
//             Console.WriteLine(usuario);
//         }
//     }

//     public void LeerMensajePorUsuario(string usuario)
//     {
//         List<string> mensajes = new List<string>();

//         for (int i = 0; i < mensajesLocales.Count; i++)
//         {
//             if (mensajesLocales[i].StartsWith(usuario + ";"))
//             {
//                 mensajes.Add(mensajesLocales[i]);
//             }
//         }

//         Console.WriteLine($"mensaje para {usuario}:");
//         foreach (var mensaje in mensajes)
//         {
//             string[] partes = mensaje.Split(";");
//             Console.WriteLine($"asunto: {partes[1]}, mensaje: {partes[2]}");
//         }
//     }

//     public void LeerTodosLosMensajesLocales()
//     {
//         Console.WriteLine("mensaje locales");
//         foreach (var mensaje in mensajesLocales)
//         {
//             string[] partes = mensaje.Split(";");
//             Console.WriteLine($"{partes[0]}, asunto: {partes[1]}, {partes[2]}");
//         }
//     }

//     public void PasarMensajesAlArchivo()
//     {
//         File.AppendAllLines(archivoMensajes, mensajesLocales);
//         mensajesLocales.Clear();
//         Console.WriteLine("Mensajes locales pasados al archivo");
//     }

//     public void LeerMensajesDesdeArchivo()
//     {
//         StreamReader reader = new StreamReader("mensajes.txt");

//         bool opcion = true;

//         Console.WriteLine("Mensajes de archivo:");
//         while (opcion)
//         {
//             string linea = reader.ReadLine();
//             if (linea != null && linea != "")
//             {
//                 Console.WriteLine(linea);

//             }else
//             {
//                 opcion = false;
//             }
//         }
//         reader.Close();      
//     }
// }

using System;
using System.Collections.Generic;
using System.IO;

internal class Program
{
    private static void Main(string[] args)
    {
        string archivo = "libros.txt";
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("Menú:");
            Console.WriteLine("1. Añadir libros");
            Console.WriteLine("2. Mostrar libros");
            Console.WriteLine("3. Borrar libros");
            Console.WriteLine("4. Salir");
            Console.Write("Selecciona una opcion: ");
            
            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    nuevoLibro(archivo);
                    break;
                case 2:
                    LibrosPorAutor(archivo);
                    break;
                case 3:
                    BorrarLibros(archivo);
                    break;
                case 4:
                    salir = true;
                    break;
                default:
                    Console.WriteLine("intenta otra vez");
                    break;
            }
        }
    }

    private static void nuevoLibro(string archivo)
    {
        List<string> libros = new List<string>();

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("título? ");
            string titulo = Console.ReadLine();
            Console.WriteLine("autor? ");
            string autor = Console.ReadLine();
            Console.WriteLine("isbn? ");
            string isbn = Console.ReadLine();

            libros.Add($"{titulo};{autor};{isbn}");
        }

        using (StreamWriter libreria = new StreamWriter(archivo, true))
        {
            foreach (var libro in libros)
            {
                libreria.WriteLine(libro);
            }
        }
    }

    private static void LibrosPorAutor(string archivo)
    {
        List<string> libros = new List<string>();

        string linea;

        using (StreamReader libreria = new StreamReader(archivo))
        {
            while ((linea = libreria.ReadLine()) != null)
            {
                libros.Add(linea);
            }
        }

        libros.Sort(PorAutores);

        foreach (var libro in libros)
        {
            string[] datosLibro = libro.Split(';');

            Console.WriteLine("título: {0}", datosLibro[0]);
            Console.WriteLine("autor: {0}", datosLibro[1]);
            Console.WriteLine("isbn: {0}", datosLibro[2]);
        }
    }

    private static int PorAutores(string libro1, string libro2)
    {
        string autor1 = libro1.Split(';')[1];
        string autor2 = libro2.Split(';')[1];

        int i = 0;

        while (i < autor1.Length && i < autor2.Length)
        {
            if (autor1[i] < autor2[i])
            {
                return -1;
            }
            else if (autor1[i] > autor2[i])
            {
                return 1;
            }

            i++;
        }

        if (autor1.Length < autor2.Length)
        {
            return -1;
        }
        else if (autor1.Length > autor2.Length)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    private static void BorrarLibros(string archivo)
    {
        using (StreamWriter libreria = new StreamWriter(archivo, false))
        {
            libreria.Write("");
        }
        Console.WriteLine("libros borrados");
    }
}