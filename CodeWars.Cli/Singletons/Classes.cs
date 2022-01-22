namespace CodeWars.Cli.Singletons;

public sealed class Adam: Male
{
    private static Adam? Instance = null;
    private Adam() {}
    
    public static Adam GetInstance()
    {
        return Instance ??= new Adam { Name = "Adam" };
    }
}

public sealed class Eve : Female
{
    private static Eve? Instance = null;
    
    private Eve() {}

    public static Eve? GetInstance(Adam adam)
    {
        if (adam == null) throw new ArgumentNullException();
        return Instance ??= new Eve { Name = "Eve" };
    }
}

public class Male : Human
{
    protected Male() {}
    public Male(string name, Human? mother, Human? father)
    { 
        //if (!string.Equals(name, "Adam", StringComparison.InvariantCultureIgnoreCase) && (mother == null || father == null))
        if (mother == null || father == null)
        {
            throw new ArgumentNullException();
        }
        Name = name;
        Mother = mother;
        Father = father;
    }
}

public class Female : Human
{
    protected Female() {}
    public Female(string name, Human? mother, Human father)
    {
        //if (!string.Equals(name, "eve", StringComparison.InvariantCultureIgnoreCase) && (mother == null || father == null))
        if (mother == null || father == null)
        {
            throw new ArgumentNullException();
        }        
        Name = name;
        Mother = mother;
        Father = father;
    }    
}

public abstract class Human
{
    public string? Name { get; set; }
    public Human? Mother { get; set; }
    public Human? Father { get; set; }
}