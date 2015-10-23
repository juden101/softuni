#include <stdio.h>

int contains_element(int*, int, int);

int main(
{
    int n, x, i;
    
    printf("n = ");
    scanf("%d", &n);
    
    int numbers[n];
    
    for (i = 0; i < n; i++)
    {
        scanf("%d", &numbers[i]);
    }
    
    printf("x = ");
    scanf("%d", &x);
    
    printf("contains = %s", contains_element(numbers, n, x) ? "true" : "false");

    return 0;
}

int contains_element(int arr[], int arrLength, int element)
{
    int i;
    
    for (i = 0; i < arrLength; i++)
    {
        if (arr[i] == element)
        {
            return 1;
        }
    }
    
    return 0;
}