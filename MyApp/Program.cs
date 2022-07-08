using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;

List<Personaje>listaPeleadores = new List<Personaje>(); //var listaPersonajes = new List<Personaje>();
string path = Directory.GetCurrentDirectory();
string archivoCsv = path + @"\ganadores.csv";
string archivoJson = path + @"\personajes.json";
FileStream fs;
StreamWriter sw;
int op;
int nroCombate;

do
{
    Console.WriteLine("\n#### CONFIGURACIONES DEL TORNEO ####");
    elegirCrearCsv();
    elegirVerCsv();
    elegirCreacionPeleadores();
    elegirVerPeleadores();
    Console.WriteLine("\n##### COMIENZA EL TORNEO MAS BRUTAL DE TODOS LOS TIEMPOS :( #####");
    Console.Write($"**** Esta contienda se llevara a cabo en: {obtenerProvApi()} ****");
    Console.ReadKey();
    nroCombate=0;
    do
    {
        nroCombate++;
        Console.WriteLine($"\n**** COMBATE {nroCombate}: {listaPeleadores[0].DatPersonaje.Nombre} VS {listaPeleadores[1].DatPersonaje.Nombre} ****");
        Combate nuevoCombate = new Combate(listaPeleadores[0],listaPeleadores[1]);
        nuevoCombate.pelear();
        eliminarPerdedor(listaPeleadores[0], listaPeleadores[1]);
        mejorarGanador();
        Console.WriteLine($"\n>>>> Ganador del combate: {listaPeleadores[0].DatPersonaje.Nombre} <<<<");
        Console.ReadKey();
    } while (listaPeleadores.Count > 1);
    guardarGanadorCsv();
    Console.WriteLine($"\n>>>> EL VENCEDOR DEL TORNEO Y GANADOR DEL TRONO DE HIERRO ES: <<<<");
    listaPeleadores[0].mostrarDatos();
    Console.WriteLine("\nFELICITACIONES CAMPEÓN!!!!!!!!!");
    Console.WriteLine("\n----------------------");
} while (jugarNuevoTorneo()==1);


//---------------- FUNCIONES -----------------------

void elegirCrearCsv()
{
    if (!File.Exists(archivoCsv))
    {
        Console.WriteLine("\n==> No existe un archivo Csv para guardar los ganadores de los Torneos, a continuacion se creará uno automaticamente... <==");
        crearCsv();
    }
    else
    {
        Console.WriteLine("\n==> Se detecto un archivo Csv de los ganadores de los Torneos, ¿desea usarlo o crear uno nuevo? <=");
        do
        {
            Console.WriteLine("[1]Usarlo, [0]Crear uno nuevo (se elimina el archivo anterior)");
            op = Convert.ToInt32(Console.ReadLine());  
        } while (op<0 || op>1);
        if (op==0)
        {
            crearCsv();
        }
    }
}

void crearCsv()
{   
    using (fs = new FileStream(archivoCsv, FileMode.Create))
    {
        using (sw = new StreamWriter(fs))
        {
            sw.WriteLine("VICTORIAS"+","+"NOMBRE"+","+"APODO"+","+"FECHA"+","+"HORA");
        }
    }
    Console.WriteLine("==> Archivo Csv creado con éxito <==");
    Console.ReadKey();
}

void guardarGanadorCsv() //guarda al ganador de un Torneo
{
    using (fs = new FileStream(archivoCsv, FileMode.Append))
    {
        using (sw = new StreamWriter(fs))
        {
            sw.WriteLine(listaPeleadores[0].DatPersonaje.Victorias+","+listaPeleadores[0].DatPersonaje.Nombre+","+listaPeleadores[0].DatPersonaje.Tipo+","+DateTime.Now.ToShortDateString()+","+DateTime.Now.ToShortTimeString());
        }
    }
}

void elegirVerCsv()
{
    do
    {
        Console.WriteLine("\n==> ¿Desea ver el contenido guardado del archivo Csv? (1)Si, 0(No) <==");
        op = Convert.ToInt32(Console.ReadLine());  
    } while (op<0 || op>1);
    if (op==1)
    {
        string[] ganadores = File.ReadAllLines(archivoCsv);
        string[] valores;
        for (int i = 0; i < ganadores.Count(); i++)
        {
            valores = ganadores[i].Split(';');
            for (int j= 0; j < valores.Count(); j++)
            {
                Console.Write(valores[j] + "  ");
            }
            Console.WriteLine();
        }
        Console.ReadKey();
    }
}

void elegirCreacionPeleadores() //elegir usar personajes del archivo Json o crear personajes nuevos aleatoriamente
{
    bool aux = true;
    if (!File.Exists(archivoJson)) //en caso de que no existe un Json se crea uno automaticamente
    {
    }
    else
    {
        Console.WriteLine("\n==> Se detecto un archivo Json con personajes del Torneo anterior, ¿desea usar los mismos personajes o crear nuevos?");
        do
        {
            Console.WriteLine("[1]Usarlos, [2]Crear Nuevos");
            op = Convert.ToInt32(Console.ReadLine());
        } while (op<1 || op>2);
        if (op==1)
        {
            deserializarJson();
            aux = false;
        }
    }
    if (aux==true)
    {
        crearJson();
        crearListaPeleadores(elegirCantPeleadores());
        serializarJson(); 
    }
}

void crearJson() //crea un nuevo Json. Si ya existe uno se lo sobreescribe
{
    fs = new FileStream(archivoJson, FileMode.Create);
    fs.Close();
}

void serializarJson() //guarda los personajes en un Json
{
    using (fs = new FileStream(archivoJson, FileMode.Create))
    {
        using (sw = new StreamWriter(fs))
        {
            string stringJson = JsonSerializer.Serialize(listaPeleadores);
            sw.WriteLine(stringJson);
        }
    }
}

void deserializarJson()
{
    using (fs = new FileStream(archivoJson, FileMode.Open))
    {
        using (StreamReader sr = new StreamReader(fs))
        {
            string stringJson = sr.ReadToEnd();
            listaPeleadores = JsonSerializer.Deserialize<List<Personaje>>(stringJson)!;
        }
    }
}

int elegirCantPeleadores()
{
    int cantPeleadores;
    do
    {
        Console.WriteLine("\n==> Ingrese la cantidad de peleadores que participarán en el Torneo (2 Min - 10 Max) <== ");
        cantPeleadores = Convert.ToInt32(Console.ReadLine()); 
    } while (cantPeleadores<2 || cantPeleadores>10 );
    return cantPeleadores;
}

void crearListaPeleadores(int cantPeleadores)
{
    Personaje nuevoPersonaje;
    Datos nuevosDatos;
    Caracteristicas nuevasCaracteristicas;
    for (int i = 0; i < cantPeleadores; i++)
    {
        nuevosDatos = new Datos(obtenerExcusaApi());
        nuevasCaracteristicas = new Caracteristicas();
        nuevoPersonaje = new Personaje(nuevosDatos, nuevasCaracteristicas); //nuevoPersonaje = new Personaje(new Datos(), new Caracteristicas());
        listaPeleadores.Add(nuevoPersonaje);
    }
}

string obtenerExcusaApi()
{
    var url = $"https://excuser.herokuapp.com/v1/excuse";
    var request = (HttpWebRequest)WebRequest.Create(url);
    request.Method = "GET";
    request.ContentType = "application/json";
    request.Accept = "application/json";
    try
    {
        using (WebResponse response = request.GetResponse())
        {
            using (Stream strReader = response.GetResponseStream())
            {
                if (strReader != null)
                {
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string responseBody = objReader.ReadToEnd(); 
                        List<Excusa> excusaFav = JsonSerializer.Deserialize<List<Excusa>>(responseBody)!;
                        return excusaFav[0].excuse;
                    }
                }
                else
                {
                    return "No sos vos, soy yo...";
                }
            }
        }
    }
    catch (Exception)
    {
        return "No sos vos, soy yo...";
    }   
}   

void elegirVerPeleadores()
{
    int verLista;
    do
    {
        Console.WriteLine("\n==> Desea ver los peleadores que participaran del torneo? (1: Si, 0:No) <==");
        verLista = Convert.ToInt32(Console.ReadLine());
    } while (verLista<0 || verLista>1);
    if (verLista==1)
    {   
        for (int i = 0; i < listaPeleadores.Count; i++)
        {
            Console.WriteLine($"\n**** PELEADOR {Convert.ToInt32(i+1)} ****");
            listaPeleadores[i].mostrarPersonaje();
            Console.ReadKey();
        };
    }
}

string obtenerProvApi()
{
    var url = $"https://apis.datos.gob.ar/georef/api/provincias?campos=id,nombre";
    var request = (HttpWebRequest)WebRequest.Create(url);
    request.Method = "GET";
    request.ContentType = "application/json";
    request.Accept = "application/json";
    try
    {
        using (WebResponse response = request.GetResponse())
        {
            using (Stream strReader = response.GetResponseStream())
            {
                if (strReader != null)
                using (StreamReader objReader = new StreamReader(strReader))
                {
                    string responseBody = objReader.ReadToEnd(); 
                    ProvinciasArgentina ProvinciasArg = JsonSerializer.Deserialize<ProvinciasArgentina>(responseBody)!;
                    Random rnd = new Random();
                    return ProvinciasArg.Provincias[rnd.Next(24)].Nombre;
                }
                else
                {
                    return "Tucuman, barrio San Cayetano :S";
                }
            }
        }
    }
    catch (Exception)
    {
        return "Tucuman, barrio La Bombilla :S";
    }
}   

void eliminarPerdedor(Personaje peleador1, Personaje peleador2)
{
    if (peleador1.DatPersonaje.Salud < peleador2.DatPersonaje.Salud)
    {
        listaPeleadores.Remove(peleador1);
    }
    else
    {
        if (peleador1.DatPersonaje.Salud > peleador2.DatPersonaje.Salud)
        {
            listaPeleadores.Remove(peleador2);
        }
        else
        {
            Console.WriteLine("\nEl combate termino empatado. Elija un peleador para SACRIFICARLO:");
            do
            {
                Console.WriteLine($"==> (1){peleador1.DatPersonaje.Nombre}, (2){peleador2.DatPersonaje.Nombre} <==");
                op = Convert.ToInt32(Console.ReadLine());
            } while (op<1 || op>2);
            if (op==1)
            {
                listaPeleadores.Remove(peleador1);
            }
            else
            {
                listaPeleadores.Remove(peleador2);
            }
        }
    }
}

void mejorarGanador()
{
    listaPeleadores[0].DatPersonaje.Salud += 5; 
    listaPeleadores[0].DatPersonaje.Victorias += 1;
    listaPeleadores[0].CaracPersonaje.Fuerza += 1;
    listaPeleadores[0].CaracPersonaje.Velocidad += 2;
}

int jugarNuevoTorneo()
{
    do
    {
        Console.WriteLine("\n==> ¿Jugar un nuevo Torneo? [1]Si, [0]No <==");
        op = Convert.ToInt32(Console.ReadLine());
    } while (op<0 || op>1);
    if (op==1)
    {
        listaPeleadores.Remove(listaPeleadores[0]);
    }
    return op;
}