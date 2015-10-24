#include <stdio.h>

int main() {
    float a;
    float b;
    float c;

    printf("Input:\n");
    scanf("%f %f %f", &a, &b, &c);
    printf("sum = %.2f", a + b + c);
    
    return 0;
}