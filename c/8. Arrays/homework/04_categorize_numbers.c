#include <stdio.h>
#include <float.h>

void calculate_arr(float [], int);

int main()
{
    int n, i;
    
    printf("n = ");
    scanf("%d", &n);
    
    float rounded[n];
    float floating[n];
    
    int roundedSize = 0, floatingSize = 0;
    
    for (i = 0; i < n; i++)
    {
        float input;
        scanf("%f", &input);
        
        if (input == (int)input)
        {
            rounded[roundedSize] = input;
            roundedSize++;
        }
        else
        {
            floating[floatingSize] = input;
            floatingSize++;
        }
    }
    
    calculate_arr(floating, floatingSize);
    calculate_arr(rounded, roundedSize);

    return 0;
}

void calculate_arr(float arr[], int size)
{
    int i;
    float min = FLT_MAX, max = FLT_MIN, avg, sum = 0;
    
    printf("[");
    
    for (i = 0; i < size; i++)
    {
        printf("%g", arr[i]);
        
        if (i < size - 1)
        {
            printf(", ");
        }
        
        if (min > arr[i])
        {
            min = arr[i];
        }
        
        if (max < arr[i])
        {
            max = arr[i];
        }
        
        sum += arr[i];
    }
    
    avg = sum / size;
    
    printf("] -> min: %g, max: %g, sum: %g, avg: %g\n", min, max, sum, avg);
}