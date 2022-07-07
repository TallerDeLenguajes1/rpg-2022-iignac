//namespace Juego

public class Caracteristicas
{   
    Random random = new Random();
    
    // campos o variables
    private int velocidad; //1 a 10
    private int destreza; //1 a 5
    private int fuerza; //1 a 10
    private int nivel; //1 a 10
    private int armadura; //1 a 10

    // constructor
    public Caracteristicas()
    {   
        this.velocidad = random.Next(1, 11);
        this.destreza = random.Next(1, 6);
        this.Fuerza = random.Next(1,11);
        this.nivel = random.Next(1,11);
        this.armadura = random.Next(1,11);
    }

    // propiedades
    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Armadura { get => armadura; set => armadura = value; }
}  