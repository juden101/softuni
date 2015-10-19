#include <stdio.h>
#include <stdlib.h>

int random_number(int min_num, int max_num);

int main() {
    int n, min, max, i;
    
    printf("n = ");
    scanf("%d", &n);
    
    printf("min = ");
    scanf("%d", &min);
    
    printf("max = ");
    scanf("%d", &max);
    
    for (i = 0; i < n; i++) {
        printf("%d ", rand() % (max - min + 1) + min);
    }

    return 0;
}