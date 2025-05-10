public class Guerrero : Jugador
{
    public int TurnosDeBloqueo;

    public Guerrero(int vida, int nivel, double puntosHabilidad) : base(vida, nivel, puntosHabilidad)
    {
        TurnosDeBloqueo = 0;
    }

    public override int NivelAtaque()
    {
        Random rand = new Random();
        int dado1 = rand.Next(1, 7); 
        int dado2 = rand.Next(1, 7);
        int nivelAtaque = dado1 + dado2 + 2; // Bono de ataque del Guerrero por ser Guerrero
        System.Console.WriteLine($"Nivel de ataque del Guerrero: {nivelAtaque}");
        return nivelAtaque;
    }

    public bool BloqueoGuerreo(EnemigosCPU enemigo) // Problemas con las habilidades especiales
    {
        if (TurnosDeBloqueo >= 3)
        {
            System.Console.WriteLine($"Has bloqueado el ataque del enemigo quitando -3 de vida. Vida restante del enemigo: {enemigo.Vida}");
            enemigo.Vida -= 3;
            TurnosDeBloqueo = 0;
            return true;
        }
        else
        {
            System.Console.WriteLine("La habilidad de bloqueo no está disponible en este turno.");
            TurnosDeBloqueo++;
            return false;
        }
    }
}