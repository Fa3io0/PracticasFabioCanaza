public class Mago : Jugador
{
    public int TurnosParaGenerarVida;

    public Mago(int vida, int nivel, double puntosHabilidad) : base(vida, nivel, puntosHabilidad)
    {
        TurnosParaGenerarVida = 0;
    }

    public override int NivelAtaque()
    {
        Random rand = new Random();
        int dado1 = rand.Next(1, 7); 
        int dado2 = rand.Next(1, 7);
        int nivelAtaque = dado1 + dado2 + 4; // Bono de ataque del Mago por ser Mago
        System.Console.WriteLine($"Nivel de ataque del Mago: {nivelAtaque}");
        return nivelAtaque;
    }

    public bool GenerarVida() // Problemas con las habilidades especiales, sobretodo con la regeneración de vida
    // las otras dos funcionan en varios turnos, pero esta no, ni una vez
    {
        if (TurnosParaGenerarVida >= 3)
        {
            Vida += 2;
            System.Console.WriteLine($"¡Has regenerado 2 puntos de vida! Vida actual: {Vida}");
            TurnosParaGenerarVida = 0;
            return true;
        }
        else
        {
            System.Console.WriteLine("La habilidad de regeneración no está disponible en este turno.");
            TurnosParaGenerarVida++;
            return false;
        }
    }
}