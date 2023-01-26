namespace GrokkingAlgorithms.Chapter_4;

public class QuickSort 

{
   public static int[] SortArr(int[] arr, int left, int right) 
   {
      if (left >= right) return arr;
      int pivot = GetPivot(arr, left, right);
      
      SortArr(arr, left, pivot - 1);
      SortArr(arr, pivot + 1, right);

      return arr;
   }
   public static int GetPivot(int[] arr, int left, int right) 
   {
      int pivot = left - 1;
      int tmp;
      for (int i = left; i < right; i++) 
      {
         if (arr[i] < arr[right]) 
         {
            pivot++;
            tmp = arr[i];
            arr[i] = arr[pivot];
            arr[pivot] = tmp;
         }
      }
      pivot++;
      tmp = arr[pivot];
      arr[pivot] = arr[right];
      arr[right] = tmp;
      return pivot;
   }   
}