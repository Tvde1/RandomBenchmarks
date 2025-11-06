namespace InheritanceVsComposition.Inh;

public abstract class DistributedCache<TItem>
{
    protected abstract string CreateKey(TItem key);

    public int Get(TItem item)
    {
        var key = CreateKey(item);
        return key.Length;
    }

    public int Set(TItem item)
    {
        var key = CreateKey(item);
        return key.Length;
    }
}

public sealed class CorporateCache : DistributedCache<Corporate>
{
    protected override string CreateKey(Corporate key)
    {
        return "Corporate_" + key.Identifier;
    }
}