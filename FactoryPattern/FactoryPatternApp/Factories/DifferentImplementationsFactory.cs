using FactoryPatternApp.Samples;

namespace FactoryPatternApp.Factories;

public static class DifferentImplementationsFactory
{
    public static void AddVehicleFactory(this IServiceCollection services)
    {
        services.AddTransient<IVehicle, Car>();
        services.AddTransient<IVehicle, Truck>();
        services.AddTransient<IVehicle, Van>();
        services.AddSingleton<Func<IEnumerable<IVehicle>>>(x => () => x.GetService<IEnumerable<IVehicle>>()!);
        services.AddSingleton<IVehicleFactory, VehicleFactory>();
    }
}