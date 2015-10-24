#include <stdio.h>
#include <math.h>

int main() {
    int n, i, isPrime;
    
    printf("n = ");
    scanf("%d", &n);
    
    if (n == 1)
    {
        isPrime = 0;
    }
    else if (n == 2)
    {
        isPrime = 1;
    }
    else
    {
        isPrime = 1;
        
        for (i = 2; i <= ceil(sqrt(n)); ++i)
        {
            if (n % i == 0)
            {
                isPrime = 0;
            }
        }
    }
    
    printf("%s", isPrime ? "true" : "false");

    return 0;
}