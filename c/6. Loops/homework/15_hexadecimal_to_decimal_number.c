#include <stdio.h>
#include <string.h>

int hex_number(char hexChar);

int main() {
    int i, decimalNumber = 0;
    char* hexadecimalNumber;
    
    printf("hexadecimal = ");
    scanf("%s", hexadecimalNumber);
    
    for (i = 0; i < strlen(hexadecimalNumber); i++) {
        decimalNumber += hex_number(hexadecimalNumber[i]) * int_pow(16, (long)(strlen(hexadecimalNumber) - i - 1));
    }
    
    printf("decimal = %d", decimalNumber);

    return 0;
}

int hex_number(char hexChar) {
    switch (hexChar) {
        case '0':
            return 0;
        case '1':
            return 1;
        case '2':
            return 2;
        case '3':
            return 3;
        case '4':
            return 4;
        case '5':
            return 5;
        case '6':
            return 6;
        case '7':
            return 7;
        case '8':
            return 8;
        case '9':
            return 9;
        case 'a':
        case 'A':
            return 10;
        case 'b':
        case 'B':
            return 11;
        case 'c':
        case 'C':
            return 12;
        case 'd':
        case 'D':
            return 13;
        case 'e':
        case 'E':
            return 14;
        case 'f':
        case 'F':
            return 15;
        default:
            break;
    }

    return 0;
}

int int_pow(int x, unsigned int pow) {
    int result = 1, i;
    
    for (i = 0; i < pow; i++) {
        result *= x;
    }

    return result;
}