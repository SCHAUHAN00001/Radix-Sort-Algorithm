using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radix_Sort_Algorithm
{
    internal class Program
    {
        class RadixSort
        {
            
            static int GetMax(int[] arr)
            {
                int max = arr[0];
                for (int i = 1; i < arr.Length; i++)
                {
                    if (arr[i] > max)
                    {
                        max = arr[i];
                    }
                }
                return max;
            }

           
            static void CountingSort(int[] arr, int exp)
            {
                int n = arr.Length;
                int[] output = new int[n];
                int[] count = new int[10];

                
                for (int i = 0; i < 10; i++)
                {
                    count[i] = 0;
                }

                
                for (int i = 0; i < n; i++)
                {
                    count[(arr[i] / exp) % 10]++;
                }

                
                for (int i = 1; i < 10; i++)
                {
                    count[i] += count[i - 1];
                }

               
                for (int i = n - 1; i >= 0; i--)
                {
                    output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                    count[(arr[i] / exp) % 10]--;
                }

                
                for (int i = 0; i < n; i++)
                {
                    arr[i] = output[i];
                }
            }

            
            static void RadixSortAlgorithm(int[] arr)
            {
                int max = GetMax(arr);

                
                for (int exp = 1; max / exp > 0; exp *= 10)
                {
                    CountingSort(arr, exp);
                }
            }

            
            static void DisplayArray(int[] arr)
            {
                int n = arr.Length;
                for (int i = 0; i < n; i++)
                {
                    Console.Write(arr[i] + " ");
                }
                Console.WriteLine();
            }
            static void Main(string[] args)
            {
                int[] arr = { 170, 45, 75, 90, 802, 24, 2, 66 };

                Console.WriteLine("Original Array:");
                DisplayArray(arr);

                RadixSortAlgorithm(arr);

                Console.WriteLine("\nSorted Array:");
                DisplayArray(arr);
                Console.ReadLine();
            }
        }
    }
}
