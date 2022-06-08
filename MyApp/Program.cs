using Juego;

List<Personaje>listaPeleadores = new List<Personaje>();
Personaje nuevoPersonaje;
Datos nuevosDatos;
Caracteristicas nuevasCaracteristicas;

System.Console.WriteLine("COMIENZA EL MORTALKOMBAT MAS EPICO DE TODO EL WORLD");
Console.WriteLine("\nIngrese la cantidad de peleadores que participarán en la masacre: ");
int cantPeleadores = Convert.ToInt32(Console.ReadLine());

// creo los personajes y los agrego a la lista
for (int i = 0; i < cantPeleadores; i++)
{
    nuevosDatos = new Datos();
    nuevasCaracteristicas = new Caracteristicas();
    nuevoPersonaje = new Personaje(nuevosDatos, nuevasCaracteristicas);
    listaPeleadores.Add(nuevoPersonaje);
}

mostrarlista(listaPeleadores);


void mostrarlista(List<Personaje>lista)
{
    for (int i = 0; i < lista.Count; i++)
    {
        Console.WriteLine("\n### Personaje " + Convert.ToInt32(i+1) + " ###");
        lista[i].mostrarPersonaje();
    }
}