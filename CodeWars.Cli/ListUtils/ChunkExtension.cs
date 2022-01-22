namespace CodeWars.Cli.ListUtils;

public static class ChunkExtension
{
    // For CodeWars that doesn't yet recognise the built-in Chunk.
    public static List<List<T>> ChunkBy<T>(this IEnumerable<T> source, int chunkSize) 
    {
        return source   
            .Select((x, i) => new { Index = i, Value = x })
            .GroupBy(x => x.Index / chunkSize)
            .Select(x => x.Select(v => v.Value).ToList())
            .ToList();
    }    
}