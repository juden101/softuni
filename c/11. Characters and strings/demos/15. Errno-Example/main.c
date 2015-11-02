#include <stdio.h>
#include <stdlib.h>
#include <errno.h>
#include <string.h>

int main() 
{
    char *ptr = malloc(2L << 32);
    if (!ptr)
    {
        fprintf(stderr, "%s\n", strerror(errno));
    }
    
    return (EXIT_SUCCESS);
}

