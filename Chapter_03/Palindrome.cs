namespace GrokkingAlgorithms.Chapter_3;
public class Palindrome
{
   public static bool IsPalindrome(string word, int i = 0) 
   {
      if (word[i] == word[word.Length - 1 - i]) 
      {
         if (i == (int)Math.Round((double)word.Length / 2, MidpointRounding.ToZero) - 1) 
            return true;

         else return IsPalindrome(word, ++i);
      }
      return false;
   }
}