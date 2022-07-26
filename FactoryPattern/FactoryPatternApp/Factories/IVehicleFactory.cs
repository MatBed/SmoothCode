using FactoryPatternApp.Samples;

namespace FactoryPatternApp.Factories;
public interface IVehicleFactory
{
    IVehicle Create(string name);
}