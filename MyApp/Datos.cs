namespace Juego
{
    public class Datos
    {
        string[] tipos = {"Bestia", "Saiyajin", "Hechicero", "Cazador", "Templario"};
        string[] nombres = {"Bruce Wayne", "Maradona", "David", "Messi", "Sub-Zero"};
        string[] apodos = {"Pica ojo", "Golden Boy", "El atrevido", "Barrilete cósmico", "Buenito pero peligroso"};
        Random random = new Random();
        // buscar: como mostrar el texto del enum?

        // campos o variables
        private string tipo;
        private string nombre; 
        private string apodo; 
        private DateOnly fechaDeNacimiento;
        private int edad; //entre 0 a 300
        private int salud; //100

        // constructor (método)
        public Datos()
        {
            this.tipo = tipos[random.Next(5)];
            this.nombre = nombres[random.Next(5)];
            this.apodo = apodos[random.Next(5)];
            this.fechaDeNacimiento = new DateOnly(random.Next(1722,2023), random.Next(1,13), random.Next(1,29));
            this.edad = DateTime.Now.Year - FechaDeNacimiento.Year;
            this.salud = 100;
        }

        // propiedades
        public string Tipo { get => tipo; }
        public string Nombre { get => nombre; }
        public string Apodo { get => apodo; }
        public DateOnly FechaDeNacimiento { get => fechaDeNacimiento; }
        public int Edad { get => edad; }
        public int Salud { get => salud; }
    } 
}


