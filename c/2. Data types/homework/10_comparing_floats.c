#include <stdio.h>
#include <math.h>

int main() {
    float eps = 0.000001;
    
    printf("%s\n", fabs(5.3 - 6.01) < eps ? "true" : "false");
    printf("%s\n", fabs(5.00000001 - 5.00000003) < eps ? "true" : "false");
    printf("%s\n", fabs(5.00000005 - 5.00000001) < eps ? "true" : "false");
    printf("%s\n", fabs(-0.0000007 - 0.00000007) < eps ? "true" : "false");
    printf("%s\n", fabs(-4.999999 - -4.999998) < eps ? "true" : "false");
    printf("%s\n", fabs(4.999999 - 4.999998) < eps ? "true" : "false");
    
    return 0;
}