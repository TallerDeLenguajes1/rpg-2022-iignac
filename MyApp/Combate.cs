public class Combate
{
    private Personaje peleador1;
    private Personaje peleador2;
    private int mdp; //maximo danio provocable

    public Combate(Personaje peleador1, Personaje peleador2)
    {
        this.peleador1 = peleador1;
        this.peleador2 = peleador2;
        this.mdp = 200;
    }

    public void pelear()
    {
        int totalRounds=3;
        for (int i = 0; i < totalRounds; i++)
        {
            
            if (peleador1.DatPersonaje.Vivo==true)
            {
                Console.WriteLine($"\n--- Round {Convert.ToInt32(i+1)} FIGHT! ---");
                ataque(peleador1, peleador2);
                if (peleador2.DatPersonaje.Vivo==true)
                {
                    ataque(peleador2, peleador1);
                }
                else
                {
                    break; //i=totalRounds;
                }
            }
            else
            {
                break; //i=totalRounds;
            }
            Console.WriteLine("==> PRESIONE UNA TECLA PARA CONTINUAR <==");
            Console.ReadKey();
        }
    }

    public void ataque(Personaje peleadorX, Personaje peleadorY)
    {
        Console.WriteLine($"\nATACA {peleadorX.DatPersonaje.Nombre}.....");
        double danioProvoc = Math.Round(danioProvocado(peleadorX.valorDeAtaque(), peleadorY.poderDeDefensa()), 2);
        comentarios(peleadorY, danioProvoc);
        if (danioProvoc>0)
        {
            Console.WriteLine($"Danio provocado a {peleadorY.DatPersonaje.Nombre}: {danioProvoc}");
            peleadorY.DatPersonaje.Salud = Math.Round(peleadorY.DatPersonaje.Salud - danioProvoc, 2);
            controlVida(peleadorY);
        }
        Console.WriteLine($"Salud de {peleadorY.DatPersonaje.Nombre}: {peleadorY.DatPersonaje.Salud}");
    }

    public double danioProvocado(double valorAtaqPeleadorX, double poderDefPeleadorY)
    {
        return ((valorAtaqPeleadorX - poderDefPeleadorY)/mdp)*100;
    }

    public void comentarios(Personaje peleador, double danioProvoc)
    {
        Console.Write($"{peleador.DatPersonaje.Nombre} ");
        if (danioProvoc<=0)
        {
            Console.WriteLine("ESQUIVÓ EL ATAQUE COMO UN CAMPEON!!");
        }
        else
        {
            if (danioProvoc<=10)
            {
                Console.WriteLine("RECIBE UN LEVE GOLPE, UN RASGUNIO!! COMO UNA CARICIA DE UNA PLUMA!!");
            }
            else
            {
                if (10<danioProvoc && danioProvoc<=30)
                {
                    Console.WriteLine("RECIBE UN GOLPE MODERADO!! ooouuuch!!");
                }
                else
                {
                    if (30<danioProvoc && danioProvoc<=45)
                    {
                        Console.WriteLine("RECIBE UN GRAN GOLPE!! PA QUE ENTIENDA QUE EL AGUA NO SE MASTICA!!");
                    }
                    else
                    {
                        Console.WriteLine("RECIBE UN TREMEEEEEENDO GOLPAZOOO!! MAS FUERTE QUE CACHETADA DE TRANSFORMER!!");
                    }
                }
            }
        }
    }

    public void controlVida(Personaje peleador)
    {
        if (peleador.DatPersonaje.Salud < 0)
        {
            peleador.DatPersonaje.Salud=0;
            peleador.DatPersonaje.Vivo=false;
        }
        else
        {
            if (peleador.DatPersonaje.Salud == 0)
            {
                peleador.DatPersonaje.Vivo=false;
            }
        }
    }
}