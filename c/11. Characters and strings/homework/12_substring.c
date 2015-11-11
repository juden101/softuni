#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "str_lib.h"

int main()
{
	char *result1 = str_substr("Breaking Bad", 0, 2);
    printf("%s\n", result1);
    
    char *result2 = str_substr("Maniac", 3, 3);
    printf("%s\n", result2);
    
    char *result3 = str_substr("Maniac", 3, 5);
    printf("%s\n", result3);
    
    char *result4 = str_substr("Master Yoda", 13, 5);
    printf("%s\n", result4);
    
    free(result1);
    free(result2);
    free(result3);
    free(result4);
	
	return 0;
}