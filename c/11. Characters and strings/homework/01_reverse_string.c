#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "read_line.h"
#include "string_reverse.h"

int main()
{
	char* string = read_line();
    size_t size = strlen(string);
    
    char* result = string_reverse(string, size);
    printf("%s\n", result);

    free(string);
    free(result);

	return 0;
}

