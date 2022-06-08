namespace Juego
{
    public class Personaje
    {
        // campos o variables
        private Datos datPersonaje;
        private Caracteristicas caracPersonaje;

        // constructor (método)
        public Personaje (Datos datPersonaje, Caracteristicas caracPersonaje)
        {
            this.datPersonaje = datPersonaje;
            this.caracPersonaje = caracPersonaje;
        }

        // propiedades
        public Datos DatPersonaje { get => datPersonaje; }
        public Caracteristicas CaracPersonaje { get => caracPersonaje; }

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
            Console.WriteLine("Tipo: " + datPersonaje.Tipo);
            Console.WriteLine("Nombre: " + datPersonaje.Nombre);
            Console.WriteLine("Apodo: " + datPersonaje.Apodo);
            Console.WriteLine("Fecha de nacimiento: " + datPersonaje.FechaDeNacimiento);
            Console.WriteLine("Edad: " + datPersonaje.Edad);
            Console.WriteLine("Salud: " + datPersonaje.Salud);
        }

        public void mostrarCaracteristicas()
        {
            Console.WriteLine("Velocidad: " + caracPersonaje.Velocidad);
            Console.WriteLine("Destreza: " + caracPersonaje.Destreza);
            Console.WriteLine("Fuerza: " + caracPersonaje.Fuerza);
            Console.WriteLine("Nivel: " + caracPersonaje.Nivel);
            Console.WriteLine("Armadura: " + caracPersonaje.Armadura);
        }
    }   
}
