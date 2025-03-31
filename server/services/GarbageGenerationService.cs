public interface IGarbageGenerationService
{
    int generate(int mb);

    int generaterandom();
}

public class GarbageGenerationService : IGarbageGenerationService
{
    private readonly List<byte[]> _list = new List<byte[]>();
    private readonly Random _random = new Random();

    public int generate(int mb)
    {
        var garbage = new byte[mb << 20];
        _list.Add(garbage);
        return mb;
    }

    public int generaterandom()
    {
        var mb = _random.Next(1, 101);
        return generate(mb);
    }


    public void cleanup()
    {
        _list.Clear();
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}
