#include <stdio.h>

int main() {
    int n, index = 1, i, j;
    
    printf("n = ");
    scanf("%d", &n);
    
    for (i = 0; i < n; i++) {
        for (j = 0; j < n; j++) {
            printf("%d", j + index);
        }

        index++;
        printf("\n");
    }

    return 0;
}