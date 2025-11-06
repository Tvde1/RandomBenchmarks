namespace InheritanceVsComposition.Comp;

public sealed class DistributedCache<TItem>
{
    private readonly Func<TItem, string> _keySelector;

    public DistributedCache(Func<TItem, string> keySelector)
    {
        _keySelector = keySelector;
    }

    public int Get(TItem item)
    {
        var key = _keySelector(item);
        return key.Length;
    }

    public int Set(TItem item)
    {
        var key = _keySelector(item);
        return key.Length;
    }
}

public sealed class CorporateCache
{
    private readonly DistributedCache<Corporate> _cache;

    public CorporateCache()
    {
        _cache = new DistributedCache<Corporate>(CreateKey);
    }

    private static string CreateKey(Corporate key)
    {
        return "Corporate_" + key.Identifier;
    }

    public int Get(Corporate corporate) => _cache.Get(corporate);

    public int Set(Corporate corporate) => _cache.Set(corporate);
}