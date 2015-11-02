#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main() 
{
    const char *url = "https://softuni.bg/forum";
    char *occurrence = strchr(url, '/');
    if (occurrence)
    {
        size_t index = occurrence - url;
        printf("Index: %lu\n", index);
        printf("Remainder: %s", occurrence);
    }
    
    return (EXIT_SUCCESS);
}

