namespace FactoryPatternApp.Samples;

public class SampleTwo : ISampleTwo
{
    public int RandomValue { get; set; }

    public SampleTwo()
    {
        RandomValue = Random.Shared.Next(1, 100);
    }
}
