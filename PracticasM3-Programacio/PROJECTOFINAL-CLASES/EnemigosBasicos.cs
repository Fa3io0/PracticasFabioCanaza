public class EnemigosBasicos : EnemigosCPU
{
    public EnemigosBasicos(int vida, int nivel, int resistencia) : base(vida, nivel, resistencia) {}

    public override int VidaAleatoria()
    {
        Random rand = new Random();
        int VidaEnemigo = rand.Next(5, 13);

        System.Console.WriteLine($"Vida del enemigo: {VidaEnemigo}");
        return VidaEnemigo;
    }

    public override int NivelAleatorio()
    {
        Random rand = new Random();
        int NivelEnemigo = rand.Next(0, 16);

        System.Console.WriteLine($"Nivel del enemigo: {NivelEnemigo}");
        return NivelEnemigo;
    }

    public override int NivelAtaqueEnemigos()
    {
        System.Random rand = new Random();
        int dado1 = rand.Next(1, 7);
        int dado2 = rand.Next(1, 7);
        int nivelAtaqueEnemigo = dado1 + dado2;

        System.Console.WriteLine($"El Nivel de ataque del enemigo es de: {nivelAtaqueEnemigo}. Resultado del primer dado = {dado1}, y del segundo dado = {dado2}");
        return nivelAtaqueEnemigo;
    }

    public override void Atacar(Jugador personaje)
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
            System.Console.WriteLine("+1 un nivel extra");
            return 1;
        }
        else
        {
            System.Console.WriteLine("El enemigo no ha dropeado experiencia");
            return 0;
        }
    }
}