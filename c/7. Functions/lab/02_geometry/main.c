#include <stdio.h>
#include "geometry.h"

int main() {
    // valid triangle
    printf("%d\n", is_valid(3, 2, 2));
    
    // invalid triangle
    printf("%d\n", is_valid(15, 1, 1));
    
    // intersect
    printf("%d\n", is_intersect(3, 2, 2, 3, 2, 2));
    
    // does not intersect
    printf("%d\n", is_intersect(3, 2, 2, 18, 2, 2));

    return 0;
}