#include <stdio.h>

int main()
{
    int n, i;
    
    printf("n = ");
    scanf("%d", &n);
    
    int numbers[n];
    
    for (i = 0; i < n; i++)
    {
        scanf("%d", &numbers[i]);
    }
    
    printf("result = ");
    
    for (i = 0; i < n; i++)
    {
        printf("%d ", numbers[i]);
    }

    return 0;
}
