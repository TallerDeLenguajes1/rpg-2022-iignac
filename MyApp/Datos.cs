namespace Juego
{
    public class Datos
    {
        string[] tipos = {"Bestia", "Saiyajin", "Hechicero", "Rockera", "Templario", "Doncella", "Ladrón", "Cumbiera", "Cazador"};
        string[] nombres = {"Batman", "Maradona", "David", "Messi", "Sub-Zero", "Peppa Pig", "Megaman", "Scooby-Doo", "Barbie"};
        string[] apodos = {"Pica ojo", "Golden Boy", "El atrevido", "Barrilete cósmico", "Puños de acero", "Killer Queen", "Viuda negra", "La Diabla"};
        Random random = new Random();
        // buscar: como mostrar el texto del enum?

        // campos o variables
        private string tipo;
        private string nombre; 
        private string apodo; 
        private DateOnly fechaDeNacimiento;
        private int edad; //entre 0 a 300
        private double salud; //100

        // constructor (método)
        public Datos()
        {
            this.tipo = tipos[random.Next(9)];
            this.nombre = nombres[random.Next(9)];
            this.apodo = apodos[random.Next(8)];
            this.fechaDeNacimiento = new DateOnly(random.Next(1722,2023), random.Next(1,13), random.Next(1,29));
            this.edad = DateTime.Now.Year - FechaDeNacimiento.Year;
            this.Salud = 100;
        }

        // propiedades
        public string Tipo { get => tipo; }
        public string Nombre { get => nombre; }
        public string Apodo { get => apodo; }
        public DateOnly FechaDeNacimiento { get => fechaDeNacimiento; }
        public int Edad { get => edad; }
        public double Salud { get => salud; set => salud = value; }
    } 
}


