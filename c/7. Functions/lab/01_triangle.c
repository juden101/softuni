#include <stdio.h>

void print_triangle(int n) ;

int main() {
    int n;
    
    printf("n = ");
    scanf("%d", &n);
    
    print_triangle(n);

    return 0;
}

void print_triangle(int n) {
    int i, j;
    
    printf("\n");
    
    for (i = 1; i <= n; i++) {
        for (j = 1; j <= i; j++) {
            printf("%d ", j);
        }
        
        printf("\n");
    }

    for (i = n - 1; i >= 1; i--) {
        for (j = 1; j <= i; j++) {
            printf("%d ", j);
        }
        
        printf("\n");
    }
}