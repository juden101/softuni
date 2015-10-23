#include <stdio.h>

int main() {
    int n;
    
    printf("n = ");
    scanf("%d", &n);
    
    int fourthNumber = n % 10;
    int thirdNumber = (n / 10) % 10;
    int secondNumber = (n / 100) % 10;
    int firstNumber = (n / 1000) % 10;
    
    printf("sum of digits: %d\n", firstNumber + secondNumber + thirdNumber + fourthNumber);
    printf("reversed number: %d%d%d%d\n", fourthNumber, thirdNumber, secondNumber, firstNumber);
    printf("last digit in front: %d%d%d%d\n", fourthNumber, firstNumber, secondNumber, thirdNumber);
    printf("second and third digits exchanged: %d%d%d%d\n", firstNumber, thirdNumber, secondNumber, fourthNumber);

    return 0;
}