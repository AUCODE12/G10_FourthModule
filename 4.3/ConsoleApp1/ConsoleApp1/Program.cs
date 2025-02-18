using System.IO;

namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(MaximumWealth([[2, 8, 7], [7, 1, 3], [1, 9, 5]]));
    }

    public static string ClearDigits(string s)
    {
        for (int i = 0; i < s.Length; i++)
        {
            if (char.IsDigit(s[i]))
            {
                if (i > 0)
                {
                    s = s.Remove(i - 1, 1);
                    i--;
                }
                s = s.Remove(i, 1);
                i--;    
            }
        }
        return s;
    }

    public static IList<string> LetterCombinations(string digits)
    {
        if (string.IsNullOrEmpty(digits))
            return new List<string>();

        Dictionary<int, string> phoneNumKeys = new Dictionary<int, string>
        {
            { 2, "abc" }, 
            { 3, "def" }, 
            { 4, "ghi" }, 
            { 5, "jkl" },
            { 6, "mno" }, 
            { 7, "pqrs" }, 
            { 8, "tuv" }, 
            { 9, "wxyz" }
        };

        var res = new List<string> { "" };

        foreach (var d in digits)
        {
            int digit = d - '0';
            if (!phoneNumKeys.TryGetValue(digit, out string letters))
                continue;

            foreach (var p in res)
            {
                foreach (var c in letters)
                {

                }
            }
        }
        return res;
    }

    public static int CountPartitions(int[] nums)
    {
        
        var count = 0;
        var d = 0;
        var sum = nums.Sum();

        for (int i = 0; i < nums.Length - 1; i++)
        {
            d += nums[i];
            var r = sum - d;
            var a = r - d;
            if (a % 2 == 0) count++;
        }
        return count;
    }

    public static int SubarraySum(int[] nums)
    {
        var sum = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            var start = Math.Max(0, i - nums[i]);
            for (var j = start; j < i + 1; j++)
            {
                sum += nums[j];
            }
        }
        return sum;
    }

    public static int[] RunningSum(int[] nums)
    {
        var nums1d = new int[nums.Length];
        for (var i = 0; i < nums.Length; i++)
        {
            var sum = 0; 
            for (var j = 0; j <= i; j++)
            {
                sum += nums[j];
            }
            nums1d[i] = sum;
        }
        return nums1d;
    }

    public static int AddDigits(int num)
    {
        while (num >= 10)
        {
            var sum = 0;
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }
            num = sum;
        }
        return num;
    }

    public static int MaximumWealth(int[][] accounts)
    {
        //var sums = new int[accounts.Length];
        int maxWealth = 0;
        for (int i = 0; i < accounts.Length; i++)
        {
            var sum = 0;
            for (int j = 0; j < accounts[i].Length; j++)
            {
                sum += accounts[i][j];
            }
            maxWealth = Math.Max(maxWealth, sum);
        }
        return maxWealth;
    }
}
