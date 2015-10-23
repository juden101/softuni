#include <stdio.h>

int main() {
    int n;
    
    printf("n = ");
    scanf("%d", &n);
    
    printf("%s", (n / 100) % 10 == 7 ? "true" : "false");

    return 0;
}