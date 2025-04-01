internal class Program
{
    private static void Main(string[] args)
    {
        Proyecto proyecto = new Proyecto(
            "Limoes proyect",
            "Hacer limonadas para vender",
            30,
            100
        );

        proyecto.AnadirEmpleado(new Empleado("Fabio", "Desarrollador", 3000));
        proyecto.AnadirEmpleado(new Empleado("Naomi", "Diseñadora", 2500));

        proyecto.AnadirTarea(new Tarea("Fabio", "En progreso", "Diseñar el logo del proyecto"));
        proyecto.AnadirTarea(new Tarea("Naomi", "Pendiente", "Crear la API del proyecto"));

        Console.WriteLine($"Nombre del proyecto {proyecto.Nombre}");
        Console.WriteLine($"Descripción {proyecto.Descripcion}");
        Console.WriteLine($"Dias restantes {proyecto.DiasRestantes}");
        Console.WriteLine($"Costo estimado {proyecto.CostoEstimado}");
        Console.WriteLine($"Estado {proyecto.Estado}");
        Console.WriteLine($"Tareas pendientes {proyecto.TaresPendientes()}");
        Console.WriteLine($"Numero de empleados {proyecto.ContarEmpleados()}");

        proyecto.Cliente = new Cliente("Tenoch", "55531099Z", 5000, 1000);
        Console.WriteLine($"Cliente {proyecto.Cliente.Nombre}, dni {proyecto.Cliente.Dni}");
        Console.WriteLine($"Pagado {proyecto.Cliente.Pagado}, adelanto {proyecto.Cliente.Adelanto}");

        proyecto.AnadirProveedor(new Proveedor("Sancho", "00000000B"));
        proyecto.AnadirProveedor(new Proveedor("Panzo", "11111111C"));

        foreach (var proveedor in proyecto.Proveedores)
        {
            Console.WriteLine($"Proveedor {proveedor.Nombre}, dni {proveedor.Dni}");
        }
    }
}

public class Proyecto
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public int DiasRestantes { get; set; }
    public decimal CostoEstimado { get; set; }
    public string Estado { get; set; }
    public List<Empleado> Empleados { get; set; }
    public List<Tarea> Tareas { get; set; }
    public Cliente Cliente { get; set; }
    public List<Proveedor> Proveedores { get; set; }

    public Proyecto(string nombre, string descripcion, int diasRestantes, decimal CostoDiaria)
    {
        Nombre = nombre;
        Descripcion = descripcion;
        DiasRestantes = diasRestantes;
        CostoEstimado = diasRestantes * CostoDiaria;
        Estado = "En progreso";
        Empleados = new List<Empleado>();
        Tareas = new List<Tarea>();
        Proveedores = new List<Proveedor>();
    }

    public void AnadirEmpleado(Empleado Empleado)
    {
        Empleados.Add(Empleado);
    }

    public void AnadirTarea(Tarea Tarea)
    {
        Tareas.Add(Tarea);
    }

    public int TaresPendientes()
    {
        int count = 0;
        foreach (var tarea in Tareas)
        {
            if (tarea.Estado == "Pendiente")
            {
                count++;
            }
        }
        return count;
    }

    public int ContarEmpleados()
    {
        return Empleados.Count;
    }

    public void AnadirProveedor(Proveedor proveedor)
    {
        Proveedores.Add(proveedor);
    }
}

public class Empleado
{
    public string Nombre { get; set; }
    public string Cargo { get; set; }
    public int Salario { get; set; }

    public Empleado(string nombre, string cargo, int salario)
    {
        Nombre = nombre;
        Cargo = cargo;
        Salario = salario;
    }
}

public class Tarea
{
    public string Nombre { get; set; }
    public string Estado { get; set; }
    public string Descripcion { get; set; }

    public Tarea(string nombre, string estado, string descripcion)
    {
        Nombre = nombre;
        Estado = estado;
        Descripcion = descripcion;
    }
}

public class Cliente
{
    public string Nombre { get; set; }
    public string Dni { get; set; }
    public int Pagado { get; set; }
    public int Adelanto { get; set; }

    public Cliente(string nombre, string dni, int pagado, int adelanto)
    {
        Nombre = nombre;
        Dni = dni;
        Pagado = pagado;
        Adelanto = adelanto;
    }
}

public class Proveedor
{
    public string Nombre { get; set; }
    public string Dni { get; set; }

    public Proveedor(string nombre, string dni)
    {
        Nombre = nombre;
        Dni = dni;
    }
}