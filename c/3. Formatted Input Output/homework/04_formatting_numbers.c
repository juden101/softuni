#include <stdio.h>
#include <stdlib.h>

char *decimal_to_binary(int n)
{
    int i = 0, j = 9;
    char *binary = (char *)malloc(sizeof(char) * 3);
    
    for (j = 0; j < 9; j++)
    {
        binary[j] = '0';
    }
    
    while (i < 9)
    {
        int bit = (n >> i) & 1;
        binary[j] = bit == 1 ? '1' : '0';
        
        i++;
        j--;
    }
 
   return binary;
}

int main() {
    int a;
    float b, c;

    printf("a = ");
    scanf("%d", &a);

    printf("b = ");
    scanf("%f", &b);

    printf("c = ");
    scanf("%f", &c);
    
    char *format = "|%-10X|%s|%10.2f|%-10.3f|";
    printf(format, a, decimal_to_binary(a), b, c);
    
    return 0;
}