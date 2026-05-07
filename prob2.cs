//2) Write a C# program to check each input number is an outlier or not.
using System;

public class Program
{
    public static void Main()
    {
        //example data set
         double[] arr = { 115, 182, 191, 1, 196, 1099, -500, 172, 10, 179, 83, 21, 888, 21, 186, 177, -195, 193, 188, 199, 62, 109, 105, 183, 110 };
        int n = arr.Length;

        Array.Sort(arr);

        //Outliers are data points that differ significantly from the majority of a dataset, appearing as abnormally high or low values
        //Lower Boundary = Q1 - 1.5 IQR
        //Upper Boundary = Q3 + 1.5 IQR

        double q1 = Percentile(arr , 25);
        double q3 = Percentile(arr , 75);
        double Iqr = q3 - q1;

        for(int i=0; i<n; i++)
        {
            if(arr[i] < q1 - 1.5 * Iqr || arr[i] > q3 + 1.5 * Iqr )
            Console.WriteLine($"{arr[i]} is an outlier");

            else 
            Console.WriteLine($"{arr[i]} is not an outlier");
        }
    }

    static double Percentile(double[] arr, double p)
    {
        int n = arr.Length;
        int i = (int)Math.Round(p/100 * (n - 1));
        return arr[i];
    }
}
