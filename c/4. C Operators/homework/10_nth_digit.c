#include <stdio.h>

int main() {
    int number, n, found;
    
    printf("number = ");
    scanf("%d", &number);
    
    printf("n = ");
    scanf("%d", &n);
    
    while (number > 0)
    {
        if (n == 1)
        {
            found = 1;
            printf("%d", number % 10);
            
            break;
        }
        
        number /= 10;
        n--;
    }
    
    if (!n)
    {
        printf("-");
    }

    return 0;
}