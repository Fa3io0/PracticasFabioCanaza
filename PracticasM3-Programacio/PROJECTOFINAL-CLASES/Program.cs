internal class Program
{
    private static void Main(string[] args)
    {  
        Console.Clear();
        bool salir = false;

        while (!salir)
        {
            Jugador personaje = null;
            EnemigosCPU enemigo = new EnemigosBasicos(0, 10, 0);
            JefeFinal jefeFinal1 = new JefeFinal(0, 0, 0);
            DateTime inicioJuego = DateTime.Now;
            int turnos = 0;

            MostrarMenuPrincipal();

            int seleccionPersonaje = Convert.ToInt32(Console.ReadLine());
            switch (seleccionPersonaje)
            {
                case 1:
                    personaje = new Guerrero(12, 1, 2);
                    break;
                case 2:
                    personaje = new Mago(8, 3, 4);
                    break;
                case 3:
                    personaje = new Arquero(10, 2, 3);
                    break;
                case 4:
                    Console.WriteLine("Saliendo...");
                    salir = true;
                    continue;
            }

            if (salir) break;

            while (personaje.Vida > 0)
            {
                System.Console.Clear();
                ConsolaEstilizada.ImprimirConEstilo($"Turno {turnos + 1}", ConsolaEstilizada.TipoMensaje.Info);
                ConsolaEstilizada.ImprimirConEstilo("Tirando los dados", ConsolaEstilizada.TipoMensaje.Info);
                personaje.NivelAtaque();
                // MostrarEstado(personaje, enemigo, inicioJuego);

                ConsolaEstilizada.ImprimirConEstilo("Ha aparecido un enemigo", ConsolaEstilizada.TipoMensaje.Advertencia);

                if (turnos >= 5 && !(enemigo is JefeFinal)) 
                {
                    enemigo = new JefeFinal(15, 20, 5); 
                    System.Console.WriteLine("¡El Jefe Final ha aparecido!");
                }
                else
                {
                    enemigo.VidaAleatoria();
                    enemigo.NivelAleatorio();
                }
                ConsolaEstilizada.ImprimirConEstilo("Preparate para atacar al enemigo", ConsolaEstilizada.TipoMensaje.Enemigo);
                personaje.Atacar(enemigo);

                if (enemigo.Vida > 0)
                {
                    bool ataqueBloqueado = false;

                    if (personaje is Guerrero guerrero)
                    {
                        ataqueBloqueado = guerrero.BloqueoGuerreo(enemigo);
                    }

                    if (!ataqueBloqueado)
                    {
                        System.Console.WriteLine("El enemigo ha atacado al jugador");

                        if (enemigo is JefeFinal jefeFinal)
                        {
                            jefeFinal.DobleAtaque(personaje); 
                            jefeFinal.RegenerarVida(); 
                        }
                        else if (enemigo is EnemigosEspeciales enemigosEspeciales)
                        {
                            enemigosEspeciales.Atacar(personaje);
                            enemigosEspeciales.RecibirDanoConResistencia(enemigosEspeciales.Vida);
                        }
                        else
                        {
                            enemigo.Atacar(personaje);
                        }
                    }
                    else
                    {
                        ConsolaEstilizada.ImprimirConEstilo("El ataque enemigo ha sido bloqueado.", ConsolaEstilizada.TipoMensaje.Exito);
                    }
                }
                else
                {
                    ConsolaEstilizada.ImprimirConEstilo("Has derrotado al enemigo, subes de nivel", ConsolaEstilizada.TipoMensaje.Exito);
                    personaje.PuntosHabilidad += enemigo.ExperienciaDropeada();
                    personaje.LevelUp();
                    
                    enemigo = EnemigosCPU.GenerarEnemigoAleatorio(); 
                    ConsolaEstilizada.ImprimirConEstilo("Pulsa una tecla para continuar...", ConsolaEstilizada.TipoMensaje.Info);
                    Console.ReadKey();
                }

                if (personaje.Vida <= 0)
                {
                    ConsolaEstilizada.ImprimirConEstilo("Has muerto. El juego se reiniciará.", ConsolaEstilizada.TipoMensaje.Error);
                    break; 
                }

                MostrarEstado(personaje, enemigo, inicioJuego);

                ConsolaEstilizada.ImprimirConEstilo("¿Quieres usar una habilidad especial?", ConsolaEstilizada.TipoMensaje.Jugador);
                if (personaje is Arquero)
                {
                    System.Console.WriteLine("1. Ataque doble (disponible cada 3 turnos)");
                }
                else if (personaje is Mago)
                {
                    System.Console.WriteLine("1. Regenerar vida (disponible cada 3 turnos)");
                }
                else if (personaje is Guerrero)
                {
                    System.Console.WriteLine("1. Bloquear un ataque (disponible cada 3 turno)");
                }
                System.Console.WriteLine("2. No usar ninguna habilidad");

                int opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        if (personaje is Arquero arquero)
                        {
                            arquero.AtaqueDobleArquero(enemigo);
                        }
                        else if (personaje is Mago mago)
                        {
                            mago.GenerarVida();
                        }
                        else if (personaje is Guerrero guerrero)
                        {
                            guerrero.BloqueoGuerreo(enemigo);
                        }
                        break;
                    case 2:
                        System.Console.WriteLine("No se usó ninguna habilidad especial.");
                        break;
                    default:
                        System.Console.WriteLine("Opción inválida. No se usó ninguna habilidad.");
                        break;
                }

                turnos++;
            }

            if (personaje.Vida <= 0)
            {
                System.Console.WriteLine("Reiniciando...");
                continue;
            }
        }
    }

    public static void MostrarMenuPrincipal()
    {
        // Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        ConsolaEstilizada.ImprimirConEstilo("Selecciona tu personaje:", ConsolaEstilizada.TipoMensaje.Info);
        Console.ResetColor();
        ConsolaEstilizada.ImprimirConEstilo("1. Jugar como Guerrero", ConsolaEstilizada.TipoMensaje.Sistema);
        ConsolaEstilizada.ImprimirConEstilo("2. Jugar como Mago", ConsolaEstilizada.TipoMensaje.Sistema);
        ConsolaEstilizada.ImprimirConEstilo("3. Jugar como Arquero", ConsolaEstilizada.TipoMensaje.Sistema);
        ConsolaEstilizada.ImprimirConEstilo("4. Salir", ConsolaEstilizada.TipoMensaje.Info);
    }

    public static void MostrarEstado(Jugador personaje, EnemigosCPU enemigo, DateTime inicioJuego)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n--- Resumen del Turno ---");
        Console.ResetColor();

        Console.WriteLine($"Jugador: Vida = {personaje.Vida}, Nivel = {personaje.Nivel}, Puntos de Habilidad = {personaje.PuntosHabilidad}");

        Console.WriteLine($"Enemigo: Vida = {enemigo.Vida}, Nivel = {enemigo.Nivel}");

        if (enemigo is EnemigosEspeciales especial)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Tipo: Enemigo Especial");

            int resistenciaActual = especial.Resistencia - especial.DisminucionResistenciaEnTurnos;
            if (resistenciaActual < 0)
            {
                resistenciaActual = 0;
            }

            Console.WriteLine($"→ Resistencia actual: {resistenciaActual}");
            Console.ResetColor();
        }

        if (enemigo is JefeFinal)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            ConsolaEstilizada.ImprimirConEstilo("⚠ Tipo: ¡Jefe Final!", ConsolaEstilizada.TipoMensaje.Enemigo);
            Console.WriteLine("→ Habilidades: Doble ataque y regeneración de vida cada 3 turnos.");
            Console.ResetColor();
        }

        Console.WriteLine($"Tiempo transcurrido: {(DateTime.Now - inicioJuego):hh\\:mm\\:ss}");
        Console.WriteLine("-------------------------\n");
    }

    public static class ConsolaEstilizada
    {
        public enum TipoMensaje
        {
            Info,
            Advertencia,
            Exito,
            Error,
            Sistema,
            Jugador,
            Enemigo
        }

        public static void ImprimirConEstilo(string mensaje, TipoMensaje tipo = TipoMensaje.Info, int retardoPalabraMs = 150)
        {
            ConsoleColor colorAnterior = Console.ForegroundColor;
            string emoji = "";
            ConsoleColor color;

            switch (tipo)
            {
                case TipoMensaje.Info:
                    color = ConsoleColor.Gray;
                    emoji = "ℹ️";
                    break;
                case TipoMensaje.Advertencia:
                    color = ConsoleColor.Yellow;
                    emoji = "⚠️";
                    break;
                case TipoMensaje.Exito:
                    color = ConsoleColor.Green;
                    emoji = "✅";
                    break;
                case TipoMensaje.Error:
                    color = ConsoleColor.Red;
                    emoji = "❌";
                    break;
                case TipoMensaje.Sistema:
                    color = ConsoleColor.Cyan;
                    emoji = "🛠️";
                    break;
                case TipoMensaje.Jugador:
                    color = ConsoleColor.Blue;
                    emoji = "🧙";
                    break;
                case TipoMensaje.Enemigo:
                    color = ConsoleColor.Magenta;
                    emoji = "👹";
                    break;
                default:
                    color = ConsoleColor.White;
                    break;
            }

            string mensajeFinal = $"{emoji} {mensaje}";
            int ancho = mensajeFinal.Length + 4;

            string bordeSuperior = "╔" + new string('═', ancho) + "╗";
            string lineaMensaje = $"║  {mensajeFinal.PadRight(ancho - 2)}║";
            string bordeInferior = "╚" + new string('═', ancho) + "╝";

            Console.ForegroundColor = color;
            Console.WriteLine(bordeSuperior);
            ImprimirPalabraPorPalabra(lineaMensaje, retardoPalabraMs);
            Console.WriteLine();
            Console.WriteLine(bordeInferior);
            Console.ForegroundColor = colorAnterior;
            Console.WriteLine(); // Espacio después del bloque
        }

        private static void ImprimirPalabraPorPalabra(string texto, int retardoMs)
        {
            string[] palabras = texto.Split(' ');
            foreach (var palabra in palabras)
            {
                Console.Write(palabra + " ");
                Thread.Sleep(retardoMs);
            }
        }
    }
}