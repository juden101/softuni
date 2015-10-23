#include <stdio.h>

int main() {
    int a = 5;
    int b = 10;
    
    printf("before:\n");
    printf("a = %d\n", a);
    printf("b = %d\n\n", b);
    
    a ^= b;
    b ^= a;
    a ^= b;
    
    printf("after:\n");
    printf("a = %d\n", a);
    printf("b = %d\n", b);

    return 0;
}