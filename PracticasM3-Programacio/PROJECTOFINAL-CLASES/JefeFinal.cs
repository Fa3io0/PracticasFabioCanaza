public class JefeFinal : EnemigosCPU
{
    public int ContadorRegeneracion { get; set; }
    public JefeFinal(int vida, int nivel, int resistencia) : base(vida, nivel, resistencia)
    {
        Vida = vida; // Tiene vida el jefe final pero no muere o no saltan los mensajes de muerte
        Nivel = nivel;
        Resistencia = resistencia;
        DisminucionResistenciaEnTurnos = 0;
    }

    public override int NivelAtaqueEnemigos()
    {
        Random rand = new Random();
        int dado1 = rand.Next(1, 7);
        int dado2 = rand.Next(1, 7);
        int nivelAtaqueEnemigo = dado1 + dado2;

        System.Console.WriteLine($"El Nivel de ataque del JEFE FINAL es de: {nivelAtaqueEnemigo}. Resultado del primer dado = {dado1}, y del segundo dado = {dado2}");
        return nivelAtaqueEnemigo;
    }

    public override void Atacar(Jugador personaje) //Los demas enemigos si que quitan vida al jugador, 
    // pero el jefe final no, no se el porque
    {
        int dano = (int)NivelAtaqueEnemigos();
        personaje.Vida -= dano;
        System.Console.WriteLine($"El enemigo inflige {dano} de daño al jugador. Vida restante del jugador: {personaje.Vida}");

        if (personaje.Vida <= 0)
        {
            System.Console.WriteLine("¡El enemigo te ha matado!");
        }
    }

    public override int ExperienciaDropeada()
    {
        Random rand = new Random();
        int probDropearExperiencia = rand.Next(1, 101);
        if (probDropearExperiencia <= 50)
        {
            System.Console.WriteLine("El enemigo ha dropeado experiencia");
            System.Console.WriteLine("+100 un nivel extra");
            return 1;
        }
        else
        {
            System.Console.WriteLine("El enemigo no ha dropeado experiencia");
            return 0;
        }
    }

    public void DobleAtaque(Jugador jugador)
    {
        Console.WriteLine("¡El Jefe Final realiza un doble ataque!");

        int dano1 = (int)NivelAtaqueEnemigos();
        System.Console.WriteLine($"Primer ataque inflige {dano1} puntos de daño.");
        jugador.Atacar(this);

        int dano2 = (int)NivelAtaqueEnemigos();
        System.Console.WriteLine($"Segundo ataque inflige {dano2} puntos de daño.");
        jugador.Atacar(this);
    }

    public void RegenerarVida() // Despues de varios turnos he echo que se regenere vida, pero no como deberia
    {
        ContadorRegeneracion++;

        if (ContadorRegeneracion >= 3)
        {
            Vida += 2; 
            System.Console.WriteLine("El Jefe Final ha regenerado 4 puntos de vida.");
            ContadorRegeneracion = 0; 
        }
        else
        {
            System.Console.WriteLine("El Jefe Final no ha regenerado vida este turno.");
        }
    }
}