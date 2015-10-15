#include <stdio.h>

int main() {
    float width, height;
    
    printf("width = ");
    scanf("%f", &width);
    
    printf("height = ");
    scanf("%f", &height);
    
    printf("perimeter = %f\n", (width * 2) + (height * 2));
    printf("area = %f\n", width * height);

    return 0;
}