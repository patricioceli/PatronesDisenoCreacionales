using System;

// Producto (IEnvio)
public interface IEnvio
{
    decimal CalcularCosto();
    int CalcularTiempoEntrega();
}

// Producto Concreto (EnvioTerrestre)
public class EnvioTerrestre : IEnvio
{
    public decimal CalcularCosto()
    {
        return 50.0M; // Tarifa base terrestre
    }

    public int CalcularTiempoEntrega()
    {
        return 2; // Tiempo de entrega terrestre en días
    }
}

// Producto Concreto (EnvioAereo)
public class EnvioAereo : IEnvio
{
    public decimal CalcularCosto()
    {
        return 150.0M; // Tarifa base aérea
    }

    public int CalcularTiempoEntrega()
    {
        return 1; // Tiempo de entrega aérea en días
    }
}

// Creador (CompaniaTransportes)
public abstract class CompaniaTransportes
{
    public abstract IEnvio CrearEnvio();
}

// Creador Concreto (CompaniaTransportesTerrestres)
public class CompaniaTransportesTerrestres : CompaniaTransportes
{
    public override IEnvio CrearEnvio()
    {
        return new EnvioTerrestre();
    }
}

// Creador Concreto (CompaniaTransportesAereos)
public class CompaniaTransportesAereos : CompaniaTransportes
{
    public override IEnvio CrearEnvio()
    {
        return new EnvioAereo();
    }
}

class Program
{
    static void Main()
    {
        CompaniaTransportes compania = null;
        IEnvio envio = null;

        // Crear envío terrestre
        compania = new CompaniaTransportesTerrestres();
        envio = compania.CrearEnvio();
        Console.WriteLine("Costo envío terrestre: " + envio.CalcularCosto());
        Console.WriteLine("Tiempo de entrega envío terrestre: " + envio.CalcularTiempoEntrega() + " días");

        // Crear envío aéreo
        compania = new CompaniaTransportesAereos();
        envio = compania.CrearEnvio();
        Console.WriteLine("Costo envío aéreo: " + envio.CalcularCosto());
        Console.WriteLine("Tiempo de entrega envío aéreo: " + envio.CalcularTiempoEntrega() + " días");
    }
}
