namespace GrokkingAlgorithms.Chapter_9
{
    public class Knapsack
    {
        public static int SolveProblem(int[] W, int[] V, int cap)
        {
            int length = W.Length;
            int[,] dp = new int[length + 1, cap + 1];
     
            for (int i = 1; i <= length; i++)
            {
                for (int j = 1; j <= cap; j++)
                {
                    if (W[i - 1] <= j)
                        dp[i, j] = Math.Max(V[i - 1] + dp[i - 1, j - W[i - 1]], dp[i - 1, j]);

                    else
                        dp[i, j] = dp[i - 1, j];
                }
            }
     
            return dp[length, cap];
        }
    }
}
