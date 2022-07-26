using FactoryPatternApp.Samples;

namespace FactoryPatternApp.Factories;

public class VehicleFactory : IVehicleFactory
{
    private readonly Func<IEnumerable<IVehicle>> _factory;

    public VehicleFactory(Func<IEnumerable<IVehicle>> factory)
    {
        _factory = factory;
    }

    public IVehicle Create(string name)
    {
        var set = _factory();
        IVehicle output = set.Where(x => x.VehicleType == name).First();

        return output;
    }
}
