#include <stdio.h>
#include <math.h>

int main() {
    float x, y;
    
    printf("x = ");
    scanf("%f", &x);
    
    printf("y = ");
    scanf("%f", &y);
    
    int isInCircle = (((pow(x - 1, 2) + (pow(y - 1, 2))) <= 1.5 * 1.5));
    int isInRectangular = (x <= 5 && x >= -1) && (y >= -1 && y <= 1);

    printf("%s", isInCircle && !isInRectangular ? "yes" : "no");
    
    return 0;
}