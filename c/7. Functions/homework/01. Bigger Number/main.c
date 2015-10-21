#include <stdio.h>

int main() {
    int a, b, max;
    
    printf("a = ");
    scanf("%d", &a);
    
    printf("b = ");
    scanf("%d", &b);
    
    max = get_max(a, b);
    printf("max = %d", max);

    return 0;
}

int get_max(int a, int b) {
    return a >= b ? a : b;
}