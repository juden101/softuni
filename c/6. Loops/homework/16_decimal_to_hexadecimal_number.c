#include <stdio.h>

#define MAX 100

char hex_char(unsigned long long decimalNumber);

int main() {
    unsigned long long decimalNumber, index = 0, i;
    char hexadecimalNumber[MAX] = { '\0' };

    printf("decimal = ");
    scanf("%llu", &decimalNumber);

    while (decimalNumber != 0) {
        hexadecimalNumber[index++] = hex_char(decimalNumber % 16);
        decimalNumber /= 16;
    }
    
    for (i = index; i > 0; i--) {
        printf("%c", hexadecimalNumber[i - 1]);
    }

    return 0;
}

char hex_char(unsigned long long decimalNumber) {
    switch (decimalNumber) {
        case 0:
            return '0';
        case 1:
            return '1';
        case 2:
            return '2';
        case 3:
            return '3';
        case 4:
            return '4';
        case 5:
            return '5';
        case 6:
            return '6';
        case 7:
            return '7';
        case 8:
            return '8';
        case 9:
            return '9';
        case 10:
            return 'A';
        case 11:
            return 'B';
        case 12:
            return 'C';
        case 13:
            return 'D';
        case 14:
            return 'E';
        case 15:
            return 'F';
        default:
            break;
    }

    return '\0';
}