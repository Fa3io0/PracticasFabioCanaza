public class Jugador 
{
    public int Vida { get; set; }
    public int Nivel { get; set; }
    public double PuntosHabilidad { get; set; }

    public Jugador(int vida, int nivel, double puntosHabilidad)
    {
        Vida = vida;
        Nivel = nivel;
        PuntosHabilidad = puntosHabilidad;
    }

    public virtual int NivelAtaque()
    {
        Random rand = new Random();
        int dado1 = rand.Next(1, 7); 
        int dado2 = rand.Next(1, 7);
        int nivelAtaque = dado1 + dado2;
        System.Console.WriteLine($"Nivel de ataque: {nivelAtaque}");
        return nivelAtaque;
    }

    public virtual void IncrementarPuntosHabilidad(int nivelAtaque)
    {
        PuntosHabilidad += nivelAtaque * 0.1;
        System.Console.WriteLine($"Puntos de habilidad incrementados: {PuntosHabilidad}");
    }

    public void LevelUp()
    {
        Nivel++;
        System.Console.WriteLine($"¡Has subido de nivel! Nivel actual: {Nivel}");
    }

    public virtual void Atacar(EnemigosCPU enemigo)
    {
        int dano = NivelAtaque();
        enemigo.Vida -= dano;
        System.Console.WriteLine($"Has infligido {dano} de daño al enemigo. Vida restante del enemigo: {enemigo.Vida}");
    }
}