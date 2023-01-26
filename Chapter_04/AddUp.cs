namespace GrokkingAlgorithms.Chapter_4;
public class AddUp
{
   public static int GetSum(int[] arr)
   {
      if (arr.Length == 1)
         return arr[0];

      int[] lessArr = new int[arr.Length - 1];
      Array.Copy(arr, lessArr, arr.Length - 1);
      return arr[arr.Length - 1] + GetSum(lessArr);
   }
}