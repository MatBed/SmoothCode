using FactoryPatternApp.Samples;

namespace FactoryPatternApp.Factories;

public interface IUserDataFactory
{
    IUserData Create(string name);
}