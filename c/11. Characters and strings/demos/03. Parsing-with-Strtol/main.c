#include <stdio.h>
#include <stdlib.h>
#include <errno.h>
#include <limits.h>

int main() {

    char number[] = "123213213213213";
    char *remainder;
    
    errno = 0;
    long num = strtol(number, &remainder, 10);
    
    if (remainder == number)
    {
        printf("Format error\n");
    }
    else if (errno == ERANGE || 
            (num < INT_MIN || num > INT_MAX))
    {
        printf("Overflow error\n");
    }
    else 
    {
        int result = num;
        printf("%d\n", result);
    }
    
    printf("%s\n", remainder);
    
    return (EXIT_SUCCESS);
}

