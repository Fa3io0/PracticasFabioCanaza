internal class Program
{
    private static void Main(string[] args)
    {
        Base naves = new Base("Motor encendido. Estrella de la muerte lista para desplegar."
        , "Poniendo rumbo a Namek." 
        , "Aterrizando Estrella de la muerte. ¡Hemos llegado!");
        naves.estadoMotorDeLaNaveBase();
        naves.iniciarMision();
        naves.apagarMotor();
        
        Intermedia naves1 = new Intermedia("Sistemas inicializados.", "Potencia de los rayos al 77,7%."
        , "Poniendo rumba a Namek a realizar la mision" 
        , "Desactivando modo de combate.");
        naves1.estadoMotorDeLaNaveBase();
        naves1.potenciaFuego();
        naves1.apagarMotor();

        Derivada naves2 = new Derivada("Motor encendido", "33,33% de potencia de rayos."
        , "Un combate padre e hijo está por comenzar"
        , 1000000
        , "Poniendo rumba a Namek a realizar la mision" 
        , "Nave de Carga totalmente destruida");
        naves2.estadoMotorDeLaNaveBase();
        naves2.potenciaFuego();
        naves2.SituacionDentroDeLaNave();
        naves2.PesoDentroDeLaNave();
        naves2.apagarMotor();
    }
}

public class Base
{
    public string EncenderMotor { get; set; }
    public string IniciarMision { get; set; }
    public string ApagarMotor { get; set; }

    public Base(string encenderMotor, string iniciarMision, string apagarMotor)
    {
        EncenderMotor = encenderMotor;
        IniciarMision = iniciarMision;
        ApagarMotor = apagarMotor;
    }

    
    public virtual void estadoMotorDeLaNaveBase()
    {
        Console.WriteLine();
        Console.WriteLine("Estado del motor de la Nave Basica (Estrella de la Muerte) es: " + EncenderMotor);
    }

    public virtual void iniciarMision()
    {
        Console.WriteLine("Nave basica preparandose para una nueva misión. " + IniciarMision);
    }

    public virtual void apagarMotor()
    {
        Console.WriteLine("Apagen motores e inicien aterrizage. " + ApagarMotor);
        Console.WriteLine();
    }
}

public class Intermedia : Base
{
    public string PotenciaDeFuego { get; set; }

    public Intermedia(string encenderMotor, string potenciaDeFuego,  
    string iniciarMision, string apagarMotor) : base(encenderMotor, iniciarMision, apagarMotor)
    {
        PotenciaDeFuego = potenciaDeFuego;
    }

    public override void estadoMotorDeLaNaveBase()
    {
        Console.WriteLine("Estado del motor de la Nave de Combate es: " + EncenderMotor);
    }

    public virtual void potenciaFuego()
    {
        Console.WriteLine("La potencia de la estrella de la Muerte es: " + PotenciaDeFuego);
    }

    public override void apagarMotor()
    {
        Console.WriteLine("Estado de la Nave de Combate: " + ApagarMotor);
        Console.WriteLine();
    }
}

public class Derivada : Intermedia
{
    private string Situacion { get; set;}
    private int Peso { get; set; }

    public Derivada( string encenderMotor, string potenciaDeFuego, string situacion, int peso,
    string iniciarMision, string apagarMotor) : base(encenderMotor, potenciaDeFuego, iniciarMision, apagarMotor)
    {
        Situacion = situacion;
        Peso = peso;
    }

    public override void estadoMotorDeLaNaveBase()
    {
        Console.WriteLine("Estado del motor de la Nave de Carga es: " + EncenderMotor);
    }

    public override void potenciaFuego()
    {
        Console.WriteLine("La potencia ha disminuido ahora es de: " + PotenciaDeFuego);
    }

    public void SituacionDentroDeLaNave()
    {
        Console.WriteLine("Anakin y Luke se encuentran por primera vez: " + Situacion);
    }

    public void PesoDentroDeLaNave()
    {
        Console.WriteLine($"La Estrella de la Muerte transporta, solo en naves, mas de {Peso} toneladas");
    }

    public override void apagarMotor()
    {
        Console.WriteLine("Estado de la Nave de Carga: " + ApagarMotor);
        Console.WriteLine();
    }
}