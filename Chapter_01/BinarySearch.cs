namespace GrokkingAlgorithms.Chapter_1;

public class BinarySearch
{
    public static int Search(int[] nums, int target)
    {
        if (nums.Contains(target))
        {
            int i = nums.Length / 2;
            int lowest = 0;
            int highest = nums.Length;
            while (nums[i] != target)
            {
                if (nums[i] < target)
                {
                    lowest = i;
                    i = lowest + (highest - lowest) / 2;
                }
                else if (nums[i] > target)
                {
                    highest = i;
                    i = lowest + (highest - lowest) / 2;
                }
            }
            return i;
        }
        else
        {
            return -1;
        }
    }
}