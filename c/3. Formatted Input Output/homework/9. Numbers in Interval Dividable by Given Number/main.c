#include <stdio.h>

int main() {
    int start, end, i, p = 0;
    
    printf("start = ");
    scanf("%d", &start);
    
    printf("end = ");
    scanf("%d", &end);
    
    for (i = start; i <= end; i++)
    {
        if (i % 5 == 0) {
            p++;
        }
    }
    
    printf("p = %d", p);
    
    return 0;
}