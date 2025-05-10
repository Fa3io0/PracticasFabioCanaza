public class EnemigosCPU
{
    public int Vida { get; set; }
    public int Nivel { get; set; }
    public int Resistencia { get; set; }
    public int DisminucionResistenciaEnTurnos;

    public EnemigosCPU(int vida, int nivel, int resistencia)
    {
        Vida = vida;
        Nivel = nivel;
        Resistencia = resistencia;
        DisminucionResistenciaEnTurnos = 0;
    }

    public virtual int VidaAleatoria()
    {
        Random rand = new Random();
        int VidaEnemigo = rand.Next(5, 13);

        System.Console.WriteLine($"Vida del enemigo: {VidaEnemigo}");
        return VidaEnemigo;
    }

    public virtual int NivelAleatorio()
    {
        Random rand = new Random();
        int NivelEnemigo = rand.Next(0, 16);

        System.Console.WriteLine($"Nivel del enemigo: {NivelEnemigo}");
        return NivelEnemigo;
    }

    public virtual int NivelAtaqueEnemigos()
    {
        Random rand = new Random();
        int dado1 = rand.Next(1, 7);
        int dado2 = rand.Next(1, 7);
        int nivelAtaqueEnemigo = dado1 + dado2;

        System.Console.WriteLine($"Nivel de ataque del enemigo: {nivelAtaqueEnemigo}. Dado 1: {dado1}, Dado 2: {dado2}");
        return nivelAtaqueEnemigo;
    }

    public virtual void Atacar(Jugador personaje) 
    {
        int dano = NivelAtaqueEnemigos(); 
        personaje.Vida -= dano; 
        System.Console.WriteLine($"El enemigo inflige {dano} de daño al jugador. Vida restante del jugador: {personaje.Vida}");

        if (personaje.Vida <= 0)
        {
            System.Console.WriteLine("¡El enemigo te ha matado!");
        }
    }

    public virtual int ExperienciaDropeada()
    {
        Random rand = new Random();
        int probDropearExperiencia = rand.Next(1, 101);
        if (probDropearExperiencia <= 50)
        {
            System.Console.WriteLine("El enemigo ha dropeado experiencia");
            System.Console.WriteLine("+1 un nivel extra");
            return 1;
        }
        else
        {
            System.Console.WriteLine("El enemigo no ha dropeado experiencia");
            return 0;
        }
    }

    public static EnemigosCPU GenerarEnemigoAleatorio()
    {
        Random rand = new Random();
        int tipo = rand.Next(0, 2); 

        if (tipo == 0)
        {
            System.Console.WriteLine("¡Ha aparecido un enemigo básico!");
            return new EnemigosBasicos(7, 6, 0);
        }
        else 
        {
            Console.WriteLine("¡Ha aparecido un enemigo especial!");
            return new EnemigosEspeciales(10, 10, 2);
        }
    }

    public virtual void RecibirDanoConResistencia(int danoBase) // No se si esta bien implementada
    {
        int resistenciaActual = Resistencia - DisminucionResistenciaEnTurnos;
        if (resistenciaActual < 0)
        {
            resistenciaActual = 0;
        }

        int danoFinal = danoBase - resistenciaActual;
        if (danoFinal < 0)
        {
            danoFinal = 0;
        }

        Vida -= danoFinal;
        DisminucionResistenciaEnTurnos++;

        System.Console.WriteLine($"Resistencia actual del enemigo: {resistenciaActual}");
        System.Console.WriteLine($"Daño recibido {danoFinal} (resistencia de {resistenciaActual}). Vida restante: {Vida}");
    }
}
