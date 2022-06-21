using Juego;

List<Personaje>listaPeleadores = new List<Personaje>();
//var listaPeleadores = new List<Personaje>();
Personaje nuevoPersonaje;
Datos nuevosDatos;
Caracteristicas nuevasCaracteristicas;
int cantPeleadores;

do
{
    Console.WriteLine("\n==> Ingrese la cantidad de peleadores que participarán en la masacre (>= 2): ");
    cantPeleadores = Convert.ToInt32(Console.ReadLine()); 
} while (cantPeleadores < 2);

// creo los personajes y los agrego a la lista
for (int i = 0; i < cantPeleadores; i++)
{
    nuevosDatos = new Datos();
    nuevasCaracteristicas = new Caracteristicas();
    nuevoPersonaje = new Personaje(nuevosDatos, nuevasCaracteristicas);
    // nuevoPersonaje = new Personaje(new Datos(), new Caracteristicas());
    listaPeleadores.Add(nuevoPersonaje);
}

// muestro la lista
Console.WriteLine("\n==> LOS PELEADORES SON:");
mostrarlista();

Console.WriteLine("\nCOMIENZA EL MORTALKOMBAT MAS EPICO DE TODO EL WORLD");
int combate = 1;
double dañoProvoc;
do
{
    int cantAtaques = 3;
    Console.WriteLine($"\n==> COMBATE {combate}: {listaPeleadores[0].DatPersonaje.Nombre} VS {listaPeleadores[1].DatPersonaje.Nombre}");
    combate++;
    do
    {
        ataque(listaPeleadores[0], listaPeleadores[1]);
        ataque(listaPeleadores[1], listaPeleadores[0]);
        cantAtaques--;
    } while (cantAtaques > 0);
    eliminarPerdedor();
    Console.WriteLine("\n==> GANADOR DEL COMBATE!!!: " + listaPeleadores[0].DatPersonaje.Nombre);   
    if (listaPeleadores.Count > 1)
    {
        mejorarGanador();
    }
} while (listaPeleadores.Count > 1);

Console.WriteLine($"\n==> EL VENCEDOR DEL TORNEO Y GANADOR DEL TRONO DE HIERRO ES: ");
listaPeleadores[0].mostrarDatos();
Console.WriteLine("\nFELICITACIONES CAMPEÓN!!!!!!!!!!!");



///// FUNCIONES

void mostrarlista()
{
    for (int i = 0; i < listaPeleadores.Count; i++)
    {
        Console.WriteLine("\n### Personaje " + Convert.ToInt32(i+1) + " ###");
        listaPeleadores[i].mostrarPersonaje();
    }
}

void ataque(Personaje personaje1, Personaje personaje2)
{
    Console.WriteLine($"\nATACA {personaje1.DatPersonaje.Nombre}!");
    dañoProvoc = dañoProvocado(personaje1, personaje2);
    if (dañoProvoc < 0)
    {
        dañoProvoc = Math.Abs(dañoProvoc);
        Console.WriteLine($"{personaje2.DatPersonaje.Nombre} ESQUIVÓ EL ATAQUE Y COONTRATACÓ!!");
        Console.WriteLine($"DAÑO PROVOCADO A {personaje1.DatPersonaje.Nombre}: {dañoProvoc}");
        personaje1.DatPersonaje.Salud = Convert.ToDouble(personaje1.DatPersonaje.Salud - dañoProvoc);
        Console.WriteLine($"SALUD DE {personaje1.DatPersonaje.Nombre}: {personaje1.DatPersonaje.Salud}");
    }
    else
    {
        Console.WriteLine($"DAÑO PROVOCADO A {personaje2.DatPersonaje.Nombre}: {dañoProvoc}");
        personaje2.DatPersonaje.Salud = Convert.ToDouble(personaje2.DatPersonaje.Salud - dañoProvoc);
        Console.WriteLine($"SALUD DE {personaje2.DatPersonaje.Nombre}: {personaje2.DatPersonaje.Salud}");
    }
    Console.WriteLine("------------------");
}

double dañoProvocado(Personaje personaje1, Personaje personaje2)
{
    return ((personaje1.valorDeAtaque() - personaje2.valorDeDefensa())/500)*100;
}

void eliminarPerdedor()
{
    if (listaPeleadores[0].DatPersonaje.Salud == listaPeleadores[1].DatPersonaje.Salud)
    {
        Console.WriteLine("\n==>EL COMBATE FINALIZÓ EMPATADO, deberás sacrificar a un peleador :(");
        Console.WriteLine($"(1){listaPeleadores[0].DatPersonaje.Nombre}, (2){listaPeleadores[1].DatPersonaje.Nombre}");
        int opcion=0; 
        do
        {
            opcion = Convert.ToInt32(Console.ReadLine());
        } while (opcion<1 && opcion>2);
        if (opcion==1)
        {
            listaPeleadores.Remove(listaPeleadores[0]);
        }
        else
        {
            listaPeleadores.Remove(listaPeleadores[1]);
        }
    }
    else
    {
        if (listaPeleadores[0].DatPersonaje.Salud > listaPeleadores[1].DatPersonaje.Salud)
        {
            listaPeleadores.Remove(listaPeleadores[1]);
        }
        else
        {
            listaPeleadores.Remove(listaPeleadores[0]);
        }
    }
}

void mejorarGanador()
{
    listaPeleadores[0].DatPersonaje.Salud = 110; // recupera su salud y se le suma 10
    listaPeleadores[0].CaracPersonaje.Fuerza = listaPeleadores[0].CaracPersonaje.Fuerza + Convert.ToInt32(listaPeleadores[0].CaracPersonaje.Fuerza * 0.1); // aumenta un 10% en fuerza
    listaPeleadores[0].CaracPersonaje.Velocidad += 2; // aumenta 2 en velocidad;
}