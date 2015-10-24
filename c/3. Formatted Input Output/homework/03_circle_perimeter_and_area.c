#include <stdio.h>

#define PI 3.141592f

int main() {
    float r;
    float perimeter;
    float area;

    printf("r = ");
    scanf("%f", &r);
    
    perimeter = (2 * PI) * r;
    area = PI * (r * r);
    
    printf("perimeter: %.2f\n", perimeter);
    printf("area: %.2f", area);
    
    return 0;
}