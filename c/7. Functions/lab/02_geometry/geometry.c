#include "geometry.h"
#include <math.h>

int is_intersect(double x1, double y1, double r1, double x2, double y2, double r2) {
    double dx = x2 - x1;
    double dy = y2 - y1;

    double d = sqrt((dy * dy) + (dx * dx));

    if (d > (r1 + r2)) {
        return 0;
    } else if (d < abs(r1 - r2)) {
        return 0;
    } else {
        return 1;
    }
}

int is_valid(int a, int b, int c) {
    if((a + b > c) && (a + c > b) && (b + c > a)) {  
        return 1;
    }
    
    return 0;
}