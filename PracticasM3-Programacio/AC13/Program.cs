internal class Program
{
    static void Main()
    {
        Api<Clientes> elemento = new Api<Clientes>();
        elemento.AgregarElemento(new Clientes(1, "Lucia"));
        elemento.AgregarElemento(new Clientes(2, "Ramon"));

        elemento.MostrarElementos();
        elemento.Actualizar(0, new Clientes(3, "Jorge"));
        elemento.EliminarElemento(1);
        elemento.ObtenerElemento(2);

        Api<Empleados> empleado = new Api<Empleados>();
        empleado.AgregarElemento(new Empleados(1, "Dariush"));
        empleado.AgregarElemento(new Empleados(2, "Fabio Joaquin"));

        empleado.MostrarElementos();
        empleado.EliminarElemento(1);
        empleado.ObtenerElemento(2);

        Api<Productos> producto = new Api<Productos>();
        producto.AgregarElemento(new Productos(1, 13, "Pescado"));
        producto.AgregarElemento(new Productos(2, 3, "Huevos"));

        producto.MostrarElementos();
        producto.EliminarElemento(2);
        producto.ObtenerElemento(1);
    }
}

public class Api<T>
{
    private List<T> elementos;
    public Api()
    {
        elementos = new List<T>();
    }

    public void AgregarElemento(T elemento)
    {
        elementos.Add(elemento);
    }

    public void EliminarElemento(int indice)
    {
        if (indice >= 0 && indice < elementos.Count)
        {
            elementos.RemoveAt(indice);
        }
        else
        {
            Console.WriteLine("Índice fuera de rango");
        }
    }

    public T ObtenerElemento(int indice)
    {
        if (indice >= 0 && indice < elementos.Count)
        {
            return elementos[indice];
        }
        else
        {
            Console.WriteLine("índice fuera de rango");
            return elementos[0];
        }
    }

    public void Actualizar(int indice, T elemento)
    {
        if (elementos.Contains(elemento))
        {
            elementos[indice] = elemento;
            Console.WriteLine($"Actualizado: {elemento}");
        }
        else
        {
            Console.WriteLine("Elemento no encontrado para actualizar");
        }
    }

    public void MostrarElementos()
    {
        foreach (var elemento in elementos)
        {
            Console.WriteLine(elemento.ToString());
        }
    }
}

class Persona
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Persona(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Nombre: {Name}";
    }
}

class Clientes : Persona
{
    public Clientes(int id, string name) : base(id, name) {}
}

class Empleados : Persona
{
    public Empleados(int id, string name) : base(id, name) {}
}

class Productos
{
    public int Id { get; set; }
    public string Categoria { get; set; }
    public int Precio { get; set; }

    public Productos(int id, int precio, string categoria)
    {
        Id = id;
        Precio = precio;
        Categoria = categoria;
    }

    public override string ToString() {
        return $"ID: {Id}, Categoría: {Categoria}, Precio: {Precio}";
    }
}