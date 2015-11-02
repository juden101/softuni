#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define SIZE 20

int main() 
{
    char buffer[SIZE];
    strncpy(buffer, "Blagoevgrad ice cold beer", SIZE);
    buffer[SIZE - 1] = '\0';
    
    printf("%s", buffer);
    
    return (EXIT_SUCCESS);
}

