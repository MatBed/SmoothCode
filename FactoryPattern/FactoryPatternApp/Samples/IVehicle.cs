namespace FactoryPatternApp.Samples;

public interface IVehicle
{
    string VehicleType { get; set; }

    string Start();
}