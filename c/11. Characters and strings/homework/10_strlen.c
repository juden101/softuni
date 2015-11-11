#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "str_lib.h"

int main()
{
    printf("%lu\n", str_length("Soft"));
    printf("%lu\n", str_length("SoftUni"));
    
    char buffer[10] =  {'C', '\0', 'B', 'a', 'b', 'y' };
    printf("%lu\n", str_length(buffer));
	
	return 0;
}