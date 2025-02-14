namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(ClearDigits("bsd3 y u 5 5 87f iyutui"));
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
}
