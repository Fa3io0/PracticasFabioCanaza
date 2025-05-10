public class Arquero : Jugador
{
    public int TurnosParaAtaqueDoble;

    public Arquero(int vida, int nivel, double puntosHabilidad) : base(vida, nivel, puntosHabilidad)
    {
        TurnosParaAtaqueDoble = 0;
    }

    public override int NivelAtaque()
    {
        Random rand = new Random();
        int dado1 = rand.Next(1, 7); 
        int dado2 = rand.Next(1, 7);
        int nivelAtaque = dado1 + dado2 + 3; // Bono de ataque del Arquero por ser Arquero
        System.Console.WriteLine($"Nivel de ataque del Arquero: {nivelAtaque}");
        return nivelAtaque;
    }

    public bool AtaqueDobleArquero(EnemigosCPU enemigo) // Problemas con las habilidades especiales, no funcionan
    // bien, se activan sin tener en cuenta los turnos
    {
        if (TurnosParaAtaqueDoble >= 3)
        {
            int dano = NivelAtaque() * 2;
            enemigo.Vida -= dano;
            System.Console.WriteLine($"¡Ataque doble realizado! Daño infligido: {dano}. Vida restante del enemigo: {enemigo.Vida}");
            TurnosParaAtaqueDoble = 0;
            return true;
        }
        else
        {
            System.Console.WriteLine("La habilidad de ataque doble no está disponible en este turno.");
            TurnosParaAtaqueDoble++;
            return false;
        }
    }
}