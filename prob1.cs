/*
1) Write a C# program to enter the following numbers:
115, 182, 191, 31, 196, 1099, 5, 172, 10, 179, 83, 21, 20, 21, 186, 177, 195, 193, 188, 199, 62, 109, 105, 183, 110
then, compute the following statistics for n given values of data:
(i) Mean
(ii) Mode
(iii) Median
(iv) Variance
(v) P20
(vi) P50
(vii) Third quartile
(viii) Second Quartile
(ix) Third Quartile
(x) Range
(xi) Interquartile Range
(xii) Standard Division
(xiii) Summation of *Deviations
*/

using System;

class Program
{
    static void Main()
    {
        double[] arr = { 115, 182, 191, 31, 196, 1099, 5, 172, 10, 179, 83, 21, 20, 21, 186, 177, 195, 193, 188, 199, 62, 109, 105, 183, 110 };
        int n = arr.Length;

        Array.Sort(arr);
    
        Console.WriteLine("Mean =  " + Mean(arr));
        
        Console.WriteLine("Mode = " + Mode(arr));
        
        Console.WriteLine("Median = " + Median(arr));
        
        Console.WriteLine("Variance = " + Variance(arr));
        
        Console.WriteLine("P20 = " + Percentile(arr , 20));
        
        Console.WriteLine("P50 = " + Median(arr)); // p50 = Median
        
        Console.WriteLine("q1 = " + Percentile(arr , 25)); // q1 = P25
        
        Console.WriteLine("q2 = " + Median(arr)); // q2 = P50 = Median
        
        Console.WriteLine("q3 = " + Percentile(arr , 75));
        
        Console.WriteLine("Range = " + Range(arr));
        
        Console.WriteLine("IQR = " + ( Percentile(arr , 75) - Percentile(arr , 25))); //IQR = q3 -q1
        
        Console.WriteLine("Standard Deviation = " + Math.Sqrt(Variance(arr)));
        
        Console.WriteLine("Summation of Deviations = " + Sum_Deviations(arr) + "  = zero");
    }
        
    
    // (i) Mean
    static double Mean(double[] arr)
    {
        int n = arr.Length;
        double sum = 0;
        for (int i = 0; i < n; i++) sum += arr[i];
        return sum / n;
    }
    
    // (ii) Mode
    static double Mode(double[] arr)
    {
        int n = arr.Length;
        double mode = arr[0];
        int max_count = 0;
        for (int i = 0; i < n; i++)
        {
            int count = 0;
            for (int j = 0; j < n; j++)
            {
                if (arr[j] == arr[i]) count++;
            }
            if (count > max_count)
            {
                max_count = count;
                mode = arr[i];
            }
        }
        return mode;
    }
    
    // (iii) Median
    static double Median(double[] arr)
    {
        int n = arr.Length;
        double median;
        if (n % 2 == 1)
        {
            median = arr[n / 2];
        }
        else
        {
            median = (arr[n / 2 - 1] + arr[n / 2]) / 2.0;
        }
        return median;
    }
    
    // (iv) Variance
    static double Variance(double[] arr)
    {
        int n = arr.Length;
        double mean = Mean(arr);
        double vsum = 0;
        for (int i = 0; i < n; i++)
        {
            vsum += (arr[i] - mean) * (arr[i] - mean);
        }
        return vsum / (n - 1);
    }
    
    //(v) P20
    //(vi) P50 
    //(vii) Third quartile
    //(viii) Second Quartile
    //(ix) Third Quartile
    static double Percentile(double[] arr, double p)
    {
        int n = arr.Length;
        int i = (int)Math.Round(p/100 * (n - 1));
        return arr[i];
    }
    
    // (x) Range
    static double Range(double[] arr)
    {
        int n = arr.Length;
        return arr[n - 1] - arr[0];
    }
    
    // (xiii) Summation of Deviations
    static double Sum_Deviations(double[] arr)
    {
        int n = arr.Length;
        double mean = Mean(arr);
        double SD = 0;
        for (int i = 0; i < n; i++)
        {
            SD += (arr[i] - mean);
        }
        return SD;
    }
}
