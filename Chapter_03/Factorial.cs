namespace GrokkingAlrogithms.Chapter_3;

public class Factorial
{
    public static int GetFactorial(int n) 
    {
        if (n == 1)
            return 1;

        return n * GetFactorial(n - 1);
    }
}
