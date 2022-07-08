public class Datos
{
    string[] tipos = {"Bestia", "Saiyajin", "Hechicero", "Rockera", "Templario", "Doncella", "Ladron", "Cumbiera", "Cazador"};
    string[] nombres = {"Batman", "Maradona", "Solid Snake", "Messi", "Sub-Zero", "Peppa Pig", "Megaman", "Scooby", "Barbie"};
    string[] apodos = {"Pica ojo", "Mano de piedra", "El atrevido", "Barrilete cosmico", "Punios de acero", "Killer Queen", "Viuda negra", "La Diabla"};

    // campos o variables
    private string tipo;
    private string nombre; 
    private string apodo; 
    private DateTime fechaDeNacimiento;
    private int edad; //entre 0 a 300
    private double salud; //100
    private bool vivo; //esta vivo si salud es > 0
    private int victorias; //cantidad de combates ganados
    private string excusaFavorita;

    // constructor (método)
    public Datos(string excusaFavorita)
    {
        Random random = new Random();
        this.tipo = tipos[random.Next(9)];
        this.nombre = nombres[random.Next(9)];
        this.apodo = apodos[random.Next(8)];
        this.fechaDeNacimiento = new DateTime(random.Next(1722,2023), random.Next(1,13), random.Next(1,29));
        this.edad = DateTime.Now.Year - FechaDeNacimiento.Year;
        this.salud = 100;
        this.vivo = true;
        this.victorias = 0;
        this.excusaFavorita = excusaFavorita;
    }

    // propiedades
    public string Tipo { get => tipo; set => tipo = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Apodo { get => apodo; set => apodo = value; }
    public DateTime FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
    public int Edad { get => edad; set => edad = value;}
    public double Salud { get => salud; set => salud = value; }
    public bool Vivo { get => vivo; set => vivo = value; }
    public int Victorias { get => victorias; set => victorias = value; }
    public string ExcusaFavorita { get => excusaFavorita; set => excusaFavorita = value; }
} 