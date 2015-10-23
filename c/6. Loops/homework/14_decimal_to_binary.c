#include <stdio.h>
#include <string.h>

#define MAX 100

int main() {
    long decimalNumber;
    char binary[MAX] = { '\0' };
    int index = 0, i;
    
    printf("decimal number = ");
    scanf("%ld", &decimalNumber);
    
    while (decimalNumber != 0)
    {
        if(decimalNumber % 2 == 0)
        {
            binary[index++] = '0';
        }
        else
        {
            binary[index++] = '1';
        }

        decimalNumber /= 2;
    }

    if(binary[0] == '\n')
    {
        binary[0] = '0';
    }
    
    for (i = index; i >= 0; i--) {
        printf("%c", binary[i]);
    }

    return 0;
}