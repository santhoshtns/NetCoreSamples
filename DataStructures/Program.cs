namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 2, 5, -4, 11, 0, 18, 22, 67, 51, 6 };
            QuickSort.Quick_Sort(arr, 0, arr.Length - 1);

            //new Arrays().RearrangeArray();
            //new Arrays().MergeTwosortedArray();
            //new Arrays().FirstNonRepeatingNumber();
            //new Arrays().FirstAndSecondSmallest();
            //new Arrays().Actions();
        }
    }
}
