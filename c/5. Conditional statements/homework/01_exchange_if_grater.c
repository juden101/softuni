#include <stdio.h>

int main() {
    float a, b, temp;
    
    printf("a = ");
    scanf("%f", &a);
    
    printf("b = ");
    scanf("%f", &b);
    
    if (a > b) {
        temp = a;
        a = b;
        b = temp;
    }
    
    printf("result = %.1f %.1f", a, b);

    return 0;
}