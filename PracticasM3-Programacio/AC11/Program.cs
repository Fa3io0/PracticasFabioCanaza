internal class Program
{
    private static void Main(string[] args)
    {
        Proyecto proyecto = new Proyecto("Limones proyect", "Hacer limonadas para vender", 30, 100);

        proyecto.AnadirEmpleado(new Empleado("Fabio", "444444Z", "CEO", 3000));
        proyecto.AnadirEmpleado(new Empleado("Naomi", "444444F", "dependienta", 2000));

        proyecto.AnadirTarea(new Tarea("hacer un logo", "En progreso", "Diseñar el logo del proyecto"));
        proyecto.AnadirTarea(new Tarea("publicidad", "Pendiente", "Hacer merkating del proyecto"));

        Console.WriteLine($"Nombre del proyecto: {proyecto.Nombre}");
        Console.WriteLine($"Descripción: {proyecto.Descripcion}");
        Console.WriteLine($"Dias restantes: {proyecto.DiasRestantes}");
        proyecto.ListarEmpleados();
        proyecto.ListarTareas();
        Console.WriteLine($"Costo estimado {proyecto.CostoEstimado} euros");
        Console.WriteLine($"Estado: {proyecto.Estado}");
        Console.WriteLine($"Tareas pendientes: {proyecto.TaresPendientes()}");
        Console.WriteLine($"Numero de personas en el proyecto: {proyecto.ContarEmpleados()}");

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

    public void ListarTareas()
    {
        Console.WriteLine("Lista de tareas");
        foreach (var tarea in Tareas)
        {
            Console.WriteLine($"nombre de la tarea: {tarea.Nombre} - estado: {tarea.Estado} - descripcion: {tarea.Descripcion}");
        }
    }

    public void ListarEmpleados()
    {
        Console.WriteLine("Lista empleados");
        foreach (var empleado in Empleados)
        {
            Console.WriteLine($"nombre: {empleado.Nombre} - cargo: {empleado.Cargo} - salario: {empleado.Salario}");
        }
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

public class Persona
{
    public string Nombre { get; set; }
    public string Dni { get; set; }

    public Persona(string nombre, string dni)
    {
        Nombre = nombre;
        Dni = dni;
    }
}

public class Empleado : Persona
{
    public string Cargo { get; set; }
    public int Salario { get; set; }

    public Empleado(string nombre, string dni, string cargo, int salario) : base (nombre, dni)
    {
        Cargo = cargo;
        Salario = salario;
    }
}

public class Cliente : Persona
{
    public int Pagado { get; set; }
    public int Adelanto { get; set; }

    public Cliente(string nombre, string dni, int pagado, int adelanto) : base (nombre, dni)
    {
        Pagado = pagado;
        Adelanto = adelanto;
    }
}

public class Proveedor : Persona
{
    public Proveedor(string nombre, string dni) : base (nombre, dni) {}
}