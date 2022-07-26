using FactoryPatternApp.Samples;

namespace FactoryPatternApp.Factories;

public static class GenerateClassWithDataFactory
{
    public static void AddGenericClassWithDataFactory(this IServiceCollection services)
    {
        services.AddTransient<IUserData, UserData>();
        services.AddSingleton<Func<IUserData>>(x=>()=>x.GetService<IUserData>()!);
        services.AddSingleton<IUserDataFactory, UserDataFactory>();
    }
}