#include <stdio.h> 
#include <stdlib.h>
#include <string.h>
#include <math.h>

#define MAX 1024

double reverse(char *n, int *error);

int main(void) {
    int error = 0;
    char n[MAX];
    
    printf("n =  ");
    gets(n);
    
    double reversed = reverse(n, &error);
    
    if (error == 1) {
        printf("Invalid format");
    } else {
        printf("%lf", reversed);
    }
    
    return 0; 
}

double reverse(char *digits, int *error) {
    char reversedDigits[MAX] = {0};
    int digitsLength = strlen(digits) - 1;
    
    while(digitsLength >= 0) {
        int currentASCIChar = (int)digits[digitsLength] - 48;
        
        if (currentASCIChar != -2 && !(currentASCIChar >= 0 && currentASCIChar <= 9)) {
            *error = 1;
            break;
        }
        
        reversedDigits[strlen(digits) - digitsLength - 1] = digits[digitsLength];
        digitsLength--;
    }
    
    return atof(reversedDigits);
}