using Xunit;
namespace TestDaw
{
    internal class Program
    {
        private static void Main(string[] args) {}
    }

    public class Calculadora
    {
        // Suma dos números
        public int Sumar(int a, int b) => a + b;
        // Resta dos números
        public int Resta(int a, int b) => a - b;
        // Devuelve true si el número es par
        public bool EsPar(int n) => n % 2 == 0;
        // Devuelve el mayor de dos números
        public int Maximo(int a, int b) => a > b ? a : b;
        // Invierte una cadena de texto
        public string Invertir(string texto) => new string(texto.Reverse().ToArray());
        // Devuelve la inicial de un nombre (primer carácter en mayúscula)
        public char Inicial(string nombre) => char.ToUpper(nombre[0]);
    }

    public class CalculadoraTests
    {
        [Fact]
        public void SumarDosNumerosTest()
        {
            var calculadora = new Calculadora();
            int resultado = calculadora.Sumar(2, 3);

            Assert.Equal(5, resultado);
            Assert.NotEqual(0, resultado);
            Assert.InRange(resultado, 4, 6);
            Assert.True(resultado > 0, "El resultado debe ser positivo");
            Assert.IsType<int>(resultado);
        }
        
        [Fact]
        public void Resta_Equal()
        {
            var calc = new Calculadora();
            int resultado = calc.Resta(8, 5);
            // Assert.Equal: verifica que el resultado sea exactamente 3
            Assert.Equal(3, resultado);
        }

        [Fact]
        public void EsPar_True()
        {
            var calc = new Calculadora();
            // Assert.True: verifica que EsPar(4) devuelve true
            Assert.True(calc.EsPar(4));
        }

        [Fact]
        public void Maximo_NotEqual()
        {
            var calc = new Calculadora();
            int max = calc.Maximo(10, 5);
            // Assert.NotEqual: verifica que el máximo no es 5
            Assert.NotEqual(5, max);
        }

        [Fact]
        public void Invertir_NotNull()
        {
            var calc = new Calculadora();
            string invertida = calc.Invertir("hola");
            // Assert.NotNull: verifica que la cadena invertida no es null
            Assert.NotNull(invertida);
        }

        [Fact]
        public void Inicial_Contains()
        {
            var calc = new Calculadora();
            char inicial = calc.Inicial("fabio");
            // Assert.Contains: verifica que la inicial esta en el conjunto de letras mayusculas
            Assert.Contains(inicial, "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
        }
    }
}