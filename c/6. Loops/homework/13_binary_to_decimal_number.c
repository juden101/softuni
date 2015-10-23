#include <stdio.h>
#include <string.h>

int main() {
    int i, decimalNumber = 0;
    char* binary;
    
    printf("binary = ");
    scanf("%s", binary);
    
    for (i = 0; i < strlen(binary); i++) {
        decimalNumber += ((int)binary[i] - 48) * int_pow(2, (unsigned int)(strlen(binary) - i - 1));
    }
    
    printf("decimal = %d", decimalNumber);

    return 0;
}

int int_pow(int x, unsigned int pow) {
    int result = 1, i;
    
    for (i = 0; i < pow; i++) {
        result *= x;
    }

    return result;
}