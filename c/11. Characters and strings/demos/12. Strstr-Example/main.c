#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main() 
{
    char *name = "Nakov";
    char *ptr = strstr(name, "ko");
    if (ptr)
    {
        printf("%lu\n", ptr - name);
        printf("%s", ptr);
    }
    
    return (EXIT_SUCCESS);
}

