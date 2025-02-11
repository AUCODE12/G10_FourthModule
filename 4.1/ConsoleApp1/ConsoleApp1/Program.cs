using System.Text;

namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Reverse(123));
    }

    public static string ClearDigits1(string s)
    {
        StringBuilder sb = new StringBuilder(s);

        for (int i = 0; i < sb.Length; i++)
        {
            if (char.IsDigit(sb[i]))
            {
                if (i > 0)
                {
                    sb.Remove(i - 1, 1);
                    i--;
                }
                sb.Remove(i, 1);
                i--;
            }
        }

        return sb.ToString();
    }

    public static int RemoveElement(int[] nums, int val)
    {
        var newNums = new int[nums.Length];
        var count = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] != val)
            {
                nums[count] = nums[i];
                count++;
            }
        }
        return count;
    }

    //!!!
    public static int Reverse(int x)
    {
        List<char> list = new List<char>();
        var nums = new int[x.ToString().Count() - 1];
        for (var i = 0; i < nums.Length; i++)
        {
            nums[i] = x.ToString()[i + 1];
            list.Add(x.ToString()[i]);
        }
        nums.Reverse();
        list.Reverse();
        if (nums[0] == 0)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                nums[i] = nums[i + 1];
            }
            list.RemoveRange(0, 1);
        }
        return Int32.Parse(list.ToArray());
    }

    public static string FindValidPair(string s)
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9};
        Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
        var nums = s.ToArray();
        foreach (int num in numbers)
        {
            keyValuePairs.Add(num, 0);
        }

        for (var i = 0; i < nums.Length; i++)
        {
            if (keyValuePairs.Key)
        }
        
    }
}
