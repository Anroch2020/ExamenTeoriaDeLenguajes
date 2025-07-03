/// <summary>
/// Clase base abstracta para todos los vehículos eléctricos.
/// Contiene propiedades y métodos comunes.
/// </summary>
public abstract class VehiculoElectrico
{
    public string Marca { get; }
    public string Modelo { get; }
    public int AutonomiaMaxima { get; }
    
    // Encapsulamiento de la carga actual para controlar sus valores.
    private double _cargaActual;
    public double CargaActual
    {
        get => _cargaActual;
        protected set
        {
            if (value < 0) _cargaActual = 0;
            else if (value > 100) _cargaActual = 100;
            else _cargaActual = value;
        }
    }

    protected VehiculoElectrico(string marca, string modelo, int autonomiaMaxima, double cargaActual)
    {
        Marca = marca;
        Modelo = modelo;
        AutonomiaMaxima = autonomiaMaxima;
        CargaActual = cargaActual;
    }

    /// <summary>
    /// Metodo abstracto para cargar la batería. La implementación varía en cada subclase.
    /// </summary>
    public abstract void CargarBateria();

    /// <summary>
    /// Metodo abstracto que devuelve el consumo de bateria por kilometro.
    /// </summary>
    /// <returns>El porcentaje (%) de bateria consumido por km.</returns>
    public abstract double ConsumoPorKm();

    public override string ToString()
    {
        return $"Tipo: {GetType().Name,-20} | Marca: {Marca,-10} | Modelo: {Modelo,-10} | Carga: {CargaActual,6:F2}%";
    }
}

/// <summary>
/// Representa un Auto Electrico.
/// </summary>
public class AutoElectrico : VehiculoElectrico
{
    public AutoElectrico(string marca, string modelo, int autonomiaMaxima, double cargaActual)
        : base(marca, modelo, autonomiaMaxima, cargaActual) { }

    public override void CargarBateria()
    {
        Console.WriteLine($"Iniciando carga lenta para el auto {Marca} {Modelo}...");
        CargaActual = 100; // Simula una carga completa
        Console.WriteLine("Carga del auto completada.");
    }

    public override double ConsumoPorKm()
    {
        return 0.3; // Consume 0.3% de bateria por km
    }
}

/// <summary>
/// Representa una Motocicleta Electrica.
/// </summary>
public class MotocicletaElectrica : VehiculoElectrico
{
    public MotocicletaElectrica(string marca, string modelo, int autonomiaMaxima, double cargaActual)
        : base(marca, modelo, autonomiaMaxima, cargaActual) { }

    public override void CargarBateria()
    {
        Console.WriteLine($"Iniciando carga normal para la motocicleta {Marca} {Modelo}...");
        CargaActual = 100;
        Console.WriteLine("Carga de la motocicleta completada.");
    }

    public override double ConsumoPorKm()
    {
        return 0.15; // Consume 0.15% de bateria por km
    }
}

/// <summary>
/// Representa una Bicicleta Electrica.
/// </summary>
public class BicicletaElectrica : VehiculoElectrico
{
    public BicicletaElectrica(string marca, string modelo, int autonomiaMaxima, double cargaActual)
        : base(marca, modelo, autonomiaMaxima, cargaActual) { }

    public override void CargarBateria()
    {
        Console.WriteLine($"Iniciando carga rápida para la bicicleta {Marca} {Modelo}...");
        CargaActual = 100;
        Console.WriteLine("Carga de la bicicleta completada.");
    }

    public override double ConsumoPorKm()
    {
        return 0.05; // Consume 0.05% de batería por km
    }
}


// --- Logica de la Aplicacion Interactiva ---

public class Program
{
    public static void Main(string[] args)
    {
        // Generar la lista inicial de vehículos.
        var flota = new List<VehiculoElectrico>
        {
            new AutoElectrico("Tesla", "Model 3", 500, 65.5),
            new AutoElectrico("Nissan", "Leaf", 350, 15.0),
            new MotocicletaElectrica("Zero", "SR/F", 250, 80.2),
            new MotocicletaElectrica("Harley", "LiveWire", 235, 19.9),
            new BicicletaElectrica("Giant", "Trance E+", 120, 95.0),
            new BicicletaElectrica("Trek", "Rail", 110, 55.0),
            new AutoElectrico("Ford", "Mustang ME", 480, 8.5),
        };

        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("\n--- Gestión de Flota de Vehículos Eléctricos ---");
            Console.WriteLine("1. Ver todos los vehículos de la flota");
            Console.WriteLine("2. Mostrar vehículos con batería baja (< 20%)");
            Console.WriteLine("3. Mostrar marcas con buena carga (> 50%)");
            Console.WriteLine("4. Calcular consumo total de la flota por Km");
            Console.WriteLine("5. Cargar batería de un vehículo con poca carga");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");

            string? opcion = Console.ReadLine();
            Console.Clear(); // Limpia la consola para una mejor experiencia

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("--- Flota Completa ---");
                    flota.ForEach(v => Console.WriteLine(v));
                    break;
                case "2":
                    Console.WriteLine("--- Vehículos con Batería Baja (< 20%) ---");
                    var vehiculosBateriaBaja = flota.Where(v => v.CargaActual < 20).ToList();
                    if (!vehiculosBateriaBaja.Any())
                        Console.WriteLine("Ningún vehículo tiene la batería baja.");
                    else
                        vehiculosBateriaBaja.ForEach(v => Console.WriteLine(v));
                    break;
                case "3":
                    Console.WriteLine("--- Marcas de Vehículos con Buena Carga (> 50%) ---");
                    var marcasConBuenaCarga = flota.Where(v => v.CargaActual > 50).Select(v => v.Marca).Distinct().ToList();
                     if (!marcasConBuenaCarga.Any())
                        Console.WriteLine("Ningún vehículo tiene carga superior al 50%.");
                    else
                        marcasConBuenaCarga.ForEach(m => Console.WriteLine($"- {m}"));
                    break;
                case "4":
                    Console.WriteLine("--- Consumo Total de la Flota ---");
                    double consumoTotal = flota.Sum(v => v.ConsumoPorKm());
                    Console.WriteLine($"El consumo total de la flota por kilómetro es: {consumoTotal:F2}% de batería por Km.");
                    break;
                case "5":
                     Console.WriteLine("--- Cargar Batería ---");
                     var vehiculoParaCargar = flota.FirstOrDefault(v => v.CargaActual < 100);
                     if(vehiculoParaCargar == null)
                     {
                        Console.WriteLine("¡Todos los vehículos están completamente cargados!");
                     }
                     else
                     {
                        Console.WriteLine($"Vehículo seleccionado para cargar: {vehiculoParaCargar.Marca} {vehiculoParaCargar.Modelo}");
                        vehiculoParaCargar.CargarBateria();
                        Console.WriteLine($"Estado actual: {vehiculoParaCargar}");
                     }
                    break;
                case "6":
                    salir = true;
                    Console.WriteLine("¡Hasta luego!");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                    break;
            }
             if (!salir)
            {
                Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}