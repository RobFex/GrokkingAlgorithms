namespace GrokkingAlgorithms.Chapter_9
{
    public class Dynamic
    {
        public static string LongestCommonSubstring(string word1, string word2)
        {
            int[,] dp = new int[word1.Length + 1, word2.Length + 1];
            Dictionary<int, char> p = new Dictionary<int, char>();

            int n = word1.Length;
            int m = word2.Length;
            string substring = string.Empty;

            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 1; j < m + 1; j++)
                {
                    if (word1[i - 1] == word2[j - 1] && !p.ContainsKey(dp[i - 1, j - 1] + 1))
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                        p.Add(dp[i, j], word1[i - 1]);
                    }
                    else
                    {
                        switch (dp[i - 1, j] > dp[i, j - 1])
                        {
                            case true:
                                dp[i, j] = dp[i - 1, j];
                                break;

                            default:
                                dp[i, j] = dp[i, j - 1];
                                break;
                        }
                    }
                }
            }

            foreach (char s in p.Values)
                substring += s;

            return substring;
        }
        public static int LongestCommonSubsequence(string word1, string word2)
        {
            int[,] dp = new int[word1.Length + 1, word2.Length + 1];
            int n = word1.Length;
            int m = word2.Length;

            for (int i = 1;  i < n + 1; i++)
            {
                for (int j = 1;  j < m + 1; j++)
                {
                    if (word1[i - 1] == word2[j - 1])
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    
                    else
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }

            return dp[n, m];
        }
    }
}
