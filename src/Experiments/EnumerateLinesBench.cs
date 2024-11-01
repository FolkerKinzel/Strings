namespace Experiments;

public class EnumerateLinesBench 
{
    public static void Test()
    {
        string input = """
            1
            2
            3

            """;

        int counter = 0;
        foreach(ReadOnlySpan<char> line in input.AsSpan().EnumerateLines())
        {
            counter++;
        }
    }
}
