#include <stdio.h>

char* last_digit(int n);

int main() {
    int n;
    char* result;
    
    printf("n = ");
    scanf("%d", &n);
    
    result = last_digit(n % 10);
    printf("number = %s", result);

    return 0;
}

char* last_digit(int n) {
    switch(n) {
        case 0:
            return "zero";
        case 1:
            return "one";
        case 2:
            return "two";
        case 3:
            return "three";
        case 4:
            return "four";
        case 5:
            return "five";
        case 6:
            return "six";
        case 7:
            return "seven";
        case 8:
            return "eight";
        case 9:
            return "nine";
        default:
            return "NaN";
    }
}