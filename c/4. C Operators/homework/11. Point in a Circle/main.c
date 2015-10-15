#include <stdio.h>

int main() {
    float x, y;
    int radius = 2;
    
    printf("x = ");
    scanf("%f", &x);
    
    printf("y = ");
    scanf("%f", &y);
    
    printf("inside = %s", ((x * x) + (y * y)) <= radius * radius ? "yes" : "no");

    return 0;
}