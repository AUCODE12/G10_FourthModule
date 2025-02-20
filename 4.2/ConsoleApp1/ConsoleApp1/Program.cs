namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(StrStr("sadbutsad", "sad"));
    }

    public static int MaxProduct(int[] nums)
    {
        var numsList = nums.ToList();
        var max1 = numsList.Max();
        numsList.Remove(max1);
        var max2 = numsList.Max();

        var sum = (max1 - 1) * (max2 - 1);
        return sum;
    }

    public static int XorOperation(int n, int start)
    {
        var result = 0;
        var list = new int[n];
        for (var i = start; i < n; i = start + 2 * i)
        {
            list[i] = i;
        }
        foreach (var i in list)
        {
            result ^= i;
        }
        return result;
    }

    public static int StrStr(string haystack, string needle)
    {
        if (needle.Length == 0)
        {
            return 0;
        }
        return haystack.IndexOf(needle);
    }
}
