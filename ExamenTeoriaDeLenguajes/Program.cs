
// --- Clases que representan los Vehículos (Paradigma POO) ---

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
    /// Método abstracto para cargar la batería. La implementación varía en cada subclase.
    /// </summary>
    public abstract void CargarBateria();

    /// <summary>
    /// Método abstracto que devuelve el consumo de batería por kilómetro.
    /// </summary>
    /// <returns>El porcentaje (%) de batería consumido por km.</returns>
    public abstract double ConsumoPorKm();

    public override string ToString()
    {
        return $"Tipo: {GetType().Name,-20} | Marca: {Marca,-10} | Modelo: {Modelo,-10} | Carga: {CargaActual,6:F2}%";
    }
}

/// <summary>
/// Representa un Auto Eléctrico.
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
        return 0.3; // Consume 0.3% de batería por km
    }
}

/// <summary>
/// Representa una Motocicleta Eléctrica.
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
        return 0.15; // Consume 0.15% de batería por km
    }
}

/// <summary>
/// Representa una Bicicleta Eléctrica.
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


// --- Lógica de la Aplicación (Uso de Paradigma Funcional con LINQ) ---

public class Program
{
    public static void Main(string[] args)
    {
        // 1. Generar una lista de vehículos de diferentes tipos.
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

        Console.WriteLine("--- Flota de Vehículos Eléctricos ---");
        flota.ForEach(v => Console.WriteLine(v));
        Console.WriteLine("\n" + new string('-', 40) + "\n");

        // 2. Filtrar y mostrar vehículos con menos del 20% de batería.
        Console.WriteLine("--- Vehículos con Batería Baja (< 20%) ---");
        var vehiculosBateriaBaja = flota.Where(v => v.CargaActual < 20);
        
        if (!vehiculosBateriaBaja.Any())
        {
            Console.WriteLine("Ningún vehículo tiene la batería baja.");
        }
        else
        {
            foreach (var vehiculo in vehiculosBateriaBaja)
            {
                Console.WriteLine(vehiculo);
            }
        }
        Console.WriteLine("\n" + new string('-', 40) + "\n");
        
        // 3. Obtener las marcas de vehículos con más del 50% de batería.
        Console.WriteLine("--- Marcas de Vehículos con Buena Carga (> 50%) ---");
        var marcasConBuenaCarga = flota
            .Where(v => v.CargaActual > 50)
            .Select(v => v.Marca);

        if (!marcasConBuenaCarga.Any())
        {
             Console.WriteLine("Ningún vehículo tiene carga superior al 50%.");
        }
        else
        {
            foreach (var marca in marcasConBuenaCarga)
            {
                Console.WriteLine($"- {marca}");
            }
        }
        Console.WriteLine("\n" + new string('-', 40) + "\n");

        // 4. Calcular el consumo total por kilómetro de toda la flota.
        Console.WriteLine("--- Consumo Total de la Flota ---");
        double consumoTotal = flota.Sum(v => v.ConsumoPorKm());
        Console.WriteLine($"El consumo total de la flota por kilómetro es: {consumoTotal:F2}% de batería por Km.");
    }
}