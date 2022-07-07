//namespace Juego

public class Personaje
{
    // campos o variables
    private Datos datPersonaje;
    private Caracteristicas caracPersonaje;  

    public Personaje(){} //constructor vacio para poder deserializar
    
    public Personaje (Datos d, Caracteristicas c) //constructor
    {
        this.datPersonaje = d;
        this.caracPersonaje = c;
    }

    // propiedades
    public Datos DatPersonaje { get => datPersonaje; set => datPersonaje = value; }
    public Caracteristicas CaracPersonaje { get => caracPersonaje; set => caracPersonaje = value; }

    // métodos
    public void mostrarPersonaje()
    {
        Console.WriteLine("--- Datos ---");
        mostrarDatos();
        Console.WriteLine("--- Características ---");
        mostrarCaracteristicas();
    }

    public void mostrarDatos()
    {
        Console.WriteLine("Tipo: " + DatPersonaje.Tipo);
        Console.WriteLine("Nombre: " + DatPersonaje.Nombre);
        Console.WriteLine("Apodo: " + DatPersonaje.Apodo);
        Console.WriteLine("Fecha de nacimiento: " + DatPersonaje.FechaDeNacimiento.ToShortDateString());
        Console.WriteLine("Edad: " + DatPersonaje.Edad);
        Console.WriteLine("Salud: " + DatPersonaje.Salud);
    }

    public void mostrarCaracteristicas()
    {
        Console.WriteLine("Velocidad: " + CaracPersonaje.Velocidad);
        Console.WriteLine("Destreza: " + CaracPersonaje.Destreza);
        Console.WriteLine("Fuerza: " + CaracPersonaje.Fuerza);
        Console.WriteLine("Nivel: " + CaracPersonaje.Nivel);
        Console.WriteLine("Armadura: " + CaracPersonaje.Armadura);
    }

    public double valorDeAtaque()
    {
        Random random = new Random();
        double poderDisparo = CaracPersonaje.Destreza*CaracPersonaje.Fuerza*CaracPersonaje.Nivel;
        double efectividadDisparo = random.Next(1,101); 
        double valorDeAtaque = (poderDisparo*efectividadDisparo)/100; //valor porcentual
        return valorDeAtaque;
    }

    public double poderDeDefensa()
    {
        return CaracPersonaje.Armadura * CaracPersonaje.Velocidad;
    }
}   