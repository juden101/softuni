#include <stdio.h>

int main() {
    float a, b, h;
    
    printf("a = ");
    scanf("%f", &a);
    
    printf("b = ");
    scanf("%f", &b);
    
    printf("h = ");
    scanf("%f", &h);

    printf("area = %f", ((a + b) * h) / 2);
    
    return 0;
}