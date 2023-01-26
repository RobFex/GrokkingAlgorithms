namespace GrokkingAlgorithms.Chapter_3;
public class CountDown 
{
         static void Countdown(int n) 
         {
            Thread.Sleep(1000);
         	Console.WriteLine(n--);
         	if (n == 0)
         	{
         		Console.WriteLine("That's all!");
         		return;
         	}
         	Countdown(n);
         }
}