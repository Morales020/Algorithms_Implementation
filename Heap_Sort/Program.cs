namespace Heap_Sort
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = { 9, 4, 3, 8, 10, 2, 5 };
            HeapSortArray(arr);
            Console.WriteLine("Sorted array is ");
            PrintArray(arr);
        }

/// <summary>
/// ///////////////////////////////////////////////////////////////////////
/// </summary>

        // To heapify a subtree rooted with node i
        // which is an index in arr[].
        static void Heapify(int[] arr, int n, int i)
        {

            // Initialize largest as root
            int largest = i;

            // left index = 2*i + 1
            int l = 2 * i + 1;

            // right index = 2*i + 2
            int r = 2 * i + 2;

            // If left child is larger than root
            if (l < n && arr[l] > arr[largest])
            {
                largest = l;
            }

            // If right child is larger than largest so far
            if (r < n && arr[r] > arr[largest])
            {
                largest = r;
            }

            // If largest is not root
            if (largest != i)
            {
                int temp = arr[i]; // Swap
                arr[i] = arr[largest];
                arr[largest] = temp;

                // Recursively heapify the affected sub-tree
                Heapify(arr, n, largest);
            }
        }

        // Main function to do heap sort
        static void HeapSortArray(int[] arr)
        {
            int n = arr.Length;

            // Build heap (rearrange array)
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }

            // One by one extract an element from heap
            for (int i = n - 1; i > 0; i--)
            {

                // Move current root to end
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                // Call max heapify on the reduced heap
                Heapify(arr, i, 0);
            }
        }

        // A utility function to print array of size n
        static void PrintArray(int[] arr)
        {
            foreach (int value in arr)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
        }

    }
}
