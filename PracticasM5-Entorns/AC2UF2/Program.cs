using Xunit;

namespace TestDaw;

public class CalculadoraTests
{
    [Fact]
    public void GenerarNumeroAleatorioTest()
    {
        var calculadora = new Calculadora();
        int resultado = calculadora.GenerarNumeroAleatorio();

        Assert.True(resultado >= 0, "Que no sea negativo");
    }

    [Fact]
    public void SumarDosNumerosTest()
    {
        var calculadora = new Calculadora();
        int resultado = calculadora.Sumar(2, 3);

        Assert.Equal(5, resultado); // Comprueba que el resultado sea 5
        Assert.NotEqual(0, resultado); // Verifica que el resultado no sea 0
        Assert.InRange(resultado, 4, 6); // Testea que el resultado este en el rango de 4 a 6
        Assert.True(resultado > 0, "El resultado debe ser positivo"); // Verifica que el resultado sea positivo
        Assert.IsType<int>(resultado); // Hace la prueba de que el resultado sea de tipo int
    }

    [Fact]
    public void RestarDosNumerosTest1()
    {
        var calculadora = new Calculadora();
        int resultado1 = calculadora.Restar(6, 5);

        Assert.Equal(1, resultado1);
        Assert.NotEqual(0, resultado1);
        Assert.InRange(resultado1, 0, 1);
        Assert.True(resultado1 > 0, "Debe ser positivo");
        Assert.IsType<int>(resultado1);

    }

    [Fact]
    public void MultiplicarDosNumerosTest2()
    {
        var calculadora = new Calculadora();
        int resultado2 = calculadora.Multiplicar(3, 3);

        Assert.Equal(9, resultado2);
        Assert.NotEqual(0, resultado2);
        Assert.InRange(resultado2, 8, 10);
        Assert.True(resultado2 > 0, "Número positivo");
        Assert.IsType<int>(resultado2);

    }

    [Fact]
    public void DividirDosNumerosTest3()
    {
        var calculadora = new Calculadora();
        int resultado3 = calculadora.Dividir(20, 10);

        Assert.Equal(2, resultado3);
        Assert.NotEqual(0, resultado3);
        Assert.InRange(resultado3, 1, 3);
        Assert.True(resultado3 > 0, "Tiene que ser positivo");
        Assert.IsType<int>(resultado3);

    }
}

class Calculadora
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hola Mundo");
    }
    // Genera un número aleatorio
    public int GenerarNumeroAleatorio()
    {
        var random = new Random();
        return random.Next(); 
    }
    // Suma dos números
    public int Sumar(int a, int b) => a + b;
    // Resta dos números
    public int Restar(int a, int b) => a - b;
    // Multiplica dos números
    public int Multiplicar(int a, int b) => a * b;
    // Divide dos números
    public int Dividir(int a, int b) => a / b;
}