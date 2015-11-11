#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "str_lib.h"

int main()
{
	char buffer1[10] = "Soft";
    str_concat("Uni", buffer1, 7);
    printf("%s\n", buffer1);

    char buffer2[10]= "C";
    str_concat(" is cool", buffer2, 8);
    printf("%s\n", buffer2);
	
	return 0;
}