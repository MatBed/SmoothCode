using FactoryPatternApp.Factories;
using FactoryPatternApp.Samples;

public class UserDataFactory : IUserDataFactory
{
    private readonly Func<IUserData> _factory;

    public UserDataFactory(Func<IUserData> factory)
    {
        _factory = factory;
    }

    public IUserData Create(string name)
    {
        var output = _factory();
        output.Name = name;

        return output;
    }
}