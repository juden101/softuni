#include <assert.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char *decimal_to_binary(int n)
{
   int i, j, count;
   char *pointer;
 
   count = 0;
   pointer = (char*)malloc(10+1);
 
   if (pointer == NULL)
   {
      exit(EXIT_FAILURE);
   }
 
   for (i = 9; i >= 0; i--)
   {
      j = n >> i;
 
      if (j & 1) {
         *(pointer+count) = 1 + '0';
      } else {
         *(pointer+count) = 0 + '0';
      }
      
      count++;
   }
   
   *(pointer+count) = '\0';
 
   return pointer;
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