namespace GrokkingAlrogithms.Chapter_2;
public class SelectionSort 
{
         public static int[] SortArr(int[] arr) 
         {
         	int minIndex = 0;
         	for (int i = 0; i < arr.Length; i++) 
         	{
         		minIndex = i;
         		for(int j = minIndex + 1; j < arr.Length; j++) 
         		{
         			if (arr[j] < arr[minIndex]) 
         			{
         				int buffer = arr[minIndex];
         				arr[minIndex] = arr[j];
         				arr[j] = buffer;
         			}
         		}
         	}
         	return arr;
         }
}