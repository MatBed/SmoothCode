namespace FactoryPatternApp.Samples;

public class SampleOne : ISampleOne
{
    public string CurrentDateTime { get; set; } = DateTime.Now.ToString();
}
